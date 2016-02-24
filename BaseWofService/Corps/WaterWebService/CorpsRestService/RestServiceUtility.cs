using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using log4net;
using WaterOneFlowImpl;

namespace RestServiceClient
{
    public class Utility
    {
        
        private static ILog log =
           LogManager.GetLogger(
           System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
           );


        public static XmlReader RestByUrl(String UrlPath)
        {
            String requestUrl =
                String.Format("{0}", UrlPath);
            log.Info("Request URL: " + requestUrl);
            StreamReader resultReader = GetHTTPFile(requestUrl, 10);

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.CheckCharacters = false;
            settings.IgnoreWhitespace = true;
            XmlReader xmlReader = XmlReader.Create(resultReader, settings);

            return xmlReader;
        }

        public static StreamReader GetHTTPFile(string strURL, int SecondsToRespond)
        {
            Encoding encode = Encoding.GetEncoding("utf-8");
            WebRequest myWebRequest = WebRequest.Create(strURL);
#if DEBUG
            HttpWebRequest aRequest = myWebRequest as HttpWebRequest;
            if (aRequest != null)
                log.Info("Answering IPAddress: " + (aRequest).Address.OriginalString);
#endif
            myWebRequest.Timeout = SecondsToRespond * 10000;
            HttpWebResponse myWebResponse;
            myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            if (log.IsDebugEnabled) log.Debug("HTTP Status Code: " + myWebResponse.StatusCode);

            
            if (myWebResponse.StatusCode != HttpStatusCode.OK)
            {
                switch (myWebResponse.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        throw new WaterOneFlowSourceException("Error  Service returned HTTP Status Code: " + myWebResponse.StatusCode);

                        default:
                            throw new WaterOneFlowSourceException("Error  Service returned HTTP Status Code: " + myWebResponse.StatusCode);

                }
}
            //if (myWebResponse.ContentType.StartsWith(@"text/html"))
            //    throw new WebException("Bad response from external resource. Requested Service URL: '" + strURL + "'");
            Stream receiveStream1 = myWebResponse.GetResponseStream();

            StreamReader readStream = new StreamReader(receiveStream1, encode);

 
            return readStream;


        }
    }
}
