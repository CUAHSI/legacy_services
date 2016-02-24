using System;
using System.IO;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using WaterOneFlow.Utilities;

namespace NwisWOFService
{
  using NWISWS=NwisWOFService.gov.usgs.nwis.dailyValues;
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
            public class NWISTimeSeriesResponse : TimeSeriesResponseType, IXmlSerializable
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

                public NWISWS.QueryInfoType QueryInfo
                {
                    get { return response.queryInfo; }
                }
                public NWISWS.TimeSeriesType[] TimeSeries
                {
                    get { return response.timeSeries; }
                }

                public NWISTimeSeriesResponse()
                {
                    Response  = null;
                }
                public NWISTimeSeriesResponse(gov.usgs.nwis.dailyValues.TimeSeriesResponseType
                    NWISTimeSeriesResponseType)
                {
                    Response = NWISTimeSeriesResponseType;
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
                    

                    XmlRootAttribute qi = new XmlRootAttribute("queryInfo");
                    qi.Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE;
                  XmlSerializer queryInfo= 
                      WOFXmlSerializerFactory.GetSerializer(typeof(NWISWS.QueryInfoType), qi);

                    queryInfo.Serialize(writer,QueryInfo);

                                      XmlRootAttribute ts = new XmlRootAttribute("timeSeries");
                    ts.Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE;
                  XmlSerializer timeSeries= 
                      WOFXmlSerializerFactory.GetSerializer(typeof(NWISWS.TimeSeriesType), ts);
                  foreach (NWISWS.TimeSeriesType t in TimeSeries)
                  {
                      timeSeries.Serialize(writer,t);

                  }
                   
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

