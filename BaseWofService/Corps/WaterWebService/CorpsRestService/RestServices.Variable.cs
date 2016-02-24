using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using RestServiceClient;
using log4net;
using WaterOneFlow.Schema.v1;


namespace RestServiceClient
{
    namespace v1
    {
        using VariablesResponseType = WaterOneFlow.Schema.v1.VariablesResponseType;



        public class VariableInfoRest :BaseRestClient
        {
            private static ILog log =
      LogManager.GetLogger(
      System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
      );
            private XmlSerializer tsSerializer;

            

            public object GetResponseAsObject(object[] queryParameters)
            {
                /*
                 * there really is not any good way to test this.
                 * Everything comes back as tex/plain
                 * So, if the XML deserialier fails... well 
                 * */

                string url = createUrl(queryParameters);
                XmlReader reader = Utility.RestByUrl(url);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                 VariablesResponseType response;
                
                if (doc.GetElementsByTagName("variables",WaterOneFlowImpl.Constants.XML_SCHEMA_NAMSPACE).Count >0)
                {
                    try
                    {
                        //TextReader reader2 = new StringReader(doc.DocumentElement.OuterXml);
                        // response = (VariablesResponseType)tsSerializer.Deserialize(reader2);
                        response = new VariablesResponseType();
                        response.variables = FixVariablesResponse(doc);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(
                            "Error. Possible bad station or variable, or the  service could be down. It is hard to tell");

                    }   
                } else
                {
                    response = new VariablesResponseType();
                    response.variables = FixVariablesResponse(doc);
                }
               
                

                return response;
            }

            private VariableInfoType[] FixVariablesResponse(XmlDocument xdoc)
            {
                XmlRootAttribute root = new XmlRootAttribute("variable");
                Type[] types = new Type[0];
                XmlSerializer varSerializar = new XmlSerializer(typeof(VariableInfoType), null, types,root, WaterOneFlowImpl.Constants.XML_SCHEMA_NAMSPACE);
                List<VariableInfoType> vars = new List<VariableInfoType>();
                VariablesResponseType variablesResponseType = new VariablesResponseType();
                foreach (XmlNode v in xdoc.GetElementsByTagName("variable",WaterOneFlowImpl.Constants.XML_SCHEMA_NAMSPACE))
                {
                    try
                    {
                        TextReader reader = new StringReader(v.OuterXml);
                    

                    VariableInfoType variableInfoType = (VariableInfoType) varSerializar.Deserialize(reader);
                    vars.Add(variableInfoType);
                    } catch {
                    log.Debug("error serializing variable");
                }

            }
                return vars.ToArray();
            }

           
        }
    }
}

