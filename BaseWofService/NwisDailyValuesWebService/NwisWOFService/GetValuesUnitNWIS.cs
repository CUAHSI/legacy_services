using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using log4net;
using WaterOneFlow.Service.Constants.v1;
using WaterOneFlowImpl;

namespace NwisWOFService
{
    namespace v1_0
    {
        using WaterOneFlow.Schema.v1;
        using WaterOneFlowImpl.v1_0;
        using WaterOneFlow.Service.v1_0;
        public class GetValuesUnitNWIS : DataTimeSeriesWofService
        {
            private static ILog log = LogManager.GetLogger(typeof(GetValuesUnitNWIS));

            public GetValuesUnitNWIS()
                : base()
            {

            }

            public GetValuesUnitNWIS(DataInfoService ds)
                : base(ds)
            {

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
                // put the date check up front.
                // a start date can be older than 31 days, as long as the endDate is not older than 31 days.

                if (endDate.HasValue && endDate.Value.DateTime < DateTime.Today.AddDays(-31))
                {
                    throw new WaterOneFlowException("No Data. EndDate must be less than that 31 days from present.");
                }

                TimeSeriesResponseType result = null;

                string[] StationsList = new string[] { lp.SiteCode };

                result = CuahsiBuilder.CreateTimeSeriesObject();


                result.queryInfo.criteria.locationParam = lp.ToString();
                result.queryInfo.criteria.variableParam = vp.ToString();

                // not fully correct, but just choose the first one.
                VariableInfoType[] vits = DataInfoService.GetVariableInfoObject(vp);
                result.timeSeries.variable = vits[0];

                string aUrl = UnitValues(startDate, endDate,
                                         new string[] { vp.Code }, StationsList);
                try
                {
                    // refactor too much abstraction
                    //CreateRealTimeSeriesObject(result, RealTime(StationsList));
                    result.timeSeries.values =
                        USGSCommon.CreateTimeSeriesValuesElement(vp,
                        aUrl,
                        true // add provisional flag
                        );
                }
                catch (Exception e)
                {

                    log.Error(e.Message + e.StackTrace);
                    throw new WaterOneFlowException("An External resource failed.", e);
                }

                // add site information
                result.timeSeries.sourceInfo = DataInfoService.GetSite(lp);

                // all data are provisional
                List<NoteType> notes = new List<NoteType>();
                NoteType pNote = new NoteType();
                pNote.title = "USGS Data Provisional";
                pNote.href = "http://waterdata.usgs.gov/nwis/help/?provisional";
                pNote.Value = "All data are provisional, and subject to revision";
                notes.Add(pNote);

                NoteType urlNote = new NoteType();
                urlNote.title = "USGS URL";
                urlNote.Value = aUrl;
                notes.Add(urlNote);

                result.queryInfo.note = notes.ToArray();

                return result;
            }

            private static string UnitValues(
                Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate,
                string[] variables, string[] stations)
            {
                // only a start date is needed.
                String StartDate = USGSCommon.usgsTime(startDate);
                String EndDate = USGSCommon.usgsTime(endDate);
                string URL = "http://nwis.waterdata.usgs.gov/nwis/uv?format=rdb&date_format=YYYY-MM-DD&" +
                     USGSCommon.usgsStationQP(stations) +
                    //StationsList + 
                     USGSCommon.usgsVariablesQP(variables) +
                    //"&parameter_cd=" + Variable +
                    // no longer accepts begin_date= as parameter
                    USGSCommon.usgsTimePeriodQP(startDate, endDate);
                //USGSCommon.usgsUnitValuesPeriod(startDate, endDate);


                return URL;
            }
        }
    }
}
