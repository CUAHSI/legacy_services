using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using WaterOneFlow.Service.Constants.v1;
using WaterOneFlow.Service.v1_0.Passthrough;
using WaterOneFlowImpl;
using log4net;
//using NwisWOFService.pass;

namespace NwisWOFService
{
    namespace v1_0
    {
        using WaterOneFlow.Schema.v1;
        using WaterOneFlowImpl.v1_0;
        using WaterOneFlow.Service.v1_0;
        public class GetValuesDailyUSGS : DataTimeSeriesWofService
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

            private static ILog log = LogManager.GetLogger(typeof(GetValuesDailyUSGS));

            private gov.usgs.nwis.dailyValues.GetWSService svc;

            private string agencyCodeDefault = "USGS";
            private XmlSerializer serializer;

            private string DefaultServiceUrl = "http://interim.waterservices.usgs.gov/NWISQuery/GetWSService";

            public GetValuesDailyUSGS()
                : base()
            {
                Initialixe();

            }
            public GetValuesDailyUSGS(string USGSServiceUrl)
                : base()
            {

                DefaultServiceUrl = USGSServiceUrl;
                Initialixe();
            }

            private void Initialixe()
            {

                svc = new gov.usgs.nwis.dailyValues.GetWSService();
                svc.Url = DefaultServiceUrl;


                serializer = new XmlSerializer(typeof(TimeSeriesResponseType)); 
            }
            /* PASSTHOUGH VERSION */
            [return: XmlElement(
     Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "timeSeriesResponse",
   IsNullable = false
   , Type = typeof(gov.usgs.nwis.dailyValues.TimeSeriesResponseType)
     )]
            public override object GetTimeSeries(
       locationParam Location,
        VariableParam Variable,
        W3CDateTime? BeginDateTime, W3CDateTime? EndDateTime)
            {
                string siteNum;
                string parameterCode;
                string statisticCode;
                string agencyCode = "USGS";
                string startDateTime = null;
                string endDateTime = null;

                if (Location.isGeometry)
                {
                    throw new WaterOneFlowException("Geometry not supported ");
                }
                if (Location != null)
                {
                    siteNum = Location.SiteCode;
                    if (Location.options.ContainsKey("agency"))
                    {
                        agencyCode = option2AgencyCode(Location);
                    }
                }
                else
                {

                    throw new WaterOneFlowException("Missing SiteCode ");
                }

                if (Variable != null)
                {
                    
                    parameterCode = Variable.Code;
                    statisticCode = option2UsgsStatCode(Variable);
                    //agencyCode = option2AgencyCode(Variable);

                }
                else
                {
                    throw new WaterOneFlowException("Missing Parameter ");

                }

                if (BeginDateTime.HasValue) startDateTime = BeginDateTime.Value.DateTime.ToString("yyyy-MM-dd");
                if (EndDateTime.HasValue) endDateTime = EndDateTime.Value.DateTime.ToString("yyyy-MM-dd");
                String dailyValues = null;

                try
                {
                    //dailyValues = svc.getDV(siteNum,
                    //                              parameterCode, statisticCode,
                    //                              startDateTime, endDateTime,
                    //                              agencyCode);
                    gov.usgs.nwis.dailyValues.TimeSeriesResponseType response
                        = svc.getDV(siteNum,
                                    parameterCode, statisticCode,
                                    startDateTime, endDateTime,
                                    agencyCode);

                    return response;
                }
                catch
                {
                    log.Info("USGS DailyValue Connection Error ");
                    throw new WaterOneFlowSourceException("Error connecting to USGS");
                }


                /* 
                 * Original code: tried to reqrite to a different object
                 * */
                //try
                //{
                //    //dailyValues = svc.getDV(siteNum,
                //    //                              parameterCode, statisticCode,
                //    //                              startDateTime, endDateTime,
                //    //                              agencyCode);
                //    gov.usgs.nwis.dailyValues.TimeSeriesResponseType response
                //        = svc.getDV(siteNum,
                //                    parameterCode, statisticCode,
                //                    startDateTime, endDateTime,
                //                    agencyCode);
 
                //    StringBuilder sb = new StringBuilder();


                //    // Create an XmlRootAttribute overloaded constructer 
                //    //and set its namespace.
                //    XmlRootAttribute tsXmlRootAttribute =
                //                   new XmlRootAttribute("timeSeriesResponse");
                //    tsXmlRootAttribute.Namespace = Constants.XML_SCHEMA_NAMSPACE;

                //    XmlSerializer xs = new XmlSerializer(
                //        typeof(gov.usgs.nwis.dailyValues.TimeSeriesResponseType),
                //        tsXmlRootAttribute);
 
                //    XmlWriter writer = XmlWriter.Create(sb);

                //    xs.Serialize(writer, response);

                //    dailyValues = sb.ToString();
                //}
                //catch
                //{
                //    log.Info("USGS DailyValue Connection Error ");
                //    throw new WaterOneFlowSourceException("Error connecting to USGS");
                //}
                //dailyValues.Replace("ns2:", "");
                //if (dailyValues.Contains("<Error>"))
                //{
                //    log.Info("Error from USGS: " + dailyValues);
                //    throw new WaterOneFlowException("Error message from USGS: " + dailyValues);
                //}
                ////String dailyValues =
                ////    File.ReadAllText(
                ////        "D:\\dev2005\\BasicOneFlowWebService\\BasicWebService\\NwisWOFService\\usgs_samples\\USGSNwisResponse_20071016_modified.xml");

                //// section rewritten to use passthrough
                ////TimeSeriesResponseType res = reserializeResponse(dailyValues);
                ////try
                ////{
                ////    res.timeSeries.values.count = res.timeSeries.values.value.LongLength.ToString();
                ////}
                ////catch
                ////{
                ////    log.Info("DailyValue response with no values: " + Location.ToString() + " variable:" + Variable);
                ////}
                ////List<NoteType> notes;
                ////if (res.queryInfo.note != null)
                ////{
                ////    notes = new List<NoteType>(res.queryInfo.note);

                ////}
                ////else
                ////{
                ////    notes = new List<NoteType>();
                ////}
                ////NoteType urlNote = new NoteType();
                ////urlNote.title = "CUAHSI Data Source";
                ////urlNote.href = svc.Url;
                ////urlNote.Value = "Retrieved from USGS WaterML Soap Interface";
                ////notes.Add(urlNote);
                ////res.queryInfo.note = notes.ToArray();

                //WaterOneFlow.Service.v1_0.Passthrough.TimeSeriesResponseString res = 
                //    new TimeSeriesResponseString(dailyValues);


                //////TimeSeriesResponsePassthrough pass= new TimeSeriesResponsePassthrough(dailyValues);
                ////    NwisWOFService.pass.TimeSeriesResponseType pass = new NwisWOFService.pass.TimeSeriesResponseType(dailyValues);
                ////    WaterOneFlow.Service.Schema.v1.TimeSeriesResponseType res = (WaterOneFlow.Service.Schema.v1.TimeSeriesResponseType)pass;

                //return res;


            }


