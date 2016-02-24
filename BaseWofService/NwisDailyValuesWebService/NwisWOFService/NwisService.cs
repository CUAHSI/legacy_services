using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Caching;
using System.IO;
using System.Text;
using System.Net;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using WaterOneFlow.Schema.v1;
using WaterOneFlowImpl;


/*
 * XTODO discharge to daily values
 * TODO add parameter_cd to query string to get only the appropriate parameter
 * TODO add checks to make sure the network is NWIS for the site code
 * TODO variable checks.
 * XTODO add units to  variable (need to figure out how to do it with a variableParam call)
 * XTODO Add actual times for water quality measurments
 * TODO can we get no time for Daily Data.
 * TODO Time zone offsets for stations.
 *       Date Time parsing needs to be smart about site offsets. Need to include site times.
 * TODO add queryInfo to siteRespone xml
 * TODO add queryInfo to VariablesResponse (if appropriate)
 * TODO many QA (potiential qualifiers) columns in the qwdata call. what do we want to do with them
 * */

/*
 * getVarColum
 * getVarCodeColumn contain the logic for options aks statistics
 */

/* usgs changes to services
 * Aug 2007
 * * parameter_cd change to parm_cd
 * * Only returning 1 year of data, if begin date is not specified.
 * * not retunring anything if a pergin date or period is not used in unit values
 */
namespace WaterOneFlow.Nwis
{
    public class NwisService : IDisposable
    {
        private string vbNewLine = System.Environment.NewLine;
        private EventLog waterLog;


        /// <summary>
        /// codes for the parameters statistics. 
        /// As part of the column name: instrument_code_statistic
        /// </summary>

        private static Dictionary<String, String> Statistic = new Dictionary<string, string>();

        public enum FaultCode
        {
            Client = 0,
            Server = 1,
            External = 2,
            Unknown = 3
        }

        public enum usgsApplications
        {
            dv,
            uv
        }
        private Cache appCache;

        private HttpContext appContext;

        // two static strings to use in retriving items from the cache
        private static string variableDataSetCache = "nwisVariables";
        private static string sitCache = "siteInfoCache:";
        private static string SiteXMLCache = "siteXML:";
        private static string iidPORCache = "iidPeriodOfRecord:";
        private static string dvPORCache = "dvPeriodOfRecord:";
        private static string gwPORCache = "gwPeriodOfRecord:";
        private static string uvPORCache = "uvPeriodOfRecord:";

        //private static DataSet variableDataSet;
        private static VariablesDataset variableDataSetField;

        public NwisService(HttpContext aContext)
        {
            appContext = aContext;
            appCache = appContext.Cache;

            // create that statistic values
            if (Statistic.Count == 0)
            {
                Statistic.Add("max", "00001");
                Statistic.Add("min", "00002");
                Statistic.Add("mean", "00003");
                Statistic.Add("qualifiers", "cd");
            }



            if (!EventLog.SourceExists("WaterOneFlow"))
            {
                EventLog.CreateEventSource("WaterOneFlow", "WaterOneFlowEvents");
            }
            waterLog = new EventLog();
            waterLog.Source = "WaterOneFlow";
            waterLog.WriteEntry("NWIS web service started.");


        }

        #region Public Service Implementations
        public SiteInfoResponseType GetSiteInfo(string siteId)
        {
            return GetSiteInfo(siteId, null);
        }
        public SiteInfoResponseType GetSiteInfo(string siteId, int? sourceId)
        {
            string Network;
            string SiteCode;
            //WSUtils.ParseSiteId(siteId, out Network, out SiteCode);

            /* logic
             * look at siteInfo XML cache
             * if no cache exists, 
             * get siteInventory XML from USGS
             * parse, figure out what data is available
             * use threading to simutaneouly retrieve variable information
             * when thread return populate variable record
             *  cache siteInfo XML
             * */

            /* some logic for adding variable info
                      * read returned XML,
                      * look at 
                      *  * rt_bol
                      *  * discharge_count_nu,
                      *  * peak_count_nu
                      *  * qw_count_nu
                      *  * gw_count_nu
                      * 
                      * If any of the above are non-zero, create a threadpool.
                      * For the ones that are non-zero retrieve values by going to the appropriate parameter
                      *  * grab a one day record (except for real time)
                      *  * parse parameters
                      *  * match with parameter numbers, and statistical matches.
                      * even if a value is non-zero, WE WILL GET HTML pages, and other errors.
                      *   *** such errors are not fatal flaws. Just ignore (or was it log)***
                      * add appropriate lists
             * for time periods use the information from the siteInventory XML, for now.
             * 
                      * **** CACHE siteInventory XML ****
             * 
                      */

            try
            {
                locationParam sq = new locationParam(siteId);
                Network = sq.Network;
                SiteCode = sq.SiteCode;
                if (sq.isGeometry)
                {
                    throw new WaterOneFlowException("Location by Geometry not accepted: " + siteId);
                }
            }
            catch (WaterOneFlowException we)
            {
                waterLog.WriteEntry("Bad SiteID:" + siteId, EventLogEntryType.Information);
                throw;
            }
            catch (Exception e)
            {
                waterLog.WriteEntry("Uncaught exception:" + e.Message, EventLogEntryType.Error);
                throw new WaterOneFlowException("Sorry. Your submitted site ID for this getSiteInfo request caused an problem that we failed to catch programmatically: " + e.Message);
            }


            SiteInfoResponseType result = createSiteInfoResponse(new string[] { SiteCode }, sourceId);

            result.queryInfo.criteria.locationParam = siteId;
            result.site[0].siteInfo.siteCode[0].network = "NWIS";

            return result;
        }

        public SiteInfoResponseType GetSites(string[] siteIDs)
        {
            XmlDocument XMLResponse = new XmlDocument();
            // @TODO call locationParam
            // string[] iDs = Array.ConvertAll(siteIDs, new Converter<string, string>(WSUtils.SiteCode));
            string[] iDs = Array.ConvertAll(siteIDs, new Converter<string, string>(locationParam.getSiteCode));
            SiteInfoResponseType result = CuahsiBuilder.CreateASetOfSiteResponses(siteIDs.Length, 1);

            string numbers = null;
            foreach (string site in iDs)
            {
                numbers += site + Environment.NewLine;
            }
            string URL = "http://waterdata.usgs.gov/nwis/inventory?multiple_site_no=" + HttpUtility.UrlEncode(numbers) + "&sort_key=site_no&group_key=NONE&format=sitefile_output&sitefile_output_format=xml&column_name=agency_cd&column_name=site_no&column_name=station_nm&column_name=dec_lat_va&column_name=dec_long_va&column_name=coord_meth_cd&column_name=state_cd&column_name=county_cd&column_name=alt_va&list_of_search_criteria=multiple_site_no";
            try
            {
                XMLResponse.LoadXml(GetHTTPFile(URL, 30));
                XmlNodeList aSiteSet = XMLResponse.GetElementsByTagName("site_no");
                XmlNodeList aStationSet = XMLResponse.GetElementsByTagName("station_nm");
                int count = 0;
                foreach (XmlNode aSiteNode in aSiteSet)
                {
                    result.site[count].siteInfo.siteCode[0].network = "NWIS";
                    if (string.IsNullOrEmpty(aSiteNode.InnerText))
                    {
                        continue;
                    }
                    result.site[count].siteInfo.siteCode[0].Value = aSiteNode.InnerText;
                    result.site[count].siteInfo.siteName = aStationSet[count].InnerText;
                    ((LatLonPointType)result.site[count].siteInfo.geoLocation.geogLocation).latitude = Convert.ToDouble(XMLResponse.GetElementsByTagName("dec_lat_va")[count].InnerText);
                    ((LatLonPointType)result.site[count].siteInfo.geoLocation.geogLocation).longitude = Convert.ToDouble(XMLResponse.GetElementsByTagName("dec_long_va")[count].InnerText);
                    count++;
                }

                List<site> aList = new List<site>(result.site);
                List<site> removeList = new List<site>();
                foreach (site aSite in aList)
                {
                    if (string.IsNullOrEmpty(aSite.siteInfo.siteCode[0].Value))
                        removeList.Add(aSite);
                }
                foreach (site aSite in removeList)
                    aList.Remove(aSite);
                result.site = aList.ToArray();
            }
            catch (Exception e)
            {
                string ex = CreateMessage(e);
                waterLog.WriteEntry(ex, EventLogEntryType.Error);
                throw new WaterOneFlowException("An External resource failed.", e);
            }
            return result;
        }

        public VariablesResponseType GetVariableInfo(string variable)
        {
            if (String.IsNullOrEmpty(variable))
            {
                VariablesResponseType vrt = new VariablesResponseType();
                //vrt.variables = NwisVariableCatalog.GetVariables();
                vrt.variables = ODvariables.GetVariables();
                return vrt;
            }
            VariableParam vp;
            try
            {
                vp = new VariableParam(variable);

            }
            catch (WaterOneFlowException we)
            {
                waterLog.WriteEntry("Bad Variable Request '" + variable + "'", EventLogEntryType.Information);
                throw;
            }
            catch (Exception e)
            {
                waterLog.WriteEntry("uncaught exception duing Variable Request '" + variable + "'", EventLogEntryType.Error);
                throw new WaterOneFlowException("Sorry. Your variable parameter caused an exception that we failed to catch:" + e.Message);

            }

            VariablesResponseType Response = CuahsiBuilder.CreateAVariable();
            /* 
             * if (!CheckDataBaseForVariable(variable, Response))
            {
                try
                {
                      string sURL = "http://nwis.waterdata.usgs.gov/nwis/pmcodes/pmcodes?pm_group=ALL&pm_search=" + vp.Code + "&format=rdb&show=parameter_cd&show=parameter_group_nm&show=parameter_nm";
                    using (StringReader streamreader = new StringReader(GetHTTPFile(sURL, 10)))
                    {
                        string line = streamreader.ReadLine();
                        while (!(line.Substring(0, 1) != "#"))
                        {
                            line = streamreader.ReadLine();
                        }
                        line = streamreader.ReadLine();
                        line = streamreader.ReadLine();
                        string ParamDescription = line.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries)[2];
                        int LastComma = ParamDescription.LastIndexOf(",");
                        Response.variables[0].variableCode[0].Value = vp.Code;
                        Response.variables[0].variableCode[0].vocabulary = "NWIS";
                        Response.variables[0].variableName = ParamDescription.Substring(0, LastComma);

                        Response.variables[0].units.Value = ParamDescription.Substring(LastComma + 2); // definitely the text, and not the units abbreviation
                    }
                }
                catch (Exception e)
                {
                    string ex = CreateMessage(e);
                    waterLog.WriteEntry(ex, EventLogEntryType.Error);
                    throw new WaterOneFlowException("An External resource failed.", e);
                }
            } */
            //Response.variables[0] = NwisVariableCatalog.getVariable(vp.Code, variableDataSet);
            Response.variables = ODvariables.getVariable(vp.Code, variableDataSet);
            return Response;
        }

