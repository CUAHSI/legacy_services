using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Resources;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WaterOneFlow.Schema
{

    #region Get Schema
    public class GetSchema
    {
        public static XmlSchema SchemaV1_0()
        {
            return GetResource(Properties.Settings.Default.SchemaResourceNameV1_0);

        }

        public static XmlSchema SchemaV1_1()
        {
            return GetResource(Properties.Settings.Default.SchemaResourceNameV1_1);

        }


        public static XmlSchema SchemaV2_0()
        {
            return GetResource(Properties.Settings.Default.SchemaResourceNameV2_0);

        }

        public static String SchemaXmlV1_0()
        {
            String r = GetSchemaXmlReader(Properties.Settings.Default.SchemaResourceNameV1_0);
            return r;

        }

        public static string SchemaXmlV1_1()
        {
            return GetSchemaXmlReader(Properties.Settings.Default.SchemaResourceNameV1_1);

        }


        public static string SchemaXmlV2_0()
        {
            return GetSchemaXmlReader(Properties.Settings.Default.SchemaResourceNameV2_0);

        }

        private static String GetSchemaXmlReader(String ResourceName)
        {
            ResourceManager rm = Properties.Resources.ResourceManager;
            string xsdResource = (String)rm.GetObject(ResourceName);

            return xsdResource;
        }
        private static XmlSchema GetResource(String ResourceName)
        {
            XmlSerializer schemaSerializer = new XmlSerializer(typeof(XmlSchema));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("wtr11", "http://www.cuahsi.org/waterML/1.1/");
            ns.Add("wtr10", "http://www.cuahsi.org/waterML/1.0/");

            string xsdPath = null;

            // string schemaResourceName = Properties.Settings.Default.SchemaResourceNameV1_0;

            //ResourceManager rm = Properties.Resources.ResourceManager;
            //string xsdResource = (String)rm.GetObject(ResourceName);
            string xsdResource = GetSchemaXmlReader(ResourceName);
            if (xsdResource == null)
            {
                throw new SettingsPropertyNotFoundException("Cannot Read Missing resource from Assembely: cuahsiTimeSeries_v1");
            }
            else
            {
                XmlReader reader;
                //                  StringReader xsd = new StringReader(xsdResource);

                //XmlReaderSettings settings = new XmlReaderSettings();
                //                  settings.ValidationType = new ValidationType();
                //                  settings.ValidationType = ValidationType.Schema;
                //                // reader = new XmlTextReader(xsd);
                //                  reader = XmlReader.Create(xsd, settings);
                StringReader xsd = new StringReader(xsdResource);

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = new ValidationType();
                settings.ValidationType = ValidationType.Schema;
                //  XmlTextReader reader = new XmlTextReader(xsd);
                reader = XmlReader.Create(xsd, settings);
                //xsdPath = System.Web.HttpContext.Current.Server.MapPath("cuahsiTimeSeries_v1.xsd");
                // XmlTextReader reader = new XmlTextReader(xsdPath);
                //XmlSchema s = (XmlSchema)schemaSerializer.Deserialize(
                //    reader, null);
                XmlSchema s = XmlSchema.Read(
 reader, null);

                s.Namespaces.Add("wtr11", "http://www.cuahsi.org/waterML/1.1/");
                s.Namespaces.Add("wtr10", "http://www.cuahsi.org/waterML/1.0/");
                s.Namespaces.Add("wtr20", "http://www.cuahsi.org/waterML/2.0/");

                return s;
            }
        }

    #endregion
    }
}
