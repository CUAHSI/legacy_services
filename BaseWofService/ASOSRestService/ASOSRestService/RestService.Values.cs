using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using log4net;
 

namespace NCDC.RestService
{
    namespace v1 {
    using TimeSeriesResponse=WaterOneFlow.Schema.v1.TimeSeriesResponseType;

        using Properties = NCDC.RestService.Properties;

    public class TimeSeries
    {
        private static ILog log =
  LogManager.GetLogger(
  System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
  );
        private XmlSerializer tsSerializer;

        public  TimeSeries()
    {
        tsSerializer = new XmlSerializer( typeof(TimeSeriesResponse) );
    }
        
        public  TimeSeriesResponse GetNCDCParitalResponse(string NCDCSiteCode, string NCDCVariableCode, string BeginDate, string endDate, string token, string NCDCDataSource)
        {
            /*
             * there really is not any good way to test this.
             * Everything comes back as tex/plain
             * So, if the XML deserialier fails... well 
             * */
            string outputFormat = "waterml";
            string url = UrlByStationVariable(NCDCSiteCode, NCDCVariableCode, BeginDate, endDate, NCDCDataSource);
            XmlReader isdreder = Utility.RestByUrl(url, outputFormat, token);
            TimeSeriesResponse response;
            try
          {
                
                response =  (TimeSeriesResponse) tsSerializer.Deserialize(isdreder);
          } catch
          {
              throw new Exception(
                  "Error. Possible bad station or variable, or the NCDC service could be down. It is hard to tell");
              
          }

            return response;
        }

        public static string ISDUrlByStationVariable(string NCDCSiteCode, string NCDCVariableCode, string BeginDate, string endDate)
        {
            return UrlByStationVariable(NCDCSiteCode, NCDCVariableCode, BeginDate, endDate, "ish");
        }

        public static string UrlByStationVariable(string NCDCSiteCode, string NCDCVariableCode, string BeginDate, string endDate, string NCDCDataSource)
        {
            /*
             http://www7.ncdc.noaa.gov/rest/services/values/datasetId/stationId/variableId/{startDate}/{endDate}
http://www7.ncdc.noaa.gov/rest/services/values/isd/72584523225/CIG/20080101/20080131/?output=waterml
*/ 
             string UrlFormat = Properties.Settings.Default.BaseURL
                + "values/{0}/{1}/{2}/";

             string url = String.Format(UrlFormat, NCDCDataSource, NCDCSiteCode, NCDCVariableCode);
            if (!String.IsNullOrEmpty(BeginDate))
            {
                const string dateUrlFormat = "{0}/";
                url += String.Format(dateUrlFormat, BeginDate);
                // I do not think that only endDate is an acceptable NCDC parameter.
                if (!String.IsNullOrEmpty(endDate))
                {
                    url += String.Format(dateUrlFormat, endDate);
                }
            }
            return url;
        }
    }
    }
}
