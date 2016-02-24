using System;
using System.IO;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using WaterOneFlow.Schema.v1;
using WaterOneFlow.Utilities;

namespace NwisWOFService
{
  using NWISWS=NwisWOFService.gov.usgs.waterservices.unitvalues;
        namespace v1_0.Passthrough
        {

            using WaterOneFlow.Service.Response.v1;
           // using WaterOneFlow.Schema.v1;
           using WaterOneFlow.Service.Constants.v1;
 

#region TimeSeries
          //  [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(ElementName = "timeSeriesResponse",
               Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
               IsNullable = false)]
            public class NWISUVTimeSeriesResponse : TimeSeriesResponseType, IXmlSerializable
            {

                private NWISWS.TimeSeriesResponseType response;
                public NWISWS.TimeSeriesResponseType Response
                {
                    get { return response; }
                    set
                    {
                        response = value;
                       
                    }
                }

                private QueryInfoType wofQueryInfo;
                private object wofTimeSeries;

                public NWISWS.QueryInfoType QueryInfo
                {
                    get { return response.queryInfo; }
                }
               
                public NWISWS.TimeSeriesType TimeSeries
                // in the daily values... this is  NWISWS.TimeSeriesType[] 
                {
                    get { return response.timeSeries; }
                }

                public NWISUVTimeSeriesResponse()
                {
                    Response  = null;
                }
                public NWISUVTimeSeriesResponse(NWISWS.TimeSeriesResponseType
                    NWISTimeSeriesResponseType)
                {
                    Response = NWISTimeSeriesResponseType;
                }




                #region IXmlSerializable Members

                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
                {
                    return null;
                }

                void IXmlSerializable.ReadXml(XmlReader r)
                {


                    XmlQualifiedName qname;
                    //string type = r.GetAttribute("type", XmlSchema.InstanceNamespace);

                    //if (type == null)
                    //    qname = null;

                    //qname = ToQname(r, type);

                    //if (qname != null)
                    //{
                    //    if (qname.Namespace != OrdersNamespace || qname.Name != "Order")
                    //        throw new InvalidOperationException("Unexpected xsi:type='" + qname + "'");
                    //}
                    //type = r.GetAttribute("nil", XmlSchema.InstanceNamespace);

                    //if (IsNull(r))
                    //{
                    //    r.Skip();
                    //    return o;
                    //}

                    //if (r.IsEmptyElement)
                    //    return o;

                    //if (o == null)
                    //    o = new Order();

                    r.ReadStartElement("timeSeriesResponse", WaterOneFlowImpl.v1_0.Constants.XML_SCHEMA_NAMSPACE);

                    if (r.LocalName.Equals("queryInfo") )
                    {
                        XmlRootAttribute qi = new XmlRootAttribute("queryInfo");
                        qi.Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE;
                        XmlSerializer queryInfo =
                            WOFXmlSerializerFactory.GetSerializer(typeof(NWISWS.QueryInfoType), qi);

                       wofQueryInfo = (QueryInfoType) queryInfo.Deserialize(r);

                    }
                    if (r.LocalName.Equals("timeSeries"))
                    {
                        XmlRootAttribute qi = new XmlRootAttribute("timeSeries");
                        qi.Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE;
                        XmlSerializer queryInfo =
                            WOFXmlSerializerFactory.GetSerializer(typeof(NWISWS.TimeSeriesType), qi);

                        wofTimeSeries = r.ReadOuterXml();

                    }
                r.ReadEndElement();
                   
                }


                internal static bool IsNull(XmlReader r)
                {
                    string isNull = r.GetAttribute("nil", XmlSchema.InstanceNamespace);

                    if (isNull == null || !XmlConvert.ToBoolean(isNull))
                        return false;

                    return true;
                }

                void IXmlSerializable.WriteXml(XmlWriter writer)
                {
                    

                                      XmlRootAttribute qi = new XmlRootAttribute("queryInfo");
                    qi.Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE;
                  XmlSerializer queryInfo= 
                      WOFXmlSerializerFactory.GetSerializer(typeof(NWISWS.QueryInfoType), qi);

                    queryInfo.Serialize(writer,QueryInfo);

                    WriteTimeSereiesType(writer);
                    //foreach (NWISWS.TimeSeriesType t in TimeSeries)
                  //{
                   //  timeSeries.Serialize(writer,t);

                  //}
                   
                }
                internal void WriteTimeSereiesType(XmlWriter writer)
                {
                                      XmlRootAttribute ts = new XmlRootAttribute("timeSeries");
                    ts.Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE;
                  XmlSerializer timeSeries= 
                      WOFXmlSerializerFactory.GetSerializer(typeof(NWISWS.TimeSeriesType), ts);
                  
                    timeSeries.Serialize(writer, TimeSeries);
                   
                }
                internal void WriteTimeSereiesTypePassThrough(XmlWriter writer)
                {

                }
                #endregion
            }


            
            //public class TimeSeriesResponseStream : TimeSeriesResponseType, IXmlSerializable
            //{
            // // Reading of message from rest interface, and writign to soap output writer should
            // // speed things up. This will need some work since it needs buffered output, and 
            // // checks to see that we have gotten everything from the data source.

            //    private Stream reader;

            //    public Stream Reader
            //    {
            //        get { return reader; }
            //        set { reader = value; }
            //    }

            //    public TimeSeriesResponseStream()
            //    {
            //        Reader = null;
            //    }
            //    public TimeSeriesResponseStream(StreamReader TimeSeriesResponseTypeStreamReader)
            //    {
            //        Reader = TimeSeriesResponseTypeStreamReader;
            //    }




            //    #region IXmlSerializable Members

            //    System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
            //    {
            //        return null;
            //    }

            //    void IXmlSerializable.ReadXml(XmlReader reader)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    void IXmlSerializable.WriteXml(XmlWriter writer)
            //    {
            //        int bufferSize = 1024;
            //        using (Reader){
            //           while (!Reader.CanRead) {
            //               writer.WriteRaw(Reader.);
            //           }
            //       }
            //    }

            //    #endregion
            //}
            #endregion


