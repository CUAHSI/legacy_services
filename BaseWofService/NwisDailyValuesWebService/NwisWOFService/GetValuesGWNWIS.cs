using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using log4net;
using WaterOneFlow.Service.Constants.v1;
using WaterOneFlow.Service.Nwis;

using WaterOneFlowImpl;

namespace NwisWOFService
{
    namespace v1_0
    {
        using WaterOneFlow.Schema.v1;
        using WaterOneFlowImpl.v1_0;
        using WaterOneFlow.Service.v1_0;
        public class GetValuesGWNWIS : DataTimeSeriesWofService
        {
            private static ILog log = LogManager.GetLogger(typeof(GetValuesGWNWIS));
            private string BaseUrl = "http://nwis.waterdata.usgs.gov/nwis/gwlevels";

            public GetValuesGWNWIS()
                : base()
            {

            }

            public GetValuesGWNWIS(DataInfoService ds)
                : base(ds)
            {

            }
            public GetValuesGWNWIS(DataInfoService ds, string NWISrdbGWUrl)
                : base(ds)
            {
                BaseUrl = NWISrdbGWUrl;
            }
            /*
             public  TimeSeriesResponseType GetValues(
                locationParam Location,
                 VariableParam Variable,
                 W3CDateTime? BeginDateTime, W3CDateTime? EndDateTime)
            */


            [return: XmlElement(
     Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
    ElementName = "timeSeriesResponse",
    IsNullable = false
    , Type = typeof(TimeSeriesResponseType)
     )]
            public override object GetTimeSeries(
               locationParam lp,
               VariableParam vp,
                Nullable<W3CDateTime> startDate,
                Nullable<W3CDateTime> endDate)
            {

                if (lp.isGeometry)
                {
                    throw new WaterOneFlowException("Geometry not supported ");
                }

                TimeSeriesResponseType result = null;
                //string Network;
                //string SiteCode;
                ////WSUtils.ParseSiteId(siteId, out Network, out SiteCode);
                //try
                //{
                //    locationParam sq = new locationParam(siteNumber);
                //    Network = sq.Network;
                //    SiteCode = sq.SiteCode;
                //    if (sq.isGeometry)
                //    {
                //        throw new WaterOneFlowException("Location by Geometry not accepted: " + siteNumber);
                //    }
                //}
                //catch (WaterOneFlowException we)
                //{
                //    log.Info("Bad SiteID:" + siteNumber);
                //    throw;
                //}
                //catch (Exception e)
                //{
                //    log.Error("Uncaught exception:" + e.Message);
                //    throw new WaterOneFlowException("Sorry. Your submitted site ID for this getSiteInfo request caused an problem that we failed to catch programmatically: " + e.Message);
                //}

                //// string WaterQualityList = "&parameter_cd=" + variable;
                //string[] StationsList = new string[] { SiteCode };
                string[] StationsList = new string[] { lp.SiteCode };

                //VariableParam vp;
                //try
                //{
                //    vp = new VariableParam(variable);

                //}
                //catch (WaterOneFlowException we)
                //{
                //    log.Info("Bad Variable Request '" + variable + "'");
                //    throw;
                //}
                //catch (Exception e)
                //{
                //    log.Error("uncaught exception duing Variable Request '" + variable + "'");
                //    throw new WaterOneFlowException("Sorry. Your variable parameter caused an exception that we failed to catch:" + e.Message);

                //}

                result = CuahsiBuilder.CreateTimeSeriesObject();

                //// all data are provisional
                //List<note> notes = new List<note>();
                //note urlNote = new note();
                //urlNote.title = "USGS Data Provisional";
                //urlNote.href = "http://waterdata.usgs.gov/nwis/help/?provisional";
                //urlNote.Value = "All data are provisional, and subject to revision";
                //notes.Add(urlNote);
                //result.queryInfo.note = notes.ToArray();

                result.queryInfo.criteria.locationParam = lp.ToString();
                result.queryInfo.criteria.variableParam = vp.ToString();


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
                result.timeSeries.sourceInfo = DataInfoService.GetSite(lp);


                // vaiable info
                // result.timeSeries.variable = vp.getVariableSchemaType();
                //result.timeSeries.variable = NwisVariableCatalog.getVariable(vp.Code, variableDataSet);
                //result.timeSeries.variable = ODvariables.getVariable(vp.Code, variableDataSet)[0];

                // not fully correct, but just choose the first one.
                VariableInfoType[] vits = DataInfoService.GetVariableInfoObject(vp);
                result.timeSeries.variable = vits[0];
                string aURL = GroundWater(startDate, endDate,
                                                StationsList, USGSCommon.option2AgencyCode(lp));
                try
                {
                    // refactor too much abstraction
                    //CreateRealTimeSeriesObject(result, RealTime(StationsList));
                    result.timeSeries.values =
                        CreateGWTimeSeriesObject(vp, aURL);
                }
                catch (WaterOneFlowException e)
                {
                    //log.Error(e.Message + e.StackTrace);
                    throw;
                }
                catch (WaterOneFlowSourceException e)
                {
                    //log.Error(e.Message + e.StackTrace);
                    throw;
                }
                catch (WebException e)
                {
                    log.Error(e.Message + e.StackTrace);
                    throw new WaterOneFlowException("Connecting to External resource failed.", e);
                }
                catch (Exception e)
                {

                    log.Error(e.Message + e.StackTrace);
                    throw new WaterOneFlowException("An External resource failed.", e);
                }

                result.timeSeries.sourceInfo = DataInfoService.GetSite(lp);

                List<NoteType> notes = new List<NoteType>();
                NoteType urlNote = new NoteType();
                urlNote.title = "USGS URL";
                urlNote.Value = aURL;
                notes.Add(urlNote);
                result.queryInfo.note = notes.ToArray();

                return result;
            }

