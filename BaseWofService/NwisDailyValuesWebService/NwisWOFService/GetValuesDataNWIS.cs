using System;
using System.Collections.Generic;
using System.Data;
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
        public class GetValuesDataNWIS : DataTimeSeriesWofService
        {
            private static ILog log = LogManager.GetLogger(typeof(GetValuesDataNWIS));
            private string BaseUrl = "http://nwis.waterdata.usgs.gov/nwis/qwdata";
            public GetValuesDataNWIS()
                : base()
            {

            }

            public GetValuesDataNWIS(DataInfoService ds)
                : base(ds)
            {

            }
            public GetValuesDataNWIS(DataInfoService ds, string BaseNWISrdbUrl)
                : base(ds)
            {
                BaseUrl = BaseNWISrdbUrl;
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

                string[] StationsList = new string[] { lp.SiteCode };

                result = CuahsiBuilder.CreateTimeSeriesObject();

                result.queryInfo.criteria.locationParam = lp.ToString();
                result.queryInfo.criteria.variableParam = vp.ToString();

                result.timeSeries.sourceInfo = DataInfoService.GetSite(lp);

                // not fully correct, but just choose the first one.
                VariableInfoType[] vits = DataInfoService.GetVariableInfoObject(vp);
                result.timeSeries.variable = vits[0];
                string aURL = InstantaneousData(startDate, endDate,
                                                new string[] { vp.Code }, StationsList, USGSCommon.option2AgencyCode(lp));
                try
                {
                    result.timeSeries.values =
                        CreateWQTimeSeriesObject(vp, aURL);
                }
                catch (WaterOneFlowException e)
                {
                    throw;
                }
                catch (WaterOneFlowSourceException e)
                {
                    throw;
                }
                catch (Exception e)
                {

                    log.Error(e.Message + e.StackTrace);
                    throw new WaterOneFlowException("An External resource failed.", e);
                }

                List<NoteType> notes = new List<NoteType>();
                NoteType urlNote = new NoteType();
                urlNote.title = "USGS URL";
                urlNote.Value = aURL;
                notes.Add(urlNote);
                result.queryInfo.note = notes.ToArray();

                return result;
            }

            private TsValuesSingleVariableType CreateWQTimeSeriesObject(VariableParam vp, string aURL)
            {
                // download the iformation
                String resultFile = USGSCommon.GetHTTPFile(aURL, 10);

                TsValuesSingleVariableType values = new TsValuesSingleVariableType();
                //result.TimeSeries.Values.valueUnits = units; // this needs to be done earlier


                DataTable aTable = NWISDelimitedTextParser.ParseFileIntoDT(resultFile);

                // dwv add code to get the code, and use that to find the correct columns
                // time and date are separate
                int date = 2; // present location of time column
                int time = 3;
                String code = vp.Code;
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
                    string parmameterColName = (string)Properties.Settings.Default["parameterColumn"];
                    codeCol = USGSCommon.getVarQualifiersColumn(aTable, parmameterColName, null);
                    aValue = USGSCommon.getVarColumn(aTable, "result_va", null);
                    qualifier = USGSCommon.getVarQualifiersColumn(aTable, "remark_cd", null); // there are many qa columns. what do we want to do about them
                    // qualifier = getVarColumn(aTable, "val_qual_tx", null); //Do Not use at present

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
                        // tsTypeValue.dateTimeSpecified = true;
                        //tsTypeValue.censored = string.Empty;
                        if (string.IsNullOrEmpty(aRow[aValue].ToString()))
                            continue;
                        else
                            tsTypeValue.Value = Convert.ToDecimal(aRow[aValue]);

                        USGSCommon.parseQualifiersForCensorCode(tsTypeValue, aRow[qualifier].ToString()); // this will add censored, if appropariate
                        // added for  hydrodesktop
                        tsTypeValue.qualityControlLevel = QualityControlLevelEnum.Unknown;
                        tsTypeValue.qualityControlLevelSpecified = true;
                        tsTypeValue.methodID = 0;
                        tsTypeValue.methodIDSpecified = true;
                        tsTypeValue.sourceID = 1;
                        tsTypeValue.sourceIDSpecified = true;
                        tsTypeList.Add(tsTypeValue);
                    }
                }
                values.count = tsTypeList.Count.ToString();
                values.value = tsTypeList.ToArray();

                // add added qualifiers
                values.source = new SourceType[1];
                values.source[0] = new SourceType();
                values.source[0].sourceID = 1;
                values.source[0].sourceIDSpecified = true;
                values.source[0].Organization = "USGS";
                values.source[0].SourceDescription = "US Geological Survey National Water Information System";
                values.source[0].SourceLink = "http://waterdata.usgs.gov/";

                values.qualityControlLevel = new qualityControlLevel[1];
                values.qualityControlLevel[0] = new qualityControlLevel();
                values.qualityControlLevel[0].qualityControlLevelID = "0";
                values.qualityControlLevel[0].qualityControlLevelCode = "Unknown";

                values.method = new MethodType[1];
                values.method[0] = new MethodType();
                values.method[0].methodID = 0;
                values.method[0].methodIDSpecified = true;
                values.method[0].MethodDescription = "Unknown";

                return values;
            }

            /// <summary>
            /// Creates the URL
            /// </summary>
            /// <param name="startDate"></param>
            /// <param name="endDate"></param>
            /// <param name="variables"></param>
            /// <param name="stations"></param>
            /// <param name="agency"></param>
            /// <returns></returns>
            private string InstantaneousData(W3CDateTime? startDate, W3CDateTime? endDate, string[] variables, string[] stations, string agency)
            {
                String StartDate = USGSCommon.usgsTime(startDate);
                String EndDate = USGSCommon.usgsTime(endDate);
                // Feb 2007 added parameters
                /*
               http://nwis.waterdata.usgs.gov/nwis/qwdata?site_no=01578310
               &agency_cd=USGS&begin_date=&end_date=
               &TZoutput=0&qw_attributes=0&inventory_output=0&rdb_inventory_output=value
               &format=rdb&qw_sample_wide=0&rdb_qw_attributes=0
               &date_format=YYYY-MM-DD&rdb_compression=value&submitted_form=brief_list
                 * 
                 * important one is &qw_sample_wide=0
                 */
                // adding one day to make the service function correctly.
                string URL = BaseUrl + "?" +
                  USGSCommon.usgsStationQP(stations) +
                  "&agency_cd=" + agency +
                    //StationsList +
                     USGSCommon.usgsVariablesQP(variables) +
                    //"&parameter_cd=" + Variable +
                    USGSCommon.usgsTimePeriodQP(startDate,
                    endDate.HasValue ? endDate.Value.AddDays(1) : endDate) +
                    "&format=rdb&" +
                    "qw_attributes=0&inventory_output=0" +
                    "&rdb_inventory_output=value" +
                    "&qw_sample_wide=0" +
                    "&rdb_qw_attributes=0"
                    ;
                //"&date_format=YYYY-MM-DD" + "&begin_date=" + StartDate + "&end_date=" + EndDate;

                return URL;
            }

        }
    }
}
