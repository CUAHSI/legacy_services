using System;
using System.IO;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using WaterOneFlow.Schema.v1;


namespace WaterOneFlow
{
    namespace Service
    {
        namespace v1_0.Passthrough
        {

            using WaterOneFlow.Service.Response.v1;
           // using WaterOneFlow.Schema.v1;
           using WaterOneFlow.Service.Constants.v1;

            using VariablesResponseTypeObject = WaterOneFlow.Schema.v1.VariablesResponseType;
            using QueryInfoElement = WaterOneFlow.Schema.v1.QueryInfoType;
            using VariablesElement = WaterOneFlow.Schema.v1.variables;

            using SiteInfoResponseTypeObject = WaterOneFlow.Schema.v1.SiteInfoResponseType;
            using TimeSeriesResponseTypeObject = WaterOneFlow.Schema.v1.TimeSeriesResponseType;

#region TimeSeries
          //  [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(ElementName = "timeSeriesResponse",
               Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
               IsNullable = false)]
            public class TimeSeriesResponseString : TimeSeriesResponseTypeObject, IXmlSerializable
            {
                private QueryInfoElementString _queryInfoString;
                private TimeSeriesElementString __timeSeriesString;

                private string _queryInfo;
                private string _timeSeries;
                private string xml;

                public string Xml
                {
                    get { return xml; }
                    set
                    {
                      TextReader reader = new StringReader(value);
                   XmlReader xReader =  XmlReader.Create(reader);
                    WaterOneFlow.Service.Schema.Utilities.GetResponseElements.Response res = 
                    WaterOneFlow.Service.Schema.Utilities.GetResponseElements.StripResponseElement("timeSeriesResponse",xReader) ;
                        xml = res.Xml;
                    }
                }

                public QueryInfoElementString QueryInfo
                {
                    get { return _queryInfoString; }
                    set { _queryInfoString = value; } 
                }

                public TimeSeriesResponseString()
                {
                   // Xml = null;
                }
                public TimeSeriesResponseString(string TimeSeriesResponseTypeXml)
                {
                    Xml = TimeSeriesResponseTypeXml;
                }




                #region IXmlSerializable Members

                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
                {
                    return null;
                }

                void IXmlSerializable.ReadXml(XmlReader reader)
                {

                   
                  xml = reader.ReadInnerXml();
                    //reader.MoveToContent();

                    //Boolean isEmptyElement = reader.IsEmptyElement; // (1)
                    //reader.ReadStartElement();
                    //if (!isEmptyElement) // (1)
                    //{
                    //    xml = reader.ReadInnerXml();

                    //}
                }

                void IXmlSerializable.WriteXml(XmlWriter writer)
                {
                     
                    
                  //  writer.WriteString(Xml);
                    
                    writer.WriteRaw(Xml);
                }

                #endregion
            }

            [XmlRoot(ElementName = "queryInfo",
             Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
             IsNullable = false)]
            public class QueryInfoElementString : QueryInfoElement, IXmlSerializable
            {
                
              
                private string xml;

                public string Xml
                {
                    get { return xml; }
                    set
                    {
                        TextReader reader = new StringReader(value);
                        XmlReader xReader = XmlReader.Create(reader);
                        WaterOneFlow.Service.Schema.Utilities.GetResponseElements.Response res =
                        WaterOneFlow.Service.Schema.Utilities.GetResponseElements.StripResponseElement("timeSeriesResponse", xReader);
                        xml = res.Xml;
                    }
                }

                

                public QueryInfoElementString()
                {
                    // Xml = null;
                }
                public QueryInfoElementString(string QueryInfoElementString)
                {
                    Xml = QueryInfoElementString;
                }




                #region IXmlSerializable Members

                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
                {
                    return null;
                }

                void IXmlSerializable.ReadXml(XmlReader reader)
                {
                   

                     xml = reader.ReadInnerXml();
                    //reader.MoveToContent();

                    //Boolean isEmptyElement = reader.IsEmptyElement; // (1)
                    //reader.ReadStartElement();
                    //if (!isEmptyElement) // (1)
                    //{
                    //    xml = reader.ReadInnerXml();

                    //}
                }

                void IXmlSerializable.WriteXml(XmlWriter writer)
                {
                    writer.WriteRaw(Xml);
                }

                #endregion
            }

            [XmlRoot(ElementName = "timeSeries",
          Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
          IsNullable = false)]
            public class TimeSeriesElementString : TimeSeriesType, IXmlSerializable
            {


                private string xml;

                public string Xml
                {
                    get { return xml; }
                    set
                    {
                        XmlReaderSettings settings = new XmlReaderSettings();
                        settings.ConformanceLevel = ConformanceLevel.Fragment;
                        settings.CheckCharacters=true;

                        TextReader reader = new StringReader(value);
                       // XmlReader xReader = XmlReader.Create(reader);
                        XmlReader xReader = XmlReader.Create(reader, settings);
                        WaterOneFlow.Service.Schema.Utilities.GetResponseElements.Response res =
                        WaterOneFlow.Service.Schema.Utilities.GetResponseElements.StripResponseElement("timeSeriesResponse", xReader);
                        xml = res.Xml;
                    }
                }



                public TimeSeriesElementString()
                {
                    // Xml = null;
                }
                public TimeSeriesElementString(string TimeSeriesElementString)
                {
                    Xml = TimeSeriesElementString;
                }




                #region IXmlSerializable Members

                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
                {
                    return null;
                }

                void IXmlSerializable.ReadXml(XmlReader reader)
                {


                    xml = reader.ReadInnerXml();
                    //reader.MoveToContent();

                    //Boolean isEmptyElement = reader.IsEmptyElement; // (1)
                    //reader.ReadStartElement();
                    //if (!isEmptyElement) // (1)
                    //{
                    //    xml = reader.ReadInnerXml();

                    //}
                }

                void IXmlSerializable.WriteXml(XmlWriter writer)
                {
                    writer.WriteRaw(Xml);
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
}