        public TimeSeriesResponseType GetDailyValues(string siteNumber, string variable, Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate)
        {
            TimeSeriesResponseType result = null;
            string Network;
            string SiteCode;
            //WSUtils.ParseSiteId(siteId, out Network, out SiteCode);
            try
            {
                locationParam sq = new locationParam(siteNumber);
                Network = sq.Network;
                SiteCode = sq.SiteCode;
                if (sq.isGeometry)
                {
                    throw new WaterOneFlowException("Location by Geometry not accepted: " + siteNumber);
                }
            }
            catch (WaterOneFlowException we)
            {
                waterLog.WriteEntry("Bad SiteID:" + siteNumber, EventLogEntryType.Information);
                throw;
            }
            catch (Exception e)
            {
                waterLog.WriteEntry("Uncaught exception:" + e.Message, EventLogEntryType.Error);
                throw new WaterOneFlowException("Sorry. Your submitted site ID for this getSiteInfo request caused an problem that we failed to catch programmatically: " + e.Message);
            }

            string[] StationsList = new string[] { SiteCode };
            if (string.IsNullOrEmpty(variable))
                variable = "NWIS:00060";
            VariableParam vp;
            try
            {
                vp = new VariableParam(variable);

            }
            catch (WaterOneFlowException we)
            {
                waterLog.WriteEntry("Bad Variable Request '" + variable + "'", EventLogEntryType.Information);
                throw;
            }
            catch (Exception e)
            {
                waterLog.WriteEntry("uncaught exception duing Variable Request '" + variable + "'", EventLogEntryType.Error);
                throw new WaterOneFlowException("Sorry. Your variable parameter caused an exception that we failed to catch:" + e.Message);

            }

            result = CuahsiBuilder.CreateTimeSeriesObject();
            // build query criteria
            result.queryInfo.criteria.locationParam = siteNumber;
            result.queryInfo.criteria.variableParam = variable;

            // result.queryInfo.criteria.timeParam = CuahsiBuilder.createQueryInfoTimeCriteria(startDate, endDate);

            // look for siteInfoType in cache, and use if it is there
            /* SiteInfoType sit = (SiteInfoType)appCache[sitCache + SiteCode];
             if (sit == null)
             {
                 // just use the values for now.
                 ((SiteInfoType)result.timeSeries.sourceInfo).siteCode[0].Value = SiteCode;
                 ((SiteInfoType)result.timeSeries.sourceInfo).siteCode[0].network = "NWIS";
                

             }
             else
             {
                 // in the cache, use it
                 result.timeSeries.sourceInfo = sit;
             }
             * */

            result.timeSeries.sourceInfo = getSiteInfoType(SiteCode);

            // result.timeSeries.variable = vp.getVariableSchemaType();
            //result.timeSeries.variable = NwisVariableCatalog.getVariable(vp.Code, variableDataSet);
            result.timeSeries.variable = ODvariables.getVariable(vp.Code, variableDataSet)[0];
            // TODO Add variable UNITS

            try
            {
                // refactor too much abstraction
                //CreateDailyValuesTimeSeriesObject(result, DailyValues(startDate, endDate, StationsList));
                CreateTimeSeriesObject(result, DailyValues(startDate, endDate, new string[] { vp.Code }, StationsList));
            }
            catch (Exception e)
            {
                string ex = CreateMessage(e);
                waterLog.WriteEntry(ex, EventLogEntryType.Error);
                throw new WaterOneFlowException("An External resource failed.", e);
            }
            return result;
        }

        public TimeSeriesResponseType GetWaterQualityValues(string siteNumber, string variable, Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate)
        {
            TimeSeriesResponseType result = null;
            string Network;
            string SiteCode;
            //WSUtils.ParseSiteId(siteId, out Network, out SiteCode);
            try
            {
                locationParam sq = new locationParam(siteNumber);
                Network = sq.Network;
                SiteCode = sq.SiteCode;
                if (sq.isGeometry)
                {
                    throw new WaterOneFlowException("Location by Geometry not accepted: " + siteNumber);
                }
            }
            catch (WaterOneFlowException)
            {
                waterLog.WriteEntry("Bad SiteID:" + siteNumber, EventLogEntryType.Information);
                throw;
            }
            catch (Exception e)
            {
                waterLog.WriteEntry("Uncaught exception:" + e.Message, EventLogEntryType.Error);
                throw new WaterOneFlowException("Sorry. Your submitted site ID for this getSiteInfo request caused an problem that we failed to catch programmatically: " + e.Message);
            }
            VariableParam vp;
            try
            {
                vp = new VariableParam(variable);

            }
            catch (WaterOneFlowException)
            {
                waterLog.WriteEntry("Bad Variable Request '" + variable + "'", EventLogEntryType.Information);
                throw;
            }
            catch (Exception e)
            {
                waterLog.WriteEntry("uncaught exception duing Variable Request '" + variable + "'", EventLogEntryType.Error);
                throw new WaterOneFlowException("Sorry. Your variable parameter caused an exception that we failed to catch:" + e.Message);

            }


            string[] StationsList = new string[] { SiteCode };
            result = CuahsiBuilder.CreateTimeSeriesObject();

            // passed in parameters
            result.queryInfo.criteria.locationParam = siteNumber;
            result.queryInfo.criteria.variableParam = variable;


            //    result.queryInfo.criteria.timeParam =CuahsiBuilder.createQueryInfoTimeCriteria(startDate, endDate);

            // end passed in parameters

            // look for siteInfoType in cache, and use if it is there
            /*
             * SiteInfoType sit = (SiteInfoType)appCache[sitCache + SiteCode];
            if (sit == null)
            {
                // just use the values for now.
                ((SiteInfoType)result.timeSeries.sourceInfo).siteCode[0].Value = SiteCode;
                ((SiteInfoType)result.timeSeries.sourceInfo).siteCode[0].network = "NWIS";

            }
            else
            {
                // in the cache, use it
                result.timeSeries.sourceInfo = sit;
            }
             */
            result.timeSeries.sourceInfo = getSiteInfoType(SiteCode);

            // vaiable info
            // result.timeSeries.variable = vp.getVariableSchemaType();
            //result.timeSeries.variable = NwisVariableCatalog.getVariable(vp.Code, variableDataSet);
            result.timeSeries.variable = ODvariables.getVariable(vp.Code, variableDataSet)[0];
            try
            {
                //string[] splitVariables = variable.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                // refactor too much abstraction
                // CreateWaterQualityTimeSeriesObject(result, WaterQuality(vp.Code, StationsList));
                CreateWQTimeSeriesObject(result, InstantaneousData(startDate, endDate, new string[] { vp.Code }, StationsList));
            }
            catch (Exception e)
            {
                string ex = CreateMessage(e);
                waterLog.WriteEntry(ex, EventLogEntryType.Error);
                throw new WaterOneFlowException("An External resource failed.", e);
            }
            return result;
        }

        public TimeSeriesResponseType GetUnitValues(string siteNumber, string variable, Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate)
        {
            // put the date check up front.
            // a start date can be older than 31 days, as long as the endDate is not older than 31 days.

            if (endDate.HasValue && endDate.Value.DateTime < DateTime.Today.AddDays(-31))
            {
                throw new WaterOneFlowException("No Data. EndDate must be less than that 31 days from present.");
            }

            TimeSeriesResponseType result = null;
            string Network;
            string SiteCode;
            //WSUtils.ParseSiteId(siteId, out Network, out SiteCode);
            try
            {
                locationParam sq = new locationParam(siteNumber);
                Network = sq.Network;
                SiteCode = sq.SiteCode;
                if (sq.isGeometry)
                {
                    throw new WaterOneFlowException("Location by Geometry not accepted: " + siteNumber);
                }
            }
            catch (WaterOneFlowException we)
            {
                waterLog.WriteEntry("Bad SiteID:" + siteNumber, EventLogEntryType.Information);
                throw;
            }
            catch (Exception e)
            {
                waterLog.WriteEntry("Uncaught exception:" + e.Message, EventLogEntryType.Error);
                throw new WaterOneFlowException("Sorry. Your submitted site ID for this getSiteInfo request caused an problem that we failed to catch programmatically: " + e.Message);
            }

            // string WaterQualityList = "&parameter_cd=" + variable;
            string[] StationsList = new string[] { SiteCode };

            VariableParam vp;
            try
            {
                vp = new VariableParam(variable);

            }
            catch (WaterOneFlowException we)
            {
                waterLog.WriteEntry("Bad Variable Request '" + variable + "'", EventLogEntryType.Information);
                throw;
            }
            catch (Exception e)
            {
                waterLog.WriteEntry("uncaught exception duing Variable Request '" + variable + "'", EventLogEntryType.Error);
                throw new WaterOneFlowException("Sorry. Your variable parameter caused an exception that we failed to catch:" + e.Message);

            }

            result = CuahsiBuilder.CreateTimeSeriesObject();

            // all data are provisional
            List<note> notes = new List<note>();
            note urlNote = new note();
            urlNote.title = "USGS Data Provisional";
            urlNote.href = "http://waterdata.usgs.gov/nwis/help/?provisional";
            urlNote.Value = "All data are provisional, and subject to revision";
            notes.Add(urlNote);
            result.queryInfo.note = notes.ToArray();

            result.queryInfo.criteria.locationParam = siteNumber;
            result.queryInfo.criteria.variableParam = variable;


            // result.queryInfo.criteria.timeParam  = CuahsiBuilder.createQueryInfoTimeCriteria(startDate, endDate);

            // look for siteInfoType in cache, and use if it is there
            /* SiteInfoType sit = (SiteInfoType)appCache[sitCache + SiteCode];
             if (sit == null)
             {
                 // just use the values for now.
                 ((SiteInfoType)result.timeSeries.sourceInfo).siteCode[0].Value = SiteCode;
                 ((SiteInfoType)result.timeSeries.sourceInfo).siteCode[0].network = "NWIS";

             }
             else
             {
                 // in the cache, use it
                 result.timeSeries.sourceInfo = sit;
             }
             * */
            result.timeSeries.sourceInfo = getSiteInfoType(SiteCode);


            // vaiable info
            // result.timeSeries.variable = vp.getVariableSchemaType();
            //result.timeSeries.variable = NwisVariableCatalog.getVariable(vp.Code, variableDataSet);
            result.timeSeries.variable = ODvariables.getVariable(vp.Code, variableDataSet)[0];

            try
            {
                // refactor too much abstraction
                //CreateRealTimeSeriesObject(result, RealTime(StationsList));
                CreateTimeSeriesObject(result, UnitValues(startDate, endDate, new string[] { vp.Code }, StationsList));
            }
            catch (Exception e)
            {
                string ex = CreateMessage(e);
                waterLog.WriteEntry(ex, EventLogEntryType.Error);
                throw new WaterOneFlowException("An External resource failed.", e);
            }
            return result;
        }

