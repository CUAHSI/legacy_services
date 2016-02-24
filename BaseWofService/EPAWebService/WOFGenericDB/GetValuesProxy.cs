using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WaterOneFlow.Schema.v1;
using WaterOneFlow.ws;
using WaterOneFlowImpl;
using log4net;


namespace WaterOneFlow.GenericDB
{
    /// <summary>
    /// this class retrieve values from an existing service
    /// <para>This will retirve from a web reference, then read returned response into a new 
    /// TimeSeriesResponse class, which is serialized over the web service.</para> 
    /// 
    /// </summary>
    public class GetValuesProxy : DataTimeSeriesWofService
    {
        /*
#    DD parameter statistic - Description
#    --   -----     -----     ------------------------------------
#   *09   00045     00006   - Precipitation, total, inches (Sum)
#   *20   00095     00001   - Specific conductance, water, unfiltered, microsiemens per centimeter at 25 degrees Celsius (Maximum)
#   *20   00095     00002   - Specific conductance, water, unfiltered, microsiemens per centimeter at 25 degrees Celsius (Minimum)
#   *20   00095     00003   - Specific conductance, water, unfiltered, microsiemens per centimeter at 25 degrees Celsius (Mean)

         * */
        static string statCodeDefault = "00003";

        private static ILog log = LogManager.GetLogger(typeof(GetValuesProxy));

        private edu.sdsc.river.WaterOneFlow svc;

        private XmlSerializer serializer;
        private XmlSerializer WebServiceSerializer;

        public GetValuesProxy():base()
        {
            svc = new edu.sdsc.river.WaterOneFlow();
            svc.Url = Properties.Settings.Default.WOFGenericDB_edu_sdsc_river_WaterOneFlow;
            serializer = new XmlSerializer(typeof(TimeSeriesResponseType));
            WebServiceSerializer = new XmlSerializer(typeof(edu.sdsc.river.TimeSeriesResponseType));
        }

        public override TimeSeriesResponseType GetTimeSeries(
           locationParam Location,
            VariableParam Variable,
            W3CDateTime? BeginDateTime, W3CDateTime? EndDateTime)
        {
            string siteNum;
            string parameterCode;
            string statisticCode;
           string agencyCode;
            string startDateTime = null;
            string endDateTime = null;

            if (Location != null)
            {
                siteNum = Location.SiteCode;
            }
            else
            {

                throw new WaterOneFlowException("Missing SiteCode ");
            }

            if (Variable != null)
            {
                parameterCode = Variable.Code;
  
            }
            else
            {
                throw new WaterOneFlowException("Missing Parameter ");

            }

            if (BeginDateTime.HasValue) startDateTime = BeginDateTime.Value.DateTime.ToString("yyyy-MM-dd");
            if (EndDateTime.HasValue) endDateTime = EndDateTime.Value.DateTime.ToString("yyyy-MM-dd");
           edu.sdsc.river.TimeSeriesResponseType valuesResponse = null;
            try
            {

                valuesResponse = svc.GetValuesObject(Location.ToString(),

                                             Variable.ToString(),
                                              startDateTime, endDateTime,
                                             null
                                             );

            }
            catch
            {
                log.Info("DailyValue Connection Error "  );
                throw new WaterOneFlowSourceException("Error connecting to Values Service");
            }
            
            Stream xStream = new MemoryStream();
            serializer.Serialize(xStream, valuesResponse);
            TimeSeriesResponseType res = (TimeSeriesResponseType)serializer.Deserialize(xStream);
           
            // this was for string responses
            //TimeSeriesResponseType res = reserializeResponse(WebServiceSerializer.Serialize(valuesResponse));

            List<note> notes;
            if (res.queryInfo.note != null)
            {
                notes = new List<note>(res.queryInfo.note);
                
            } else
            {
                notes = new List<note>();
            }
           note urlNote = new note();
           urlNote.title = "CUAHSI Data Source";
            urlNote.href = svc.Url;
           urlNote.Value = "Retrieved from WaterML Soap Interface";
           notes.Add(urlNote);
           res.queryInfo.note = notes.ToArray();

 
           return res;
 

        }

        /// <summary>
        /// read string from USGS, and reserializes it.
        /// </summary>
        /// <param name="dailyValues"></param>
        /// <returns></returns>
        private TimeSeriesResponseType reserializeResponse(String dailyValues)
        {
            TimeSeriesResponseType res = null;
            try
            {
                TextReader reader = new StringReader(dailyValues);



                res = (TimeSeriesResponseType)serializer.Deserialize(reader);
            }
            catch
            {
                log.Error("Bad WaterML Format");
                throw new WaterOneFlowSourceException("Error retrieving information from USGS");

            }
            return res;
        } 

        /// <summary>
     
    }
}