//#region variables
//            [XmlSchemaProvider("WaterMLSchema")]
//            [XmlRoot(ElementName = "variablesResponse",
//                Namespace = Constants.v1.ServiceDescriptions.XML_SCHEMA_NAMSPACE)]
//            public class VariablesResponse : VariablesResponseType, IXmlSerializable
//            {
//                private string xml;

//                public string Xml
//                {
//                    get { return xml; }
//                    set { xml = value; }
//                }

//                public VariablesResponse()
//                {
//                    xml = null;
//                }
//                public VariablesResponse(string VariablesResponseTypeXml)
//                {
//                    xml = VariablesResponseTypeXml;
//                }




//                #region IXmlSerializable Members

//                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
//                {
//                    return null;
//                }

//                void IXmlSerializable.ReadXml(XmlReader reader)
//                {
//                    throw new NotImplementedException();
//                }

//                void IXmlSerializable.WriteXml(XmlWriter writer)
//                {

//                    writer.WriteRaw(Xml);
//                }

//                #endregion
//            }
//            #endregion

//            #region SiteInfo
//            [XmlSchemaProvider("WaterMLSchema")]
//            public class SiteInfoResponse : SiteInfoResponseType, IXmlSerializable
//            {
//                private string xml;

//                public string Xml
//                {
//                    get { return xml; }
//                    set { xml = value; }
//                }

//                public SiteInfoResponse()
//                {
//                    xml = null;
//                }
//                public SiteInfoResponse(string SiteInfoResponseTypeXml)
//                {
//                    xml = SiteInfoResponseTypeXml;
//                }




//                #region IXmlSerializable Members

//                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
//                {
//                    return null;
//                }

//                void IXmlSerializable.ReadXml(XmlReader reader)
//                {
//                    throw new NotImplementedException();
//                }

//                void IXmlSerializable.WriteXml(XmlWriter writer)
//                {

//                    writer.WriteRaw(Xml);
//                }

//                #endregion
//            }
//            #endregion
       
        }
    }