            private TsValuesSingleVariableType CreateGWTimeSeriesObject(VariableParam vp, string aURL)
            {

                // download the iformation
                String resultFile = USGSCommon.GetHTTPFile(aURL, 10);

                TsValuesSingleVariableType values = new TsValuesSingleVariableType();
                //result.TimeSeries.Values.valueUnits = units; // this needs to be done earlier


                DataTable aTable = NWISDelimitedTextParser.ParseFileIntoDT(resultFile);

                if (aTable.Rows.Count == 0) throw new WaterOneFlowSourceException("No Data returned");

                // dwv add code to get the code, and use that to find the correct columns
                int time = 2; // present location of time column
                String code = vp.Code;
                String stat = null;
                int aValue;
                int qualifier;
                //if (result.timeSeries.variable.options != null)
                //{
                //    stat = result.timeSeries.variable.options[0].Value;
                //}
                try
                {
                    aValue = USGSCommon.getVarColumn(aTable, "lev_va", null); // uses eEndWith... so this should work
                    qualifier = USGSCommon.getVarQualifiersColumn(aTable, "lev_status_cd", null);
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
                //TimeSeriesFromRDB(aTable, time, aValue, qualifier, tsTypeList);
                values.source = new SourceType[1];
                values.source[0] = USGSCommon.USGSSourceInformation(1);
                values.method = new MethodType[1];
                values.method[0] = USGSCommon.UnknownMethod(0);
                values.qualityControlLevel = new qualityControlLevel[1];
                values.qualityControlLevel[0] = USGSCommon.UnknownQualityControlLevel(0);

                USGSCommon.TimeSeriesFromRDB(aTable, time, aValue, qualifier, tsTypeList, false,1,0,"Unknown");
                
                values.count = tsTypeList.Count.ToString();
                values.value = tsTypeList.ToArray();

                return values;
            }

            /// <summary>
            /// Creates the URL
            /// </summary>
            /// <param name="startDate"></param>
            /// <param name="endDate"></param>
            /// <param name="stations"></param>
            /// <param name="agency"></param>
            /// <returns></returns>
            // really is only one groundwater parameter
            private string GroundWater(W3CDateTime? startDate, W3CDateTime? endDate, string[] stations, string agency)
            {
                // convert date to string and trim off Time
                String StartDate = USGSCommon.usgsTime(startDate);
                String EndDate = USGSCommon.usgsTime(endDate);
                string URL = BaseUrl +"?" +
                    USGSCommon.usgsStationQP(stations) +
                    //StationsList + 
                    "&agency_cd=" +agency +
                    USGSCommon.usgsTimePeriodQP(startDate, endDate) +
                    //"&date_format=YYYY-MM-DD" + "&begin_date=" + StartDate + "&end_date=" + EndDate +
                    "&set_logscale_y=1" +
                    "&format=rdb&rdb_compression=value";
                return URL;
            }
        }
    }
}