        public TimeSeriesResponseType GetGroundWaterValues(string siteNumber, string variable, Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate)
        {
            TimeSeriesResponseType result = null;
            string Network;
            string SiteCode;
            //WSUtils.ParseSiteId(siteId, out Network, out SiteCode);
            try
            {
                locationParam sq = new locationParam(siteNumber);
                Network = sq.Network;
                SiteCode = sq.SiteCode;
                if (sq.isGeometry)
                {
                    throw new WaterOneFlowException("Location by Geometry not accepted: " + siteNumber);
                }
            }
            catch (WaterOneFlowException we)
            {
                waterLog.WriteEntry("Bad SiteID:" + siteNumber, EventLogEntryType.Information);
                throw we;
            }
            catch (Exception e)
            {
                waterLog.WriteEntry("Uncaught exception:" + e.Message, EventLogEntryType.Error);
                throw new WaterOneFlowException("Sorry. Your submitted site ID for this getSiteInfo request caused an problem that we failed to catch programmatically: " + e.Message);
            }
            VariableParam vp;
            if (!String.IsNullOrEmpty(variable))
            {
                try
                {
                    vp = new VariableParam(variable);

                }
                catch (WaterOneFlowException we)
                {
                    waterLog.WriteEntry("Bad Variable Request '" + variable + "'", EventLogEntryType.Information);
                    throw we;
                }
                catch (Exception e)
                {
                    waterLog.WriteEntry("uncaught exception duing Variable Request '" + variable + "'", EventLogEntryType.Error);
                    throw new WaterOneFlowException("Sorry. Your variable parameter caused an exception that we failed to catch:" + e.Message);

                }
            }
            else
            {
                vp = new VariableParam("NWIS:72019");


            }

            string[] StationsList = new string[] { SiteCode };
            result = CuahsiBuilder.CreateTimeSeriesObject();
            // build query criteria
            result.queryInfo.criteria.locationParam = siteNumber;
            result.queryInfo.criteria.variableParam = variable;


            //result.queryInfo.criteria.timeParam = CuahsiBuilder.createQueryInfoTimeCriteria(startDate, endDate);

            // look for siteInfoType in cache, and use if it is there
            /* SiteInfoType sit = (SiteInfoType)appCache[sitCache + SiteCode];
             if (sit == null)
             {
                 // just use the values for now.
                 ((SiteInfoType)result.timeSeries.sourceInfo).siteCode[0].Value = SiteCode;
                 ((SiteInfoType)result.timeSeries.sourceInfo).siteCode[0].network = "NWIS";

             }
             else
             {
                 // in the cache, use it
                 result.timeSeries.sourceInfo = sit;
             }
             * */
            result.timeSeries.sourceInfo = getSiteInfoType(SiteCode);

            if (string.IsNullOrEmpty(variable))
            {
                // vaiable info
                //result.timeSeries.variable = vp.getVariableSchemaType();
                //result.timeSeries.variable.variableDescription = "Water Level measured in feet below land surface";
                //result.timeSeries.variable.units.Value = "feet";
                //result.timeSeries.variable.units.unitsAbbreviation = "ft";
                //result.timeSeries.variable.units.unitsType = UnitsTypeEnum.Length;
                //result.timeSeries.variable.units.unitsTypeSpecified = true;
                // result.timeSeries.variable = vp.getVariableSchemaType();
                //result.timeSeries.variable = NwisVariableCatalog.getVariable("72019", variableDataSet);
                result.timeSeries.variable = ODvariables.getVariable("72019", variableDataSet)[0];
            }
            else
            {
                // vaiable info
                // result.timeSeries.variable = vp.getVariableSchemaType();
                //result.timeSeries.variable = NwisVariableCatalog.getVariable(vp.Code, variableDataSet);
                result.timeSeries.variable = ODvariables.getVariable(vp.Code, variableDataSet)[0];
            }
            try
            {
                // refactor too much abstraction
                //CreateGroundWaterTimeSeriesObject(result, GroundWater(startDate, endDate, StationsList));
                string gwUrl = GroundWater(startDate, endDate, StationsList);
                CreateGWTimeSeriesObject(result, gwUrl);
                result.queryInfo.queryURL = gwUrl;
            }
            catch (Exception e)
            {
                string ex = CreateMessage(e);
                waterLog.WriteEntry(ex, EventLogEntryType.Error);
                throw new WaterOneFlowException("An External resource failed.", e);
            }
            return result;
        }

        public string GetVariableForStation(string siteNumber, string startDate, string endDate)
        {
            string sURL;
            StringReader stringReader;
            string line;
            StringBuilder Result = new StringBuilder();
            string[] values;
            bool dailystreamflow = true;
            string FirstDate = string.Empty;
            int Count = 0;
            try
            {
                if (dailystreamflow == true)
                {
                    sURL = "http://waterdata.usgs.gov/nwis/inventory?search_site_no=" + siteNumber + "&search_site_no_match_type=exact&sort_key=site_no&group_key=NONE&format=sitefile_output&sitefile_output_format=xml&column_name=discharge_begin_date&column_name=discharge_end_date&column_name=discharge_count_nu&list_of_search_criteria=search_site_no";
                    XmlTextReader xmlreader = new XmlTextReader(sURL);
                    int i = 0;
                    while (xmlreader.Read())
                    {
                        if (i == 7)
                        {
                            FirstDate = xmlreader.Value;
                        }
                        else if (i == 15)
                        {
                            Count = Convert.ToInt32(xmlreader.Value);
                        }
                        i = i + 1;
                    }
                }
                sURL = "http://nwis.waterdata.usgs.gov/nwis/qwdata?search_site_no=" + siteNumber + "&search_site_no_match_type=exact&sort_key=site_no&group_key=NONE&sitefile_output_format=html_table&column_name=agency_cd&begin_date=" + ParseDate(startDate) + "&end_date=" + ParseDate(endDate) + "&inventory_output=0&format=rdb_inventory&rdb_inventory_output=value&date_format=YYYY-MM-DD&rdb_compression=file&qw_sample_wide=0&list_of_search_criteria=search_site_no";
                stringReader = new StringReader(GetHTTPFile(sURL, 5));
                line = stringReader.ReadLine();
                Result.Append("<usgs_nwis>" + vbNewLine + " <site>" + vbNewLine + " <site_no> " + siteNumber + "</site_no>");
                if (Count > 0 & dailystreamflow == true)
                {
                    Result.Append(vbNewLine + " <record parameter_cd = 'Daily Streamflow'>" + vbNewLine + " <count_nu>" + Count + "</count_nu>" + vbNewLine + " <begin_date>" + FirstDate + "</begin_date>" + vbNewLine + " <end_date>" + endDate + "</end_date>" + vbNewLine + " </record>");
                }
                if (!(line == null))
                {
                    while (line.Substring(0, 1) == "#")
                    {
                        line = stringReader.ReadLine();
                    }
                    line = stringReader.ReadLine();
                    line = stringReader.ReadLine();
                    if (line == null)
                    {
                        Result.Append(vbNewLine + " <record data = 'none'></record>");
                    }
                    while (!(line == null))
                    {
                        values = line.Split();
                        Result.Append(vbNewLine + " <record parameter_cd = '" + values[2] + "'>" + vbNewLine + " <count_nu>" + values[3] + "</count_nu>" + vbNewLine + " <begin_date>" + values[4] + "</begin_date>" + vbNewLine + " <end_date>" + values[5] + "</end_date>" + vbNewLine + " </record>");
                        line = stringReader.ReadLine();
                    }
                }
                else
                {
                    Result.Append(vbNewLine + " <record data = 'none'></record>");
                }
                Result.Append(vbNewLine + " </site>" + vbNewLine + "</usgs_nwis>");
            }
            catch (Exception e)
            {
                string ex = CreateMessage(e);
                waterLog.WriteEntry(ex, EventLogEntryType.Error);
                throw new WaterOneFlowException("An External resource failed.", e);
            }
            return Result.ToString();
        }
        #endregion

        #region Private Methods


        #region SiteInventory Methods

