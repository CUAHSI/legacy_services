using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using log4net;
using WaterOneFlow.Schema.v1;
using WaterOneFlow.Service.Constants.v1;
using WaterOneFlow.Service.v1_0;
using WaterOneFlow.Service.v1_0.Passthrough;
using WaterOneFlowImpl;

//using NwisWOFService.pass;

namespace WaterOneFlow.Service.values
{
    namespace v1_0
    {
        //using NWISWS = NwisWOFService.gov.usgs.waterservices.unitvalues;
        
        public class GetValuesXslt : DataTimeSeriesWofService
        {
           
         
            private static ILog log = LogManager.GetLogger(typeof(GetValuesXslt));

            //private NWISWS.WaterOneFlow svc;

            private string agencyCodeDefault = "EPA";
            private XmlSerializer serializer;

            private string baseUrl = "http://waterservices.usgs.gov/WOF/InstantaneousValues";

            private string xsltname = Settings.Default.xslt; 

            private CompiledXslt xslt;
            public GetValuesXslt()
                : base()
            {

                InitializeService();
                

            }
            public GetValuesXslt(string BaseRestUrl, string XsltName)
                : base()
            {
                baseUrl = BaseRestUrl;
                xsltname = XsltName;
                InitializeService();


            }
           
            private void InitializeService()
            {
                xslt = new CompiledXslt(AppDomain.CurrentDomain.BaseDirectory
                    + xsltname );
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
            public  override object GetTimeSeries(
       locationParam Location,
         WaterOneFlowImpl.v1_0.VariableParam  Variable,
        W3CDateTime? BeginDateTime, W3CDateTime? EndDateTime)
            {
                // new method. Generate a list of query parameters and values, 
                // tack that onto the end of the base url
                var queryParameters = new Dictionary<string, string>();
                string siteNum;
                string parameterCode;
                string statisticCode;
                string agencyCode = "EPA";
                W3CDateTime? startDateTime = null;
                W3CDateTime? endDateTime = null;

                if (Location.isGeometry)
                {
                    throw new WaterOneFlowException("Geometry not supported ");
                }

                if (Location != null)
                {
                    siteNum = Location.SiteCode;
                    agencyCode = option2AgencyCode(Location);
                    queryParameters.Add("organization", agencyCode);
                    queryParameters.Add("siteid", siteNum);
                }
                else
                {
                    throw new WaterOneFlowException("Missing SiteCode ");
                }

                if (Variable != null)
                {
                    parameterCode = Variable.Code;

                    queryParameters.Add("characteristicName", parameterCode);
                    queryParameters.Add("sampleMedia", siteNum);
                }
                else
                {
                    throw new WaterOneFlowException("Missing Parameter ");
                }

               
                if (BeginDateTime.HasValue)
                {
                   //tartDateTime = BeginDateTime.Value;
                     queryParameters.Add("startDateLo", BeginDateTime.HasValue ? BeginDateTime.Value.ToString("W"): "");
                }



               
        if (EndDateTime.HasValue)
        {      
           //ndDateTime = EndDateTime.Value; 
                              queryParameters.Add("startDateHi",EndDateTime.HasValue ? EndDateTime.Value.ToString("W"): "");
 
        }

        if (EndDateTime.HasValue && BeginDateTime.HasValue && EndDateTime.Value < BeginDateTime.Value)
                {
                    endDateTime = W3CDateTime.Now;
                    queryParameters["startDateHi"] = W3CDateTime.Now.ToString("W");

                }
                        
                 //   http://storetnwis.epa.gov/storetqw
              /*  he site number may be optionally prefixed by the agency code followed by a colon, which ensures the site is unique. Examples: ?site=06306300 or ?sites=USGS:06306300. There is no default if this parameter is used. For real-time streamflow sites, the site number is normally 8 characters. Site numbers range from 8 to 15 character. 
                */
                string urlFormat = "&{0}={1}";
                StringBuilder url =  new StringBuilder(baseUrl);
                foreach (var q in queryParameters)
                {
                    url.AppendFormat("&{0}={1}",q.Key, q.Value);
                }
                  try
                {

                              Uri uri = new Uri(url.ToString());
                    using (WebClient web = new WebClient())
                    {
                        TimeSeriesResponseType response;


                        using (XmlReader reader = new XmlTextReader(web.OpenRead(uri)))
                        {
                            
                            XmlWriter writer = null;
                            MemoryStream memoryStream = new MemoryStream();
                            try
                            {
                              
                                writer = XmlWriter.Create(memoryStream);
                                // Create the XsltArgumentList.
                                XsltArgumentList argList = new XsltArgumentList();

                                argList.AddParam("network", "", Location.Network);
                                argList.AddParam("vocabulary", "", Variable.Vocabulary); 
                                argList.AddParam("location", "", Location.ToString());
                                argList.AddParam("variable", "", Variable.ToString());
                                argList.AddParam("starttime", "", BeginDateTime.HasValue? BeginDateTime.Value.ToString("W"): "");
                                argList.AddParam("endtime", "", EndDateTime.HasValue? EndDateTime.Value.ToString("W"): "");


                                xslt.Transform(reader, argList, writer);
                                memoryStream.Position = 0;
                                using (var reader2 = XmlReader.Create(memoryStream))
                                {
                                    response
                                        = (TimeSeriesResponseType) serializer.Deserialize(reader2);

                                }
                            }
                            finally
                            {


                                memoryStream.Close();
                               
                               
                            }
                        }
                       

                        //TimeSeriesResponseType response
                        //    = new Passthrough(web.OpenRead(url));
                        return response;
                    }
                }


                catch (WebException ex)
                {
                    if (ex.Response is HttpWebResponse)
                    {
                        switch (((HttpWebResponse)ex.Response).StatusCode)
                        {
                            case HttpStatusCode.NotFound:
                                log.Info("WebSite  Not Found" + ex.Message);
                                throw new WaterOneFlowSourceException("Site/Variable combination Not Found");
                                break;

                            case HttpStatusCode.ServiceUnavailable:
                                log.Info("WebSite  Service Not Available " + ex.Message);
                                throw new WaterOneFlowSourceException("Service Not Available. Please try later");
                                break;

                            default:
                                log.Info("WebSite  Connection Error " + ex.Message);
                                throw new WaterOneFlowSourceException("Error connecting to WebSite");

                        }
                    }
                    log.Info("WebSite  Connection Error " + ex.Message);
                    throw new WaterOneFlowSourceException("Error connecting to WebSite: WebException: " + url);

                }
                catch (XmlException ex)
                {
                    log.Info("Error in communication with WebSite " + ex.Message);
                    throw new WaterOneFlowSourceException("Error in communication with WebSite: XmlExpcetion ");
                }
                catch (XsltException ex)
                {
                    log.Info("Error in communication with WebSite " + ex.Message);
                    throw new WaterOneFlowSourceException("Error in communication with WebSite: XsltException ");
                }
                catch (Exception ex)
                {
                    log.Info("Error in communication with WebSite " + ex.Message);
                    throw new WaterOneFlowSourceException("Error in communication with WebSite: Unknown Exception ");
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

            

            private string option2AgencyCode(VariableParam vp)
            {
                string AgencyCode = agencyCodeDefault;

                if (vp.options.ContainsKey("agency"))
                {
                    AgencyCode = vp.options["agency"];

                }
                return AgencyCode;
            }

            private string option2AgencyCode(locationParam vp)
            {
                string AgencyCode = agencyCodeDefault;

                if (vp.options.ContainsKey("agency"))
                {
                    AgencyCode = vp.options["agency"];

                }
                return AgencyCode;
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
