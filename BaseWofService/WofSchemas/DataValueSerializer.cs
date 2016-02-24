using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WaterOneFlow.Schema
{
    namespace v1
    {
        [XmlSchemaProvider("WaterMLSchema")]
        public partial class ValueSingleVariable : IXmlSerializable
        {
            private const string TypeName = "ValueSingleVariable";
            public XmlSchema GetSchema()
            {
                XmlSchema xs = Schema.GetSchema.SchemaV1_0();
                XmlQualifiedName xmlQualifiedName = new XmlQualifiedName("ValueSingleVariable");
                XmlSchemaObject vsv = xs.Elements[xmlQualifiedName];

                XmlSchema vsvSchema = new XmlSchema();
                vsvSchema.Items.Add(vsv);
                return vsvSchema;
            }

            public void ReadXml(XmlReader reader)
            {
                throw new NotImplementedException();
            }

            public void WriteXml(XmlWriter writer)
            {
                
                writer.WriteStartAttribute("dateTime");
                writer.WriteRaw(dateTimeField.ToString("yyyy-MM-dd"));
                writer.WriteEndAttribute();

                if (sourceIDSpecified)
                {
                    writer.WriteStartAttribute("sourceID");
                    writer.WriteRaw(sourceIDField.ToString());
                    writer.WriteEndAttribute();
                }

                if (methodIDSpecified)
                {
                    writer.WriteStartAttribute("methodID");
                    writer.WriteRaw(methodIDField.ToString());
                    writer.WriteEndAttribute();
                }

                if (sampleIDFieldSpecified)
                {
                    writer.WriteStartAttribute("sampleID");
                    writer.WriteRaw(methodIDField.ToString());
                    writer.WriteEndAttribute();
                }

                writer.WriteValue(valueField);
            }

            public static XmlQualifiedName WaterMLSchema(XmlSchemaSet xs)
            {
                //// This method is called by the framework to get the schema for this type.
                //// We return an existing schema from disk.

                XmlSchema xsd = Schema.GetSchema.SchemaV1_0();
                XmlQualifiedName xmlQualifiedName = new XmlQualifiedName("ValueSingleVariable");
                XmlSchemaObject vsv = xsd.Elements[xmlQualifiedName];

                XmlSchema vsvSchema = new XmlSchema();
                vsvSchema.Items.Add(vsv);

                xs.XmlResolver = new XmlUrlResolver();
                xs.Add(xsd);

                return new XmlQualifiedName(TypeName, "http://www.cuahsi.org/waterML/1.0/");
            }
        }
    }
}