        private static Uri SiteInventoryURL(String siteCode)
        {
            UriBuilder siURL;

            string sURL = "http://waterdata.usgs.gov/nwis/inventory?" +
                        usgsStationQP(new string[] { siteCode }) +
                            "&format=sitefile_output&sitefile_output_format=xml" +
                            "&column_name=agency_cd" + "&column_name=site_no&column_name=station_nm" +
                            "&column_name=lat_va&column_name=long_va&column_name=dec_lat_va&column_name=dec_long_va&column_name=coord_meth_cd&column_name=coord_acy_cd&column_name=coord_datum_cd&column_name=dec_coord_datum_cd" +
                            "&column_name=district_cd&column_name=state_cd&column_name=county_cd&column_name=country_cd&column_name=land_net_ds&column_name=map_nm&column_name=map_scale_fc" +
                            "&column_name=alt_va&column_name=alt_meth_cd&column_name=alt_acy_va&column_name=alt_datum_cd" +
                            "&column_name=huc_cd&column_name=basin_cd&column_name=topo_cd" +
                            "&column_name=station_type_cd&column_name=agency_use_cd&column_name=data_types_cd&column_name=instruments_cd&column_name=construction_dt&column_name=inventory_dt" +
                            "&column_name=drain_area_va&column_name=contrib_drain_area_va" +
                            "&column_name=tz_cd&column_name=local_time_fg" +
                            "&column_name=reliability_cd" +
                            "&column_name=gw_file_cd&column_name=gw_type_cd&column_name=nat_aqfr_cd&column_name=aqfr_cd&column_name=aqfr_type_cd&column_name=well_depth_va&column_name=hole_depth_va&column_name=depth_src_cd" +
                            "&column_name=project_no" +
                            "&column_name=rt_bol" +
                            "&column_name=discharge_begin_date&column_name=discharge_end_date&column_name=discharge_count_nu" +
                            "&column_name=peak_begin_date&column_name=peak_end_date&column_name=peak_count_nu" +
                            "&column_name=qw_begin_date&column_name=qw_end_date&column_name=qw_count_nu" +
                            "&column_name=gw_begin_date&column_name=gw_end_date&column_name=gw_count_nu";
            siURL = new UriBuilder(sURL);
            return siURL.Uri;
        }

        private XmlDocument GetSiteInventoryXML(string SiteCode)
        {
            Uri sURL = SiteInventoryURL(SiteCode);

            XmlDocument XMLResponse;
            XMLResponse = (XmlDocument)appCache[SiteXMLCache + SiteCode];
            if (XMLResponse == null)
            {
                XMLResponse = new XmlDocument();
                try
                {

                    XMLResponse.LoadXml(GetHTTPFile(sURL.ToString(), 30));
                    appCache.Insert(SiteXMLCache + SiteCode, XMLResponse);


                }
                catch (Exception e)
                {
                    string ex = CreateMessage(e);
                    waterLog.WriteEntry(ex, EventLogEntryType.Error);
                    throw new WaterOneFlowException("Failed to retrieve the siteInventory for " + SiteCode + "' attemptedURL:'" + sURL + "'", e);
                }
            }
            return XMLResponse;
        }

        private SiteInfoType createSiteInfoType(XmlDocument siteInventoryXML)
        {

            SiteInfoType sit = CuahsiBuilder.CreateASiteInfoTypeWithLatLongPoint();
            sit.siteCode[0].Value = siteInventoryXML.GetElementsByTagName("site_no")[0].InnerText;
            sit.siteName = siteInventoryXML.GetElementsByTagName("station_nm")[0].InnerText;
            ((LatLonPointType)sit.geoLocation.geogLocation).latitude = Convert.ToDouble(siteInventoryXML.GetElementsByTagName("dec_lat_va")[0].InnerText);
            ((LatLonPointType)sit.geoLocation.geogLocation).longitude = Convert.ToDouble(siteInventoryXML.GetElementsByTagName("dec_long_va")[0].InnerText);

            return sit;
        }

        private SiteInfoType getSiteInfoType(String siteCode)
        {
            // look in memory
            SiteInfoType sit = (SiteInfoType)appCache[sitCache + siteCode];
            if (sit != null) return sit;

            //ok, try the database
            int networkID = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["NwisNetworkID"]);
            SiteInfoType[] sites = ODSiteInfo.GetSitesByNetworkIDSiteCodes(networkID, new string[] { siteCode });
            if (sites != null && sites.Length == 1) return sites[0]; // had better be only one

            // not found, get the site inventory
            Uri siteInventoryURL = SiteInventoryURL(siteCode);
            XmlDocument siteInventoryXML;
            siteInventoryXML = GetSiteInventoryXML(siteCode); // catches the throws errors. Nothing needed.

            sit = createSiteInfoType(siteInventoryXML);
            sit.note = new note[1];
            sit.note[0] = new note();
            sit.note[0].type = Constants.sourceUrl;
            sit.note[0].Value = siteInventoryURL.ToString();

            return sit;

        }

        /// <summary>
        /// createSiteInfoResponse populates a SiteInfoResponseType.
        /// It is used the webmethod getSiteInfo.
        /// designed for multiple site codes
        /// This method will be slow if the information has never been cached.
        /// </summary>
        /// <param name="siteCodes"></param>
        private SiteInfoResponseType createSiteInfoResponse(string[] siteCodes, int? sourceId)
        {
            /* for each site code, add a siteInfo type with a period of record
            // for each site
             *     createSitInfoType
             *     add to response
             *     createPeriodOfRecord
             *     add to response
             * return response
             * */
            SiteInfoResponseType response = CuahsiBuilder.CreateASetOfSiteResponses(siteCodes.Length, 1);
            for (int i = 0; i < siteCodes.Length; i++)
            {
                response.site[i].siteInfo = getSiteInfoType(siteCodes[i]);
                String aSiteID = response.site[i].siteInfo.siteCode[0].siteID;
                Nullable<int> siteIDint = null;
                try
                {
                    siteIDint = Convert.ToInt32(aSiteID);
                    response.site[i].seriesCatalog = createPeriodOfRecord(siteCodes[i], siteIDint, sourceId);
                }
                catch
                {
                    response.site[i].seriesCatalog = createPeriodOfRecord(siteCodes[i], null, sourceId);
                }
            }

            return response;
        }

        #endregion

        #region PeriodOfRecord
        /// <summary>
        /// The siteInformationXML document includes infomration about the sections.
        /// elements:
        /// 
        /// if the count of each one of these is > 0, the we should attempt to add  
        /// period of record
        /// </summary>
        /// <param name="SiteCode"></param>
        /// 
        /// <returns></returns>
        private seriesCatalogType[] createPeriodOfRecord(String SiteCode, Nullable<int> siteID, int? sourceId)
        {
            // need the siteID for the DB sites, and the siteCode for retrival from the service

            // do not trust that the siteInventoryXML is still in the cache
            XmlDocument siteInventoryXML = GetSiteInventoryXML(SiteCode);

            if (siteID.HasValue)
            {
                seriesCatalogDataSet seriesDataset = ODSeriesCatalog.GetSeriesCatalogDataSet(siteID.Value);
                if (seriesDataset.SeriesCatalog.Rows.Count > 0)
                {
                    seriesCatalogType[] seriesFromDB =
                        ODSeriesCatalog.dataSet2SeriesCatalog(seriesDataset, variableDataSet, sourceId);
                    if (seriesFromDB  != null && seriesFromDB.Length > 0)
                    {
                        return seriesFromDB;
                    }
                }
            }

            List<seriesCatalogType> porList = new List<seriesCatalogType>();
            // read siteXML, add appropriate period of record blocks

            XmlNodeList byTag;
            DateTime start;
            DateTime end;
            int count;
            Boolean isRealTime;

            // There could be multiple "daily Values.
            // if a station has both discharge and groundwater

            // TODO: FIX CHECK FOR EMPTY ELEMENTS, IGNORE

            // Discahrge Values
            if (!sourceId.HasValue || sourceId.Value == 1)
            {
                count = Convert.ToInt32(
                     siteInventoryXML.GetElementsByTagName("discharge_count_nu")[0].InnerText
                     );

                if (count > 0)
                {

                    start = Convert.ToDateTime(
                        siteInventoryXML.GetElementsByTagName("discharge_begin_date")[0].InnerText
                        );

                    end = Convert.ToDateTime(
                        siteInventoryXML.GetElementsByTagName("discharge_end_date")[0].InnerText
                        );

                    porList.Add(createNwisPeriodOfRecord(SiteCode,
                                                         start, end,
                                                         count, true, usgsApplications.dv)
                        );
                }
            }
            
            // Groundwater Values
            if (!sourceId.HasValue || sourceId.Value == 4)
            {
                count = Convert.ToInt32(
                    siteInventoryXML.GetElementsByTagName("gw_count_nu")[0].InnerText
                    );

                if (count > 0)
                {

                    start = Convert.ToDateTime(
                        siteInventoryXML.GetElementsByTagName("gw_begin_date")[0].InnerText
                        );

                    end = Convert.ToDateTime(
                        siteInventoryXML.GetElementsByTagName("gw_end_date")[0].InnerText
                        );

                    porList.Add(createNwisPeriodOfRecord(SiteCode,
                                                         start, end,
                                                         count, true, usgsApplications.dv)
                        );
                }

        }

            // UNIT VALUES or REAL TIME
        if (!sourceId.HasValue || sourceId.Value == 3)
        {
                string rt_bol = siteInventoryXML.GetElementsByTagName("rt_bol")[0].InnerText;
                if (rt_bol.Equals("1"))
                {
                    isRealTime = true;
                }
                else { isRealTime = false; }

                if (isRealTime)
                {
                    DateTime endDate = DateTime.Now;
                    DateTime startDate = endDate.AddDays(-31);
                    count = 31 * 24 * 4; // 31 days, 24 hours, 4 times a hour
                    porList.Add(createNwisPeriodOfRecord(SiteCode, startDate, endDate, count, true, usgsApplications.uv));
                }
            }
            

            // INSTANTANEOUS DATA
            if (!sourceId.HasValue || sourceId.Value == 2)
            {
                count = Convert.ToInt32(siteInventoryXML.GetElementsByTagName("qw_count_nu")[0].InnerText);
                //count = siteInventoryXML.GetElementsByTagName("qw_count_nu"); 
                if (count > 0)
                {
                    start = Convert.ToDateTime(
                        siteInventoryXML.GetElementsByTagName("qw_begin_date")[0].InnerText
                        );
                    end = Convert.ToDateTime(
                        siteInventoryXML.GetElementsByTagName("qw_end_date")[0].InnerText
                        );

                    porList.Add(createIIDPeriodOfRecord(SiteCode,
                                                        start, end)
                        );
                }
            }
            

            return porList.ToArray();
        }




