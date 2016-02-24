using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace NCDC
{
   
    namespace RestService{
    public class Sites
    {
        private static string NCDC = Properties.Settings.Default.BaseURL;

        static XmlTextReader SitesByUrl(String UrlPath, String OuputFormat, String Token)
        {
            
        }

        /// <summary>
        /// Returns the XMl version of the sites
        /// </summary>
        /// <param name="Country"></param>
        /// <param name="Token"></param>
        /// <returns></returns>
        static XmlTextReader SitesByCountry(String Country, String Token)
        {
            
        }

        private static string UrlPathByCountry(String Country, String Token)
        {
            
        }

        private static string OutputFormatParameter(String OutputFormat)
        {
            return String.Format(Properties.Settings.Default., OutputFormat);
        }
        private static string TokenParameter(String Token)
        {
            return String.Format("&token={0}", Token);
        }
    }
    }
}
