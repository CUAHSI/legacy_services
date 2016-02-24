using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using log4net;
using WaterOneFlowImpl;

namespace NCDC.RestService.v1
{
    public class Utility
    {
        public const string WaterMlNs = "http://www.cuahsi.org/waterML/1.0/";
        public static string DatasetIDToCode(string DataSetID)
        {
            switch (DataSetID)
            {
                case "30":
                    return "daily";
                case "10":
                    return "isd";
                case "11":
                    return "ish";
                default:
                    throw new ArgumentException("Unkonwn DatasetId " + DataSetID);
            }


        }

        private static ILog log =
            LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
            );


        public static XmlReader RestByUrl(String UrlPath, String OutputFormat, String Token)
        {
            String requestUrl =
                String.Format("{0}?{1}&{2}", UrlPath,
                OutputFormatParameter(OutputFormat),
                TokenParameter(Token));
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
            if (log.IsDebugEnabled) log.Debug("HTTP Status Code: "+myWebResponse.StatusCode);
          
            // As of Jul 2008, NCDC Always returns 200 OK.
            if (myWebResponse.StatusCode != HttpStatusCode.OK)
                throw new WaterOneFlowSourceException("Error NCDC Service returned HTTP Status Code: " + myWebResponse.StatusCode);

            if (myWebResponse.ContentType.StartsWith(@"text/html"))
                throw new WebException("Bad response from external resource. Requested Service URL: '" + strURL + "'");
            Stream ReceiveStream = myWebResponse.GetResponseStream();

            StreamReader readStream = new StreamReader(ReceiveStream, encode);

           /* two Failed attempts to insert a filter to fix the unencoded ampersands in the stream
            * - both failed when the XMLreader complained that the first line was not 
            * a proper XML file
            * */
            //Stream filterStream = new Filter.AmpersandFilterStream(ReceiveStream);
            //StreamReader readStream = new StreamReader(filterStream, encode);

            //  string readString = readStream.ReadToEnd();
            //readString= readString.Replace("&", "&amp;");
            //  MemoryStream mem = new MemoryStream(Encoding.Unicode.GetBytes(readString));
            //  readStream = new StreamReader(mem);

            return readStream;


        }

        private static string OutputFormatParameter(String OutputFormat)
        {
            return String.Format("output={0}", OutputFormat);
        }

        private static string TokenParameter(String Token)
        {
            return String.Format("token={0}", Token);
        }

    }
}
