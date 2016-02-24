using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using WaterOneFlowImpl;

namespace WaterOneFlow.Nwis
{
    /// <summary>
    /// Utilities to provide URL services to the NWIS
    /// NWIS URL Generation
    /// local Server Base URL determination
    /// 
    /// </summary>
    public class NWISBaseUrl
    {
        public static string nwisDailyValues = "/NWIS/DailyValues.asmx";
        public static string nwisUnitValues = "/NWIS/UnitValues.asmx";
        public static string nwisIID = "/NWIS/Data.asmx";
        public static string nwisGW = "/NWIS/Groundwater.asmx";
/// <summary>
///  Generates the BasePath for an Application
/// 
/// For local URL service path generation
/// </summary>
/// <param name="context"></param>
/// <param name="removeLastDirectory"></param>
/// <returns></returns>
        public static Uri LocalServerBaseURL(HttpContext context, bool removeLastDirectory)
        {
            string scheme = "http";
            string host = context.Request.Url.Host;
            int port = context.Request.Url.Port;
    // the Application path contains the whole path at present, 
    // we want to remove the first directory
            string path = context.Request.ApplicationPath;
           if (removeLastDirectory)
           {
               path = path.Remove( path.LastIndexOf("/") );
           } 
            UriBuilder builder = new UriBuilder(scheme, host, port, path);
            return builder.Uri;

        }
  
    }
    
}
