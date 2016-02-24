using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace NwisWOFService.pass
{
    [XmlSchemaProvider("MySchema")]
    public class TimeSeriesResponseType :
             WaterOneFlow.Schema.v1.TimeSeriesResponseType, IXmlSerializable
    {

        string response = null;

        public string Response
        {
            get { return response; }
            set { response = value; }
        }
        public TimeSeriesResponseType()
        {
            response = null;
        }

        public TimeSeriesResponseType(String TimeSeriesResponseString)
        {

            response = TimeSeriesResponseString;
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(response);
        }

        public static XmlQualifiedName MySchema(XmlSchemaSet xs)
        {
            // This method is called by the framework to get the schema for this type.
            // We return an existing schema from disk.

            XmlSerializer schemaSerializer = new XmlSerializer(typeof(XmlSchema));
            string xsdPath = null;
            // NOTE: replace the string with your own path.
            xsdPath = System.Web.HttpContext.Current.Server.MapPath("SongStream.xsd");
            XmlSchema s = (XmlSchema)schemaSerializer.Deserialize(
                new XmlTextReader(xsdPath), null);
            xs.XmlResolver = new XmlUrlResolver();
            xs.Add(s);

            return new XmlQualifiedName("songStream", ns);
        }
    }
}
