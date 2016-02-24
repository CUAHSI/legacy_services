using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Resources;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WaterOneFlow.Ogc
{
      #region capabilities
            /// <summary>
            /// Returns a waterML 1.0 Xml Schema for the VariablesResponseType Type Element
            /// <para>This class should be extended, and the programmer must implement
            /// IXmlSerializable interface in the extended class. Only the WriteXml method
            /// needs full implmentation to be used in web service. The GetSchema, and
            /// ReadXml can bel left as  NotImplementedException</para>
            /// <para>This will allow for programers to impelement pass through 
            /// XML, or a variety of 
            /// XmlSerializers.</para>
            /// </summary>

            [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(
               Namespace = "http://www.cuahsi.org/his/wof",
       ElementName = "WOF_Capabilities")]  // should get WOF Capabilites
            public class WofCapabilities : IXmlSerializable
            {
                // used in the schema method
                // needed to convert Element variablesResponse to a complex
                // type derived from "VariablesResponseType"
                private const string TypeName = "WOF_CapabilitiesType"; // should be WOF Capabilite type in the future

               //   private const string TypeName = "variablesResponse";

                public WofCapabilities()
                {

                }

                /// <summary>
                /// Returns the WaterML XmlSchema, v1
                /// <para>This is an embdeded resource, "cuahsiTimeSeries_v1"</para>
                /// </summary>
                /// <param name="xs"></param>
                /// <returns></returns>
                public static XmlQualifiedName WaterMLSchema(XmlSchemaSet xs)
                {
                    //// This method is called by the framework to get the schema for this type.
                    //// We return an existing schema from disk.

                    xs.XmlResolver = new XmlUrlResolver();

                    // if you do not include this line, then it does not work
                   // xs.Add("http://www.opengis.net/ows/1.1", "http://schemas.opengis.net/ows/1.1.0/owsGetCapabilities.xsd");
                           StringCollection schemaListing = (StringCollection) Properties.Settings.Default.schemasReferenced;
    foreach(string s in schemaListing )
    {
        string[] nameSchema = s.Split(new string[]{" "}, StringSplitOptions.None);
        if (nameSchema.Length == 2)
        {
           if (nameSchema[0].Equals("http://www.w3.org/XML/1998/namespace" ))
           {
               break;
           } 
               xs.Add(nameSchema[0], nameSchema[1]);
           
        } else
        {
            // throw a warnign to a log file
        }
    }
                    {
      

    }
                    
                    /* this is trying to remove the xml namespace that
                     * is improperly added. 
                     * It needs to be added with an XML namespace
                     * 
                     * But if you just remove it. 
                     * xs.Remove()
                     * things break badly
                    */
                    if (xs.Contains("http://www.w3.org/XML/1998/namespace"))
                    {
                        ICollection xmlnamespace = xs.Schemas("http://www.w3.org/XML/1998/namespace");
                        foreach (XmlSchema x in xmlnamespace)
                        {
                            //xs.Remove(x)
                         
                        }
                    }
                    xs.Add(GetSchemaResource.Schema());
                    
                    return new XmlQualifiedName(TypeName
                        , "http://www.cuahsi.org/his/wof"
                        );
                }
                #region IXmlSerializable Members

                public System.Xml.Schema.XmlSchema GetSchema()
                {
                    return null;
                }

                public void ReadXml(System.Xml.XmlReader reader)
                {
                    throw new NotImplementedException();
                }

                public void WriteXml(System.Xml.XmlWriter writer)
                {
                    throw new NotImplementedException();
                }

                #endregion

                         
          
   
            }
             
            #endregion

         

            #region Get Schema
            public class GetSchemaResource
        {
                public static XmlSchema Schema()
            {
                XmlSerializer schemaSerializer = new XmlSerializer(typeof(XmlSchema));
                string xsdPath = null;

                string schemaResourceName = (string) Properties.Settings.Default.CapabilitiesSchema_1;

                ResourceManager rm = Properties.Resources.ResourceManager;
                string xsdResource = (String)rm.GetObject(schemaResourceName);
                if (xsdResource == null)
                {
                    throw new SettingsPropertyNotFoundException("Cannot Read Missing resource from Assembely: " + schemaResourceName);
                }
                else
                {
                    StringReader xsd = new StringReader(xsdResource);


                    XmlTextReader reader = new XmlTextReader(xsd);
                    XmlSchema s = (XmlSchema)schemaSerializer.Deserialize(
                        reader, null);
                    return s;
                }
                }
        }
            #endregion

        }// namespace v1