        /*
         * logic for period of record
         * * user passes in siteID, start and end time
         * * retrieve record via http. use a minimal time period for most things
         * * figure out number of variables
         * * if we cannot figure out the start and end date, use the passed in one
         * * create empty VariablePeriodOfRecord block
         * * populate por
         * * return por
         * */

        private seriesCatalogType createIIDPeriodOfRecord(string SiteCode, DateTime startDate, DateTime endDate)
        {
            if (appCache[iidPORCache + SiteCode] != null)
            {
                return (seriesCatalogType)appCache[iidPORCache + SiteCode];
            }
            // nwis.waterdata is required part of url
            //http://nwis.waterdata.usgs.gov/nwis/qwdata?site_no=07227500&format=rdb_inventory
            // get back an RDB table
            /*
agency_cd	site_no	parameter_cd	count_nu	begin_dt	end_dt	parameter_nm
5s	15s	5s	5s	10d	10d	30s
USGS	07227500	00008	5	1974-05-01	1975-09-17	Sample accounting number
                */
            Uri iidUrl = iidPeriodOfRecordURL(SiteCode);
            string response;
            try
            {
                response = GetHTTPFile(iidUrl.ToString(), 10);
            }
            catch (Exception e)
            { // if we get an error here, just ignore it rather than break the request
                // aka send back something
                // TODO log error
                return null;
            }
            DataTable aTable = NWISDelimitedTextParser.ParseFileIntoDT(response);

            int siteCol;
            int variableCol;
            int countCol;
            int beginDateCol;
            int endDateCol;
            int varNameCol;
            // there are many qa columns. what do we want to do about them
            try
            {
                siteCol = getVarColumn(aTable, "site_no", null);
                variableCol = getVarQualifiersColumn(aTable, "parameter_cd", null);
                countCol = getVarColumn(aTable, "count_nu", null);
                beginDateCol = getVarColumn(aTable, "begin_dt", null);
                endDateCol = getVarColumn(aTable, "end_dt", null);
                varNameCol = getVarColumn(aTable, "parameter_nm", null);
            }
            catch (WaterOneFlowException we)
            {
                return null;
                //throw new WaterOneFlowException("URL: '" + aURL, we);
            }

            seriesCatalogType por =
                CuahsiBuilder.CreateSeriesCatalog(aTable.Rows.Count,
                NwisWsDescriptions.IID_DESC,
               NWISBaseUrl.LocalServerBaseURL(appContext, true).ToString() + NWISBaseUrl.nwisIID
                );
            por.note = new note[1];
            por.note[0] = new note();
            por.note[0].type = Constants.sourceUrl;
            por.note[0].Value = iidUrl.ToString();

            //foreach (DataRow aRow in aTable.Rows)
            for (int rowNum = 0; rowNum < aTable.Rows.Count; rowNum++)
            {
                /* **** NOTE ****
                 * IF YOU BREAK SOMETHING IN HERE
                 * YOU WILL GET BAD PERIOD OF RECORD ELEMENTS
                 * verify after changing
                 * */

                try
                {
                    seriesCatalogTypeSeries porVar = por.series[rowNum];
                    DataRow aRow = aTable.Rows[rowNum];

                    //porVar.variable.variableCode[0].Value = aRow[variableCol].ToString();
                    //porVar.variable.variableDescription = aRow[varNameCol].ToString();

                    try
                    {
                        //porVar.variable = NwisVariableCatalog.getVariable(aRow[variableCol].ToString(), variableDataSet);
                        porVar.variable = ODvariables.getVariable(aRow[variableCol].ToString(), variableDataSet)[0];
                        porVar.variable.note = new note[1];
                        porVar.variable.note[0] = new note();
                        porVar.variable.note[0].Value = aRow[varNameCol].ToString();
                        porVar.variable.note[0].type = "nwis:ParameterDescription";

                    }
                    catch (Exception)
                    {
                        porVar.variable.variableCode[0].Value = aRow[variableCol].ToString();
                        porVar.variable.note = new note[2];
                        porVar.variable.note[0] = new note();
                        porVar.variable.note[0].Value = "(Variable Uknown to CUAHSI)";
                        porVar.variable.note[0].type = "error";
                        porVar.variable.note[1] = new note();
                        porVar.variable.note[1].Value = aRow[varNameCol].ToString();
                        porVar.variable.note[1].type = "nwis:ParameterDescription";

                    }


                    porVar.valueCount.Value = Convert.ToInt32(aRow[countCol]);
                    if (Convert.ToInt32(aRow[countCol]) == 1)
                    {  // one event
                        TimeSingleType tm = new TimeSingleType();
                        tm.timeSingle = Convert.ToDateTime(aRow[beginDateCol].ToString());
                        porVar.variableTimeInterval = tm;
                    }
                    else
                    {
                        TimeIntervalType tm = new TimeIntervalType();
                        tm.beginDateTime = Convert.ToDateTime(aRow[beginDateCol].ToString());
                        tm.endDateTime = Convert.ToDateTime(aRow[endDateCol].ToString());
                        porVar.variableTimeInterval = tm;
                    }

                }
                catch (Exception e)
                {
                }


            }

            // add to cache
            appCache.Insert(iidPORCache + SiteCode, por);

            return por;


        }

        private Uri iidPeriodOfRecordURL(string siteCode)
        {
            StringBuilder usgsUrl = new StringBuilder("http://");
            usgsUrl.Append("nwis.waterdata.usgs.gov");  // may be a DNS routine one day
            usgsUrl.Append("/nwis/qwdata?");
            usgsUrl.Append("format=rdb_inventory");
            usgsUrl.Append("&site_no=");
            usgsUrl.Append(siteCode);
            return new Uri(usgsUrl.ToString());
        }

        private seriesCatalogType createNwisPeriodOfRecord(string siteCode, DateTime? startDate, DateTime? endDate, int observationCount, bool observationCountEstimated, usgsApplications svc)
        {
            string wsPath;
            switch (svc)
            {
                case usgsApplications.dv:
                    wsPath = NWISBaseUrl.nwisDailyValues;
                    if (appCache[dvPORCache + siteCode] != null)
                    {
                        return (seriesCatalogType)appCache[dvPORCache + siteCode];
                    }
                    break;
                case usgsApplications.uv:
                    wsPath = NWISBaseUrl.nwisUnitValues;
                    if (appCache[uvPORCache + siteCode] != null)
                    {
                        return (seriesCatalogType)appCache[uvPORCache + siteCode];
                    }
                    break;
                default:
                    throw new WaterOneFlowException("Implement a new cache for new service");
            }
            //daily values
            // reffered_module=sw is needed
            // use date after today
            // http://waterdata.usgs.gov/nwis/dv?referred_module=sw&site_no=10263500&format=rdb&date_format=YYYY-MM-DD&begin_date=2006-12-31
            // unit values
            //http://waterdata.usgs.gov/nwis/uv?referred_module=sw&site_no=10263500&format=rdb&date_format=YYYY-MM-DD&begin_date=2006-12-31
            /*
     agency_cd	site_no	datetime	03_00065	03_00065_cd	02_00060	02_00060_cd
    5s	15s	16s	14s	14s	14s	14s
    USGS	10263500	2006-12-31 00:00				
          */
            Uri nwisUrl = nwisPeriodOfRecordURL(siteCode, svc);
            string response;
            try
            {
                response = GetHTTPFile(nwisUrl.ToString(), 10);
            }
            catch (Exception e)
            { // if we get an error here, just ignore it rather than break the request
                // aka send back something
                // TODO log error
                return null;
            }
            DataTable aTable = NWISDelimitedTextParser.ParseFileIntoDT(response);

            int agencyCol;
            int siteCol;
            int datetimeCol;

            // there are many qa columns. what do we want to do about them
            try
            {
                siteCol = getVarColumn(aTable, "site_no", null);
                agencyCol = getVarQualifiersColumn(aTable, "agency_cd", null);
                datetimeCol = getVarColumn(aTable, "datetime", null);
                //TODO do some checks and send an error if one of these is not found
            }
            catch (WaterOneFlowException we)
            {
                return null;
                //throw new WaterOneFlowException("URL: '" + aURL, we);
            }

            // list to hold the codes
            Hashtable codes = new Hashtable();
            // column names are the second value in ##_######_####
            foreach (DataColumn aCol in aTable.Columns)
            {
                if (aCol.Ordinal < 3) continue;

                string[] list = aCol.ColumnName.Split(new string[] { "_" }, StringSplitOptions.None);
                if (list.Length > 2)
                {
                    try
                    {
                        codes.Add(list[1], aCol.Ordinal);
                    }
                    catch (Exception e)
                    { }
                }

            }

            seriesCatalogType por = null;
            switch (svc)
            {
                case usgsApplications.dv:
                    por = CuahsiBuilder.CreateSeriesCatalog(codes.Count,
                         NwisWsDescriptions.DV_DESC,
                         NWISBaseUrl.LocalServerBaseURL(appContext, true).ToString() + wsPath
                         );
                    break;
                case usgsApplications.uv:
                    por = CuahsiBuilder.CreateSeriesCatalog(codes.Count,
                            NwisWsDescriptions.UV_DESC,
                            NWISBaseUrl.LocalServerBaseURL(appContext, true).ToString() + wsPath
                            );
                    break;

            }

            por.note = new note[1];
            por.note[0] = new note();
            por.note[0].type = Constants.sourceUrl;
            por.note[0].Value = nwisUrl.ToString();

            int i = 0;
            foreach (String key in codes.Keys)
            {
                seriesCatalogTypeSeries porVar = por.series[i];

                /* **** NOTE ****
                 * IF YOU BREAK SOMETHING IN HERE
                 * YOU WILL GET BAD PERIOD OF RECORD ELEMENTS
                 * verify after changing
                 * */

                try
                {
                    // porVar.variable = NwisVariableCatalog.getVariable(key, variableDataSet);
                    porVar.variable = ODvariables.getVariable(key, variableDataSet)[0];
                }
                catch (Exception)
                {
                    porVar.variable.variableCode[0].Value = key;
                    porVar.variable.note = new note[1];
                    porVar.variable.note[0].Value = "(Variable Uknown to CUAHSI)";
                }
                porVar.valueCount.Value = observationCount;  // needs to be passed in for now       
                if (observationCountEstimated)
                {
                    porVar.valueCount.countIsEstimated = true;
                    porVar.valueCount.countIsEstimatedSpecified = true;
                }


                switch (svc)
                {
                    case usgsApplications.dv:
                        TimeIntervalType tm = new TimeIntervalType();
                        tm.beginDateTime = startDate.Value;
                        tm.endDateTime = endDate.Value;
                        porVar.variableTimeInterval = tm;
                        break;
                    case usgsApplications.uv:
                        TimePeriodRealTimeType rt = new TimePeriodRealTimeType();
                        rt.realTimeDataPeriod = "P31D"; // 31 day Period
                        porVar.variableTimeInterval = rt;
                        rt.beginDateTime = startDate.Value;
                        rt.endDateTime = endDate.Value;
                        break;

                }
                i++;
            }
            // add to cache
            switch (svc)
            {
                case usgsApplications.dv:
                    appCache.Insert(dvPORCache + siteCode, por);
                    break;
                case usgsApplications.uv:
                    appCache.Insert(uvPORCache + siteCode, por);
                    break;
                default:
                    throw new WaterOneFlowException("Implement a new addd to cache for new service");
            }

            return por;
        }