            // Code ethat does not use Passthrough

            //public override TimeSeriesResponseType GetTimeSeries(
            //   locationParam Location,
            //    VariableParam Variable,
            //    W3CDateTime? BeginDateTime, W3CDateTime? EndDateTime)
            //{
            //    string siteNum;
            //    string parameterCode;
            //    string statisticCode;
            //    string agencyCode;
            //    string startDateTime = null;
            //    string endDateTime = null;

            //    if (Location != null)
            //    {
            //        siteNum = Location.SiteCode;
            //    }
            //    else
            //    {

            //        throw new WaterOneFlowException("Missing SiteCode ");
            //    }

            //    if (Variable != null)
            //    {
            //        parameterCode = Variable.Code;
            //        statisticCode = option2UsgsStatCode(Variable);
            //        agencyCode = option2AgencyCode(Variable);

            //    }
            //    else
            //    {
            //        throw new WaterOneFlowException("Missing Parameter ");

            //    }

            //    if (BeginDateTime.HasValue) startDateTime = BeginDateTime.Value.DateTime.ToString("yyyy-MM-dd");
            //    if (EndDateTime.HasValue) endDateTime = EndDateTime.Value.DateTime.ToString("yyyy-MM-dd");
            //    String dailyValues = null;
            //    try
            //    {
            //        //dailyValues = svc.getDV(siteNum,
            //        //                              parameterCode, statisticCode,
            //        //                              startDateTime, endDateTime,
            //        //                              agencyCode);
            //        gov.usgs.nwis.dailyValues.TimeSeriesResponseType response
            //            = svc.getDV(siteNum,
            //                        parameterCode, statisticCode,
            //                        startDateTime, endDateTime,
            //                        agencyCode);

            //        StringBuilder sb = new StringBuilder();


            //        // Create an XmlRootAttribute overloaded constructer 
            //        //and set its namespace.
            //        XmlRootAttribute tsXmlRootAttribute =
            //                       new XmlRootAttribute("timeSeriesResponse");
            //        tsXmlRootAttribute.Namespace = Constants.XML_SCHEMA_NAMSPACE;

            //        XmlSerializer xs = new XmlSerializer(
            //            typeof(gov.usgs.nwis.dailyValues.TimeSeriesResponseType),
            //            tsXmlRootAttribute);
            //        XmlWriter writer = XmlWriter.Create(sb);
            //        xs.Serialize(writer, response);
            //        dailyValues = sb.ToString();
            //    }
            //    catch
            //    {
            //        log.Info("USGS DailyValue Connection Error ");
            //        throw new WaterOneFlowSourceException("Error connecting to USGS");
            //    }
            //    dailyValues.Replace("ns2:", "");
            //    if (dailyValues.Contains("<Error>"))
            //    {
            //        log.Info("Error from USGS: " + dailyValues);
            //        throw new WaterOneFlowException("Error message from USGS: " + dailyValues);
            //    }
            //    //String dailyValues =
            //    //    File.ReadAllText(
            //    //        "D:\\dev2005\\BasicOneFlowWebService\\BasicWebService\\NwisWOFService\\usgs_samples\\USGSNwisResponse_20071016_modified.xml");

