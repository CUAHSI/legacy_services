using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using WaterOneFlow.Schema.v1;

namespace RestServiceClient
{
    public class BaseRestClient
    {  
#region
        private string baseUrl;
        private string pathFormat;
        private Type responseType;

        private XmlSerializer tsSerializer;

        public string BaseUrl
        {
            get
            {
                
                return baseUrl;
            }
            set { baseUrl = value; }
        }

        public string PathFormat
        {
            get
            {
                return pathFormat;
            }
            set{
                pathFormat = value;
            }
        }

        public Type ResponseType
        { get
        {
            return responseType;
        } set
        {
            responseType = value;
        }
        }
#endregion

#region XML Reeder
        public static XmlReader GetWaterML(string urlStringFormat, object[] queryParameters)
        {
             string url = createUrl(urlStringFormat, queryParameters); 
             XmlReader reader = Utility.RestByUrl(url);
            return reader;
        }

        public XmlReader GetWaterML(object[] queryParameters)
        {
            if (BaseUrl == null || PathFormat == null )
            { throw new ArgumentNullException("set BaseUrl and PathFormat");
            }
            string url = BaseUrl + PathFormat;
           XmlReader reader = GetWaterML(url, queryParameters);
            return reader;
        }
        public String createUrl ( object[] queryParameters)
        {
            string urlFormat = BaseUrl + PathFormat;
            return createUrl(urlFormat, queryParameters);
        }

        public static String createUrl(string urlStringFormat,  object[] queryParameters)
        {
            return String.Format(urlStringFormat, queryParameters);
        }
#endregion

#region return object
        public object GetResponseAsObject(object[] queryParameters)
        {
            if (ResponseType==null)
            {
                throw new ArgumentNullException("Set ResponseType");
            }

          
               XmlReader reader = GetWaterML(queryParameters);

            tsSerializer = new XmlSerializer(ResponseType);


            object response;
                try
                {

                    response = tsSerializer.Deserialize(reader);
                }
                catch (Exception exception)
                {
                    
                    throw new Exception(
                        "Error. Possible bad station or variable, or the  service could be down. It is hard to tell");

                }

                return response;
            }

        public object testValidation(XmlReader reader){
        tsSerializer = new XmlSerializer(ResponseType);


            object response;
                try
                {

                    response = tsSerializer.Deserialize(reader);
                }
                catch (Exception exception)
                {
                    
                    throw new Exception(
                        "Error. Possible bad station or variable, or the  service could be down. It is hard to tell");

                }
            return response;
            }
        }
#endregion
    }