        private Uri nwisPeriodOfRecordURL(string siteCode, usgsApplications svc)
        {
            //daily values
            // reffered_module=sw is needed
            // use date after today
            // http://waterdata.usgs.gov/nwis/dv?referred_module=sw&site_no=10263500&format=rdb&date_format=YYYY-MM-DD&begin_date=2006-12-31
            // unit values
            //http://waterdata.usgs.gov/nwis/uv?referred_module=sw&site_no=10263500&format=rdb&date_format=YYYY-MM-DD&begin_date=2006-12-31
            StringBuilder usgsUrl = new StringBuilder("http://");
            usgsUrl.Append("waterdata.usgs.gov");  // may be a DNS routine one day
            usgsUrl.Append("/nwis/");
            usgsUrl.Append(svc);
            usgsUrl.Append("?");
            usgsUrl.Append("referred_module=sw");
            usgsUrl.Append("&format=rdb");
            usgsUrl.Append("&date_format=YYYY-MM-DD");
            usgsUrl.Append("&begin_date=");
            DateTime dt = DateTime.Today.AddDays(1);
            usgsUrl.Append(dt.ToString("yyyy-MM-dd"));
            usgsUrl.Append("&site_no=");
            usgsUrl.Append(siteCode);
            return new Uri(usgsUrl.ToString());
        }

        // groundwater levels
        //http://nwis.waterdata.usgs.gov/nwis/gwlevels?site_no=410857071350401&agency_cd=USGS&format=rdb
        /*
         * 
agency_cd	site_no	lev_dt	lev_tm	lev_va	sl_lev_va	lev_status_cd
5s	15s	10d	4s	12s	12s	1s
USGS	410857071350401	1989-04-24		98	
         */

        #endregion

        // dwv removed static 
        private void CreateTimeSeriesObject(TimeSeriesResponseType result, string aURL)
        {
            // add the URL to be requested to the result
            result.queryInfo.queryURL = aURL;

            // download the iformation
            String resultFile = GetHTTPFile(aURL, 10);

            result.timeSeries.values = new TsValuesSingleVariableType();
            //result.TimeSeries.Values.valueUnits = units; // this needs to be done earlier


            DataTable aTable = NWISDelimitedTextParser.ParseFileIntoDT(resultFile);

            // dwv add code to get the code, and use that to find the correct columns
            int time = 2; // present location of time column
            String code = result.timeSeries.variable.variableCode[0].Value;
            String stat = null;
            int aValue;
            int qualifier;
            if (result.timeSeries.variable.options != null)
            {
                stat = result.timeSeries.variable.options[0].Value;
            }
            try
            {
                aValue = getVarColumn(aTable, code, stat);
                qualifier = getVarQualifiersColumn(aTable, code, stat);
            }
            catch (WaterOneFlowException we)
            {
                // need to insert the URL in the exception
                if (string.IsNullOrEmpty(stat))
                {
                    throw new WaterOneFlowException("URL: '" + aURL, we);
                    //+"' variable '"+code+"' not found at site.");
                }
                else
                {
                    throw new WaterOneFlowException("URL: '" + aURL, we);
                    //+ "' variable '"+code+"' statistic '"+stat +"' not found at site. Try not using the statistic", we);
                }
            }
            List<ValueSingleVariable> tsTypeList = new List<ValueSingleVariable>();

            TimeSeriesFromRDB(aTable, time, aValue, qualifier, tsTypeList);

            result.timeSeries.values.count = tsTypeList.Count.ToString();
            result.timeSeries.values.value = tsTypeList.ToArray();
        }
        private void CreateGWTimeSeriesObject(TimeSeriesResponseType result, string aURL)
        {
            // add the URL to be requested to the result
            result.queryInfo.queryURL = aURL;

            // download the iformation
            String resultFile = GetHTTPFile(aURL, 10);

            result.timeSeries.values = new TsValuesSingleVariableType();
            //result.TimeSeries.Values.valueUnits = units; // this needs to be done earlier


            DataTable aTable = NWISDelimitedTextParser.ParseFileIntoDT(resultFile);

            // dwv add code to get the code, and use that to find the correct columns
            int time = 2; // present location of time column
            String code = result.timeSeries.variable.variableCode[0].Value;
            String stat = null;
            int aValue;
            int qualifier;
            if (result.timeSeries.variable.options != null)
            {
                stat = result.timeSeries.variable.options[0].Value;
            }
            try
            {
                aValue = getVarColumn(aTable, "lev_va", null); // uses eEndWith... so this should work
                qualifier = getVarQualifiersColumn(aTable, "lev_status_cd", null);
            }
            catch (WaterOneFlowException we)
            {
                // need to insert the URL in the exception
                if (string.IsNullOrEmpty(stat))
                {
                    throw new WaterOneFlowException("URL: '" + aURL, we);
                    //+"' variable '"+code+"' not found at site.");
                }
                else
                {
                    throw new WaterOneFlowException("URL: '" + aURL, we);
                    //+ "' variable '"+code+"' statistic '"+stat +"' not found at site. Try not using the statistic", we);
                }
            }

            List<ValueSingleVariable> tsTypeList = new List<ValueSingleVariable>();
            TimeSeriesFromRDB(aTable, time, aValue, qualifier, tsTypeList);
            result.timeSeries.values.count = tsTypeList.Count.ToString();
            result.timeSeries.values.value = tsTypeList.ToArray();
        }

        /// <summary>
        /// This will add a qualifer, and if appropriate censorCode value to the  tsTypeValue type, if appropriate.
        ///  
        /// </summary>
        /// <param name="tsTypeValue">tsValuesTypeValue to populate</param>
        /// <param name="qualifier">qualifier field to parse, and look for tags that indicate that an item should be censored.</param>
        private static void parseQualifiersForCensorCode(ValueSingleVariable tsTypeValue, String qualifier)
        {
            if (!string.IsNullOrEmpty(qualifier))
            {

                if (qualifier.Contains("<"))
                {
                    tsTypeValue.censorCode = CensorCodeEnum.lt;
                    tsTypeValue.censorCodeSpecified = true;
                    qualifier = qualifier.Replace("<", "");

                }
                if (qualifier.Contains(">"))
                {
                    tsTypeValue.censorCode = CensorCodeEnum.gt;
                    tsTypeValue.censorCodeSpecified = true;
                    qualifier = qualifier.Replace(">", "");
                }
                if (!string.IsNullOrEmpty(qualifier)) tsTypeValue.qualifiers = qualifier;
            }
        }

        private static void TimeSeriesFromRDB(DataTable aTable, int time, int aValue, int qualifier, List<ValueSingleVariable> tsTypeList)
        {
            foreach (DataRow aRow in aTable.Rows)
            {
                try
                {
                    ValueSingleVariable tsTypeValue = new ValueSingleVariable();
                    tsTypeValue.dateTime = Convert.ToDateTime(aRow[time]);
                    tsTypeValue.dateTimeSpecified = true;
                    //tsTypeValue.censored = string.Empty;
                    if (string.IsNullOrEmpty(aRow[aValue].ToString()))
                        continue;
                    else
                        tsTypeValue.Value = Convert.ToDecimal(aRow[aValue]);
                    parseQualifiersForCensorCode(tsTypeValue, aRow[qualifier].ToString()); // this will add censored, if appropariate

                    tsTypeList.Add(tsTypeValue);
                }
                catch (Exception e)
                {
                    // just ignore any value errors
                }
            }
        }

