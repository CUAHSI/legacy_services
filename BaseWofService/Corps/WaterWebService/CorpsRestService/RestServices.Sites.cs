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



namespace RestServiceClient
{
    namespace v1
    {
        using SiteInfoResponseType = WaterOneFlow.Schema.v1.SiteInfoResponseType;



        public class SiteInfo
        {
            private static ILog log =
      LogManager.GetLogger(
      System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
      );
            private XmlSerializer tsSerializer;

            private static string baseUrl;
            private static string urlSitesFormat;
            private static string urlSiteInfoFormat;
            private static string urlValuesFormat;
            private static string urlVariableInforFormat;


            public SiteInfo()
            {
                tsSerializer = new XmlSerializer(typeof(SiteInfoResponseType));
            }

            #region
            public static string BaseUrl
            {
                get { return baseUrl; }
                set { baseUrl = value; }
            }

            public static string UrlSitesFormat
            {
                get { return urlSitesFormat; }
                set { urlSitesFormat = value; }
            }

            public static string UrlSiteInfoFormat
            {
                get { return urlSiteInfoFormat; }
                set { urlSiteInfoFormat = value; }
            }

            public static string UrlValuesFormat
            {
                get { return urlValuesFormat; }
                set { urlValuesFormat = value; }
            }

            public static string UrlVariableInforFormat
            {
                get { return urlVariableInforFormat; }
                set { urlVariableInforFormat = value; }
            }
            #endregion

            public SiteInfoResponseType GetParitalResponse(string siteCode, string variableCode, string beginDate, string endDate, string token)
            {
                /*
                 * there really is not any good way to test this.
                 * Everything comes back as tex/plain
                 * So, if the XML deserialier fails... well 
                 * */
                string outputFormat = "waterml";
                string url = UrlByStation(siteCode);
                XmlReader reader = Utility.RestByUrl(url);
                SiteInfoResponseType response;
                try
                {

                    response = (SiteInfoResponseType)tsSerializer.Deserialize(reader);
                }
                catch
                {
                    throw new Exception(
                        "Error. Possible bad station or variable, or the  service could be down. It is hard to tell");

                }

                return response;
            }


            public static string UrlByStation(string SiteCode)
            {
                 string UrlFormat = BaseUrl
                   + urlSitesFormat;

                string url = String.Format(UrlFormat, SiteCode);
               
                return url;
            }
        }
    }
}