            //    // section rewritten to use passthrough
            //    TimeSeriesResponseType res = reserializeResponse(dailyValues);
            //    try
            //    {
            //        res.timeSeries.values.count = res.timeSeries.values.value.LongLength.ToString();
            //    }
            //    catch
            //    {
            //        log.Info("DailyValue response with no values: " + Location.ToString() + " variable:" + Variable);
            //    }
            //    List<NoteType> notes;
            //    if (res.queryInfo.note != null)
            //    {
            //        notes = new List<NoteType>(res.queryInfo.note);

            //    }
            //    else
            //    {
            //        notes = new List<NoteType>();
            //    }
            //    NoteType urlNote = new NoteType();
            //    urlNote.title = "CUAHSI Data Source";
            //    urlNote.href = svc.Url;
            //    urlNote.Value = "Retrieved from USGS WaterML Soap Interface";
            //    notes.Add(urlNote);
            //    res.queryInfo.note = notes.ToArray();


            //    ////TimeSeriesResponsePassthrough pass= new TimeSeriesResponsePassthrough(dailyValues);
            //    //    NwisWOFService.pass.TimeSeriesResponseType pass = new NwisWOFService.pass.TimeSeriesResponseType(dailyValues);
            //    //    WaterOneFlow.Service.Schema.v1.TimeSeriesResponseType res = (WaterOneFlow.Service.Schema.v1.TimeSeriesResponseType)pass;

            //    return res;


            //}

          

            /// <summary>
            /// read string from USGS, and reserializes it.
            /// </summary>
            /// <param name="dailyValues"></param>
            /// <returns></returns>
            private WaterOneFlow.Schema.v1.TimeSeriesResponseType reserializeResponse(String dailyValues)
            {
                WaterOneFlow.Schema.v1.TimeSeriesResponseType res = null;
                try
                {
                    TextReader reader = new StringReader(dailyValues);



                    res = (WaterOneFlow.Schema.v1.TimeSeriesResponseType)serializer.Deserialize(reader);
                }
                catch
                {
                    log.Error("USGS DailyValue Bad WaterML Format");
                    throw new WaterOneFlowSourceException("Error retrieving information from USGS");

                }
                return res;
            }

            /// <summary>
            /// Returns the statistic code for the USGS daily values
            /// Assumes that all daily 
            /// </summary>
            /// <param name="vp"></param>
            /// <returns></returns>
            private static string option2UsgsStatCode(VariableParam vp)
            {
                string usgsStatCode = null;

                if (vp.options.ContainsKey("statistic"))
                {
                    usgsStatCode = vp.options["statistic"];

                }
                else if (vp.options.ContainsKey("datatype"))
                {
                    //Hashtable statMap = new Hashtable(CaseInsensitiveHashCodeProvider.DefaultInvariant,
                    //    CaseInsensitiveComparer.DefaultInvariant);
                    //statMap.Add("average", "00003");
                    //statMap.Add("minimum", "00002");
                    //statMap.Add("maximum", "00001");
                    //statMap.Add("Cumulative", "00006");
                    //statMap.Add("median", "00008");
                    //statMap.Add("variance", "00010");
                    //statMap.Add("instantaneous", "00011");
                    ///* not defined by ODM
                    //statMap.Add("mode",  "00007");    
                    //statMap.Add("STD",  "00009");
                    //statMap.Add("SKEWNESS",  "00013");
                    // */

                    string stat = vp.options["datatype"];
                    // if (statMap.ContainsKey(stat))
                    if (UsgsStatistic.Code.ContainsKey(stat))
                    {
                        usgsStatCode = UsgsStatistic.Code[stat];

                    }
                    else
                    {
                        // for daily values... we need to send a stat code
                        // usgsStatCode = defaultStatCode;
                        StringBuilder statNames = new StringBuilder();
                        foreach (String key in UsgsStatistic.Code.Keys)
                        {
                            statNames.AppendFormat(" '{0}'", key);
                        }
                        throw new WaterOneFlowException("Bad datatype option: " +
                            "Only Accepted names:" +
                            statNames.ToString());
                    }

                }
                else
                {
                    usgsStatCode = statCodeDefault;
                }

                return usgsStatCode;

            }

            private string option2AgencyCode(VariableParam vp)
            {
                string usgsAgencyCode = agencyCodeDefault;

                if (vp.options.ContainsKey("agency"))
                {
                    usgsAgencyCode = vp.options["agency"];

                }
                return usgsAgencyCode;
            }

            private string option2AgencyCode(locationParam vp)
            {
                string usgsAgencyCode = agencyCodeDefault;

                if (vp.options.ContainsKey("agency"))
                {
                    usgsAgencyCode = vp.options["agency"];

                }
                return usgsAgencyCode;
            }

        }
    }
}