        private void CreateWQTimeSeriesObject(TimeSeriesResponseType result, string aURL)
        {
            // add the URL to be requested to the result
            result.queryInfo.queryURL = aURL;

            // download the iformation
            String resultFile = GetHTTPFile(aURL, 10);

            result.timeSeries.values = new TsValuesSingleVariableType();
            //result.TimeSeries.Values.valueUnits = units; // this needs to be done earlier


            DataTable aTable = NWISDelimitedTextParser.ParseFileIntoDT(resultFile);

            // dwv add code to get the code, and use that to find the correct columns
            // time and date are separate
            int date = 2; // present location of time column
            int time = 3;
            String code = result.timeSeries.variable.variableCode[0].Value;
            int codeCol;
            int aValue;
            int qualifier; // there are many qa columns. what do we want to do about them
            /* 20070909
             * add 
#  meth_cd                    - Method code
#  dqi_cd                     - Data-quality indicator code
#  rpt_lev_va                 - Reporting level
#  rpt_lev_cd                 - Reporting level type
#  lab_std_va                 - Lab standard deviation
#  anl_ent_cd                 - Analyzing entity code
             */
            int method;
            try
            {
                /* 20070909 - USGS column name changes
                 * parameter_cd to param_cd
                 *     APPSETTING: ConfigurationManager.AppSettings["parameterColumn"];
                 * qualifiers now in val_qual_tx
                 * also:
#  meth_cd                    - Method code
 #  dqi_cd                     - Data-quality indicator code
#  rpt_lev_va                 - Reporting level
#  rpt_lev_cd                 - Reporting level type
#  lab_std_va                 - Lab standard deviation
#  anl_ent_cd                 - Analyzing entity code
                 */
                //codeCol = getVarQualifiersColumn(aTable, "parameter_cd", null);
                string parmameterColName = ConfigurationManager.AppSettings["parameterColumn"];
                codeCol = getVarQualifiersColumn(aTable, parmameterColName, null); 
                aValue = getVarColumn(aTable, "result_va", null);
                qualifier = getVarQualifiersColumn(aTable, "remark_cd", null); // there are many qa columns. what do we want to do about them
               // qualifier = getVarColumn(aTable, "val_qual_tx", null); //Do Not use a present
               
            }
            catch (WaterOneFlowException we)
            {
                throw new WaterOneFlowException("URL: '" + aURL, we);
            }
            List<ValueSingleVariable> tsTypeList = new List<ValueSingleVariable>();
            foreach (DataRow aRow in aTable.Rows)
            {
                if (aRow[codeCol].Equals(code))
                { // only do this if this is the correct value
                    ValueSingleVariable tsTypeValue = new ValueSingleVariable();
                    //tsTypeValue.time= Convert.ToDateTime(aRow[time]);
                    tsTypeValue.dateTime = Convert.ToDateTime(
                        aRow[date].ToString() +
                        " " + aRow[time].ToString()
                        );
                    tsTypeValue.dateTimeSpecified = true;
                    //tsTypeValue.censored = string.Empty;
                    if (string.IsNullOrEmpty(aRow[aValue].ToString()))
                        continue;
                    else
                        tsTypeValue.Value = Convert.ToDecimal(aRow[aValue]);

                    parseQualifiersForCensorCode(tsTypeValue, aRow[qualifier].ToString()); // this will add censored, if appropariate

                    tsTypeList.Add(tsTypeValue);
                }
            }
            result.timeSeries.values.count = tsTypeList.Count.ToString();
            result.timeSeries.values.value = tsTypeList.ToArray();
        }

        /*
         * 
                private static void CreateRealTimeSeriesObject(TimeSeriesResponse result, string resultFile)
                {
                    CreateTimeSeriesObject(result, resultFile);
                }
        */
        /*       private static void CreateGroundWaterTimeSeriesObject(TimeSeriesResponse result, string resultFile)
               {
                   CreateTimeSeriesObject(result, resultFile);
               }
       */
        /*        private static void CreateWaterQualityTimeSeriesObject(TimeSeriesResponse result, string resultFile)
                {
                    CreateTimeSeriesObject(result, resultFile);
                }
        */
        private string GetHTTPFile(string strURL, int SecondsToRespond)
        {
            Encoding encode = Encoding.GetEncoding("utf-8");
            WebRequest myWebRequest = WebRequest.Create(strURL);
#if DEBUG
            HttpWebRequest aRequest = myWebRequest as HttpWebRequest;
            if (aRequest != null)
                waterLog.WriteEntry("Answering IPAddress: " + (aRequest).Address.OriginalString, EventLogEntryType.Information);
#endif
            myWebRequest.Timeout = SecondsToRespond * 10000;
            WebResponse myWebResponse;
            myWebResponse = myWebRequest.GetResponse();
            if (myWebResponse.ContentType.StartsWith(@"text/html"))
                throw new WebException("Bad response from external resource. Requested Service URL: '" + strURL + "'");
            Stream ReceiveStream = myWebResponse.GetResponseStream();
            StreamReader readStream = new StreamReader(ReceiveStream, encode);
            string returnable = readStream.ReadToEnd();
            readStream.Close();
            return returnable;
        }

        private static string ParseDate(string aDate)
        {
            if (string.IsNullOrEmpty(aDate))
                return DateTime.Now.ToShortDateString();
            DateTime date = Convert.ToDateTime(aDate);
            return date.ToShortDateString();
        }
       
        private string UnitValues(Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate, string[] variables, string[] stations)
        {
            // only a start date is needed.
            String StartDate = usgsTime(startDate);
            String EndDate = usgsTime(endDate);
            string URL = "http://nwis.waterdata.usgs.gov/nwis/uv?format=rdb&" +
                 usgsStationQP(stations) +
                //StationsList + 
                 usgsVariablesQP(variables) +
                //"&parameter_cd=" + Variable +
                // no longer accepts begindate= as parameter
                //usgsTimePeriodQP(startDate, endDate);
               usgsUnitValuesPeriod(startDate, endDate);


            return URL;
        }

        private string DailyValues(Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate, string[] variables, string[] stations)
        {

            // convert date to string and trim off Time
            String StartDate = usgsTime(startDate);
            String EndDate = usgsTime(endDate);

            string URL = "http://waterdata.usgs.gov/nwis/dv?" +
                 usgsStationQP(stations) +
                //StationsList + 
                "&agency_cd=USGS" +
                usgsTimePeriodQP(startDate, endDate) +
                //"&date_format=YYYY-MM-DD" + "&begin_date=" + StartDate + "&end_date=" + EndDate +
                 usgsVariablesQP(variables) +
                //"&parameter_cd=" + Variable +
                "&format=rdb";
            return URL;
        }

        // really is only one groundwater parameter
        private string GroundWater(Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate, string[] stations)
        {
            // convert date to string and trim off Time
            String StartDate = usgsTime(startDate);
            String EndDate = usgsTime(endDate);
            string URL = "http://nwis.waterdata.usgs.gov/nwis/gwlevels?" +
                usgsStationQP(stations) +
                //StationsList + 
                "&agency_cd=USGS" +
                usgsTimePeriodQP(startDate, endDate) +
                //"&date_format=YYYY-MM-DD" + "&begin_date=" + StartDate + "&end_date=" + EndDate +
                "&set_logscale_y=1" +
                "&format=rdb&rdb_compression=value";
            return URL;
        }

        private string InstantaneousData(Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate, string[] variables, string[] stations)
        {
            String StartDate = usgsTime(startDate);
            String EndDate = usgsTime(endDate);
            string URL = "http://nwis.waterdata.usgs.gov/nwis/qwdata?" +
                usgsStationQP(stations) +
                //StationsList +
                 usgsVariablesQP(variables) +
                //"&parameter_cd=" + Variable +
                "&format=rdb" +
                usgsTimePeriodQP(startDate, endDate);
            //"&date_format=YYYY-MM-DD" + "&begin_date=" + StartDate + "&end_date=" + EndDate;

            return URL;
        }

        private static String usgsTime(Nullable<W3CDateTime> dt)
        {
            string dateOnly;
            if (dt.HasValue)
            {
                dateOnly = dt.Value.DateTime.ToString("yyyy-MM-dd");
                return dateOnly;
            }
            else
            {
                return "";
            }

        }

        private static string usgsTimePeriodQP(Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate)
        {
            StringBuilder qp = new StringBuilder("&date_format=YYYY-MM-DD");
            qp.Append("&begin_date=");
            qp.Append(usgsTime(startDate));
            if (endDate != null)
            {
                qp.Append("&end_date=");
                qp.Append(usgsTime(endDate));
            }
            return qp.ToString();
        }
         private static string usgsUnitValuesPeriod(Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate)
         {
             string period = "&period=";
             if (startDate.HasValue) 
             {
                 try
                 {
                     TimeSpan span = DateTime.Today.Subtract(startDate.Value.DateTime);

                     return period + (span.Days +1).ToString();
                    
                 } catch
                      {
                          // log an error
                           return period + "7";
                      }
             } else
             {
                 return period + "7";
             }
             

         }

        private static string usgsStationQP(String[] stations)
        {
            StringBuilder qp = new StringBuilder();
            if (stations.Length > 0)
            {
                qp.Append("&site_no=");
                qp.Append(stations[0]);
                for (int i = 1; i < stations.Length; i++)
                {
                    qp.Append(",");
                    qp.Append(stations[i]);
                }

            }
            return qp.ToString();
        }
        private static string usgsVariablesQP(String[] variables)
        {
            StringBuilder qp = new StringBuilder();
            if (variables.Length > 0)
            {
                qp.Append("&parameter_cd=");
                qp.Append(variables[0]);
                for (int i = 1; i < variables.Length; i++)
                {
                    qp.Append(",");
                    qp.Append(variables[i]);
                }

            }
            return qp.ToString();
        }

        private static string CreateMessage(Exception e)
        {
            string ex = e.Message + Environment.NewLine + e.StackTrace;
            if (e.InnerException != null)
                ex += Environment.NewLine + Environment.NewLine + e.InnerException.Message + Environment.NewLine + e.InnerException.StackTrace;
            return ex;
        }

