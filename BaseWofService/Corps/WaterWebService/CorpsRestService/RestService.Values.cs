using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using log4net;


namespace RestServiceClient
{
    namespace v1
    {
        using TimeSeriesResponse = WaterOneFlow.Schema.v1.TimeSeriesResponseType;

      

        public class TimeSeriesRest :BaseRestClient
        {
            private static ILog log =
      LogManager.GetLogger(
      System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
      );
            private XmlSerializer tsSerializer;

            private static string  baseUrl;
            private static string urlSitesFormat;
            private static string urlSiteInfoFormat;
            private static string urlValuesFormat;
            private static string urlVariableInforFormat;


            public TimeSeriesRest()
            {
                tsSerializer = new XmlSerializer(typeof(TimeSeriesResponse));
            }



            public Object GetResponseObject(object[] parameters)
            {
                /*
                 * there really is not any good way to test this.
                 * Everything comes back as tex/plain
                 * So, if the XML deserialier fails... well 
                 * */
                string outputFormat = "waterml";
                string url = createUrl(parameters);
                XmlReader reader = Utility.RestByUrl(url);
                TimeSeriesResponse response;
                try
                {

                    response = (TimeSeriesResponse)tsSerializer.Deserialize(reader);
                }
                catch
                {
                    throw new Exception(
                        "Error. Possible bad station or variable, or the  service could be down. It is hard to tell");

                }

                return response;
            }

           
         
        }
    }
}
