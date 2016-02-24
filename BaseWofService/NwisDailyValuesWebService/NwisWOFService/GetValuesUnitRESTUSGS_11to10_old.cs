using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using NwisWOFService.v1_0.Passthrough;
using WaterOneFlow.Service.Constants.v1;
using WaterOneFlow.Service.v1_0.Passthrough;
using WaterOneFlow.Service.v1_0.xsd;
using WaterOneFlowImpl;
using log4net;
//using NwisWOFService.pass;

namespace NwisWOFService
{
    namespace v1_0
    {
        //using NWISWS = NwisWOFService.gov.usgs.waterservices.unitvalues;
        
        using WaterOneFlow.Schema.v1;
        using WaterOneFlowImpl.v1_0;
        using WaterOneFlow.Service.v1_0;

        public class GetValuesUnitRESTUSGS_11to10 : DataTimeSeriesWofService
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

            //private NWISWS.WaterOneFlow svc;

            private string agencyCodeDefault = "USGS";
            private XmlSerializer serializer;

            private string USGSUVBaseUrl = "http://waterservices.usgs.gov/WOF/InstantaneousValues";
            private int maxRequestDays = 60;

            private CompiledXslt xslt;
            public GetValuesUnitRESTUSGS_11to10()
                : base()
            {
                maxRequestDays = Properties.Settings.Default.UVDaysAvailable;
                InitializeService();
                

            }
            public GetValuesUnitRESTUSGS_11to10(string BaseRestUrl)
                : base()
            {
                USGSUVBaseUrl = BaseRestUrl;
                maxRequestDays = Properties.Settings.Default.UVDaysAvailable;
                InitializeService();


            }
            public GetValuesUnitRESTUSGS_11to10(string BaseRestUrl, string MaximumRequestDays,  string XlstName)
                : base()
            {
                USGSUVBaseUrl = BaseRestUrl;
                maxRequestDays = int.Parse(MaximumRequestDays);
                InitializeService();


            }
            private void InitializeService()
            {
                xslt = new CompiledXslt(AppDomain.CurrentDomain.BaseDirectory + Properties.Settings.Default.xsltV11toV10);
               // serializer = new XmlSerializer(typeof(TimeSeriesResponseType));
                serializer = new XmlSerializer(typeof (TimeSeriesResponseString));
            }

            /* PASSTHOUGH VERSION */
            [return: XmlElement(
     Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "timeSeriesResponse",
   IsNullable = false
 // , Type = typeof(TimeSeriesResponseType)
     )]
            public override object GetTimeSeries(
       locationParam Location,
        VariableParam Variable,
        W3CDateTime? BeginDateTime, W3CDateTime? EndDateTime)
            {
                string siteNum;
                string parameterCode;
                string statisticCode;
                string agencyCode;
                DateTime startDateTime ;
                DateTime endDateTime ;

                if (Location.isGeometry)
                {
                    throw new WaterOneFlowException("Geometry not supported ");
                }

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
                    statisticCode = option2UsgsStatCode(Variable);
                    agencyCode = option2AgencyCode(Variable);
                }
                else
                {
                    throw new WaterOneFlowException("Missing Parameter ");
                }

                DateTime startMinDate = DateTime.Now.AddDays(-maxRequestDays);
                startDateTime = startMinDate;
                if (BeginDateTime.HasValue)
                {
                    startDateTime = BeginDateTime.Value.DateTime;
                    if (startDateTime <= startMinDate) startDateTime = startMinDate;
                } 
            


       DateTime endDateMax = DateTime.Now;
       endDateTime = endDateMax;
        if (EndDateTime.HasValue)
        {
            endDateTime = EndDateTime.Value.DateTime;
            if (endDateTime >= endDateMax) endDateTime = endDateMax;
        }
        if (endDateTime < DateTime.Now.AddDays(-maxRequestDays))
           {
               throw new WaterOneFlowException("Only Properties.Settings.Default.UVDaysAvailable days back is supported in the NWIS UV service");
           }
                if (endDateTime < startDateTime )
                {
                    endDateTime = DateTime.Now;
                }

                //TimeSpan span = endDateTime - startDateTime;
                //if (span.Days > 31 )
                //{
                //    span = new TimeSpan(31, 0, 0);
                //}
                try
                {

                    //http://waterservices.usgs.gov/WOF/InstantaneousValues?location=06869950&variable=00065&period=P1D
                    //string urlFormat = "http://{0}/{1}?location={2}&variable={3}&period=P{4}D";
                    //string url = string.Format(urlFormat, "waterservices.usgs.gov",
                    //                           "WOF/InstantaneousValues",
                    //                           siteNum,
                    //                           parameterCode,
                    //                           span.Days);
                 //   string urlFormat = "{0}?location={1}&variable={2}&startDate={3}&endDate={4}";
                    string urlFormat = "{0}?sites={1}&parameterCd={2}&startDT={3}&endDT={4}";
                    string url = string.Format(urlFormat, USGSUVBaseUrl,
                                               siteNum,
                                               parameterCode,
                                               startDateTime.ToString("yyyy-MM-dd"),
                                               endDateTime.ToString("yyyy-MM-dd")); 
                    Uri uri = new Uri(url);
                    using (WebClient web = new WebClient())
                    {
                       
                        XmlReader reader = new XmlTextReader(web.OpenRead(url));
                       MemoryStream memoryStream = new MemoryStream();
                       XmlWriter writer = XmlWriter.Create(memoryStream);
                        xslt.Transform(reader, writer);
                        memoryStream.Position = 0;
                       reader = XmlReader.Create(memoryStream);
                        TimeSeriesResponseType response
                            = (TimeSeriesResponseType)serializer.Deserialize(reader);

                        //TimeSeriesResponseType response
                        //    = new Passthrough(web.OpenRead(url));
                        return response;
                    }
                }

 
                catch (Exception ex)
                {
                    log.Info("USGS  Connection Error " + ex.Message);
                    throw new WaterOneFlowSourceException("Error connecting to USGS");
                }


         


            }


            

          

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

            public class Passthrough : WaterOneFlow.Schema.v1.TimeSeriesResponseType, IXmlSerializable
            {
                private Stream reader;
                public Passthrough()
                {
                    reader = null;
                }
                public Passthrough(Stream r)
                {
                    reader = r;
                }
                #region IXmlSerializable Members

                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
                {
                    return null;
                }

                void IXmlSerializable.ReadXml(XmlReader reader)
                {
                    throw new NotImplementedException();
                }
                void IXmlSerializable.WriteXml(XmlWriter writer)
                {
                    // Now read s into a byte buffer.
                    byte[] bytes = new byte[reader.Length];
                    int numBytesToRead = (int)reader.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to 10.
                        int n = reader.Read(bytes, numBytesRead, 10);
                        // The end of the file is reached.
                        if (n == 0)
                        {
                            break;
                        }
                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    reader.Close();
                    
                }
                #endregion
            }
        }
    }

  

}