        private bool CheckDataBaseForSite(string Network, string SiteNumber, SiteInfoResponseType result)
        {
            bool flag = true;
            try
            {
                using (SqlDataReader aReader = GetData("getSite", new string[] { SiteNumber, Network }, new string[] { "@SiteNumber", "@NetworkName" }))
                {
                    if (aReader.IsClosed)
                        flag = false;
                    else
                    {
                        if (aReader.HasRows)
                        {
                            //fill in SitesResponse object
                            result.site[0].siteInfo.oid = aReader["SiteID"].ToString();
                            result.site[0].siteInfo.siteCode[0].Value = aReader["SiteCode"].ToString();
                            result.site[0].siteInfo.siteName = aReader["Name"].ToString();
                            ((LatLonPointType)result.site[0].siteInfo.geoLocation.geogLocation).latitude = aReader.GetDouble(aReader.GetOrdinal(aReader["Latitude"].ToString()));
                            ((LatLonPointType)result.site[0].siteInfo.geoLocation.geogLocation).longitude = aReader.GetDouble(aReader.GetOrdinal(aReader["Longitude"].ToString()));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                waterLog.WriteEntry(e.Message + " " + e.StackTrace);
                flag = false;//if anything goes wrong default to the webservice
            }
            return flag;
        }

        /// <summary>
        /// This class is to allow for the matching of the varcolum
        /// 
        /// </summary>
        private class varColumn
        {
            public string columnTitle = null;
            public string instrument = null;
            public string parameter = null;
            public string statistic = null;
            public Boolean isCd = false;

            public varColumn(string colHeader)
            {
                columnTitle = colHeader;
                string[] temp = colHeader.Split(new string[] { "_" }, StringSplitOptions.None);
                switch (temp.Length)
                {
                    case 1:
                        parameter = temp[0];
                        break;
                    case 2:
                        if (temp[1].Equals(Statistic["qualifiers"]))
                        {
                            isCd = true;
                            parameter = temp[0];
                        }
                        else
                        {
                            instrument = temp[0];
                            parameter = temp[1];
                        }
                        break;
                    case 3:
                        instrument = temp[0];
                        parameter = temp[1];
                        if (temp[2].Equals(Statistic["qualifiers"]))
                        {
                            isCd = true;
                        }
                        else
                        {
                            statistic = temp[2];
                        }
                        break;
                    case 4:
                        instrument = temp[0];
                        parameter = temp[1];
                        statistic = temp[2];
                        if (temp[3].Equals(Statistic["qualifiers"]))
                        {
                            isCd = true;
                        }
                        break;
                    default: // >4
                        if (colHeader.Equals("sample_start_time_datum_cd"))
                        {
                            instrument = "sample";
                            parameter = "start_time";
                            statistic = "datum";                           
                                isCd = true;

                        } else
                        {
                            instrument = temp[0];
                            parameter = temp[1];
                            statistic = temp[2];
                            if (temp[temp.Length-1].Equals(Statistic["qualifiers"]))
                            {
                                isCd = true;
                            }
                        }
                        break;
                    // default should really should log an error... its a bad column name
                }



            }
            public Boolean match(String var)
            {
                if (parameter.Equals(var)) { return true; }
                else
                {
                    return false;
                }

            }
            public Boolean match(String var, String stat)
            {
                if (parameter.Equals(var))
                {
                    if (statistic.Equals(stat))
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            public Boolean exactMatch(String var)
            {
                if (columnTitle.Equals(var))
                {
                    return true;

                }
                else
                {
                    return false;

                }
            }
        }

        private static int getVarColumn(DataTable aTable, String aCode, String stat)
        {
            int colCode = -1;
            //String colCode ;

            /* NOTE: This will return only the first matching instrument.
             * logic needed
            / this will look at column names that are formated as:
            * insturment_code_statistic  (statistic:min=00001,mean=00002,max=00004)
            * insturment_code_cd

            if variable/parameter has a stat
            */

            /*
             * if (aCode.Equals("00060"))
            {
                colCode = aCode + "_" + Statistic["mean"];
            } else {
                colCode = aCode;
            }
             */
            // NOTE SAME CODE BLOCK IS USED IN getVarQualifiersColum
            // except for break after new vc.
            foreach (DataColumn aCol in aTable.Columns)
            {

                /*
                 * if (aCol.ColumnName.EndsWith(colCode))

                {
                    stat = aCol.Ordinal;
                    break;
                }
                 */
                if (colCode > -1) break; // column has already been found
                varColumn vc = new varColumn(aCol.ColumnName);
                if (vc.isCd) continue;

                if (vc.exactMatch(aCode))
                {
                    colCode = aCol.Ordinal;
                    break;
                }

                if (aCode.Equals("00060") || aCode.Equals("00065"))
                {
                    // logic match if there is or is not a stat
                    // TODO: find place to look up stat
                    if (vc.statistic != null) // has a statistic
                    {
                        // if there is an option passed in, then use it
                        if (string.IsNullOrEmpty(stat))
                        {
                            if (vc.match(aCode, Statistic["mean"]))
                            {
                                colCode = aCol.Ordinal;
                                break;
                            }
                        }
                        else
                        {
                            if (vc.match(aCode, Statistic[stat]))
                            {
                                colCode = aCol.Ordinal;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (vc.match(aCode))
                        {
                            colCode = aCol.Ordinal;
                            break;
                        }
                    }
                }
                else
                {
                    if (vc.match(aCode))
                    {
                        colCode = aCol.Ordinal;
                        break;
                    }
                }



            }
            if (colCode == -1)
            {
                if (string.IsNullOrEmpty(stat))
                {
                    throw new WaterOneFlowException(" Variable '" + aCode + "' not found at site");
                }
                else
                {
                    throw new WaterOneFlowException(" Variable '" + aCode + " statistic:'" + stat + "' not found at site.");
                }
            }
            else
            {
                return colCode;
            }
        }

        private static int getVarQualifiersColumn(DataTable aTable, String aCode, String stat)
        {
            int colCode = -1;
            //String colCode ;
            /*  NOTE: This will return only the last matching instrument.
             * logic needed
            / this will look at column names that are formated as:
            * insturment_code_statistic  (statistic:min=00001,mean=00002,max=00004)
            * insturment_code_cd

            if variable/parameter has a stat
            */

            // NOTE SAME CODE BLOCK IS USED IN getVarsColumn
            foreach (DataColumn aCol in aTable.Columns)
            {
                /*
                * if (aCol.ColumnName.EndsWith(colCode))

               {
                   stat = aCol.Ordinal;
                   break;
               }
                */
                if (colCode > -1) break; // column has already been found                
                varColumn vc = new varColumn(aCol.ColumnName);
                if (!vc.isCd) continue;

                if (vc.exactMatch(aCode))
                {
                    colCode = aCol.Ordinal;
                    break;
                }
                if (aCode.Equals("00060") || aCode.Equals("00065"))
                {
                    // logic match if there is or isnot a stat
                    // TODO: find palce to look up stat
                    if (vc.statistic != null) // has a statistic
                    {
                        // if there is an option passed in, then use it
                        if (String.IsNullOrEmpty(stat))
                        {
                            if (vc.match(aCode, Statistic["mean"]))
                            {
                                colCode = aCol.Ordinal;
                                break;
                            }
                        }
                        else
                        {
                            if (vc.match(aCode, Statistic[stat]))
                            {
                                colCode = aCol.Ordinal;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (vc.match(aCode))
                        {
                            colCode = aCol.Ordinal;
                            break;
                        }
                    }
                }
                else
                {
                    if (vc.match(aCode))
                    {
                        colCode = aCol.Ordinal;
                        break;
                    }
                }
            }
            if (colCode == -1)
            {
                throw new WaterOneFlowException("Variable '" + aCode + "' not found at site");
            }
            else
            {
                return colCode;
            }
        }

        private VariablesDataset variableDataSet
        {
            get
            {
                if (variableDataSetField == null)
                {
                    //variableDataSet = (DataSet)appCache[variableDataSetCache];
                    // variableDataSetField = (VariablesDataset)appCache[variableDataSetCache];
                    if (variableDataSetField == null)
                    {
                        // variableDataSetField = NwisVariableCatalog.VariableDataTable();
                        variableDataSetField = ODvariables.GetVariableDataSet();
                        //appCache[variableDataSetCache] = variableDataSetField;
                    }
                }
                return variableDataSetField;
            }
        }


        #region database

        private bool CheckDataBaseForVariable(string Variable, VariablesResponseType Response)
        {
            bool flag = true;
            try
            {
                if (!string.IsNullOrEmpty(Variable))
                {
                    string[] splitVariable = Variable.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    using (SqlDataReader aReader = GetData("getVariable", new string[] { splitVariable[1] }, new string[] { "@Variable" }))
                    {
                        if (aReader.IsClosed)
                            flag = false;
                        else
                        {
                            if (aReader.HasRows)
                            {
                                //fill in VariablesType1 object
                                Response.variables[0].variableCode[0].Value = aReader.GetString(aReader.GetOrdinal("VariableID"));
                                Response.variables[0].variableCode[0].vocabulary = aReader.GetString(aReader.GetOrdinal("VariableCV"));
                                Response.variables[0].units.Value = aReader.GetString(aReader.GetOrdinal("Units")); // not sure if this is the abbreviation or the text
                            }
                        }
                    }
                }
                else
                    flag = false;
            }
            catch (Exception e)
            {
                waterLog.WriteEntry(e.Message + " " + e.StackTrace);
                
                flag = false;//if anything goes wrong default to the webservice
            }
            return flag;
        }

        private static SqlDataReader GetData(string command, string[] aValue, string[] parameters)
        {
            SqlCommand aCommand;
            SqlDataReader aReader;
            // using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.enterpriseOD))
            using (SqlConnection conn = new SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["enterpriseOD"].ConnectionString
                )
            )
            {
                aCommand = new SqlCommand();
                aCommand.Connection = conn;
                aCommand.CommandType = System.Data.CommandType.StoredProcedure;
                aCommand.CommandText = command;
                int count = 0;
                foreach (string parameter in parameters)
                {
                    SqlParameter aParam = new SqlParameter(parameter, System.Data.SqlDbType.NVarChar, 50);
                    aParam.Value = aValue[count];
                    aCommand.Parameters.Add(aParam);
                    count++;
                }
                conn.Open();
                aReader = aCommand.ExecuteReader();
            }
            aCommand.Dispose();
            return aReader;
        }
        #endregion

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposeOf)
        {
            waterLog.Dispose();
        }

        #endregion
    }
}
