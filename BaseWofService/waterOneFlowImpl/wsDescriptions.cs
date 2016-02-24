using System;
using System.Collections.Generic;
using System.Text;

namespace WaterOneFlowImpl
{
   public class WsDescriptions
    {
        //TODO add basic descriptions
        public const string WsDefaultDescription = "";

       /// <summary>
       /// The name of the base Soap Port,
        /// <para> should be 'WaterOneFlow"</para>
       /// </summary>
       /// <example>[WebServiceBinding(Name = WsDescriptions.WsDefaultName,
       ///     ConformsTo = WsiProfiles.BasicProfile1_1,
       /// Namespace = ServiceDescriptions.WS_NAMSPACE )]
       /// </example>
        public const string WsDefaultName = "WaterOneFlow";
       public const string GetValuesDefaultDesc = "Given a site number, a variable, a start date, and an end date, this method returns a time series. Pass in the sitecode and variable in this format: 'NetworkName:SiteCode' and 'NetworkName:Variable'. Sending a null BeginDate and EndDate will return all values for the given parameters. This may not work with all services.";

       public const string GetValuesObjectDefaultDesc = "Given a site number, a variable, a start date, and an end date, this method returns a time series. Pass in the sitecode and variable in this format: 'NetworkName:SiteCode' and 'NetworkName:Variable'. Sending a null BeginDate and EndDate will return all values for the given parameters. This may not work with all services.";
       public const string GetSiteInfoDefaultDesc = "Given a site number, this method returns the site's metadata. Send the site code in this format: 'NetworkName:SiteCode'";
       public const string GetSiteInfoObjectDefaultDesc = "Given a site number, this method returns the site's metadata. Send the site code in this format: 'NetworkName:SiteCode'";
       public const string GetVariableInfoDefaultDesc = "Given a variable code, this method returns the variable's name. Pass in the variable in this format: 'NetworkName:Variable'. Sending no variable, or an empty variable will return a list of all variables.";
       public const string GetVariableInfoObjectDefaultDesc = "Given a variable code, this method returns the variable's siteName. Pass in the variable in this format: 'NetworkName:Variable'. Sending no variable, or an empty variable will return a list of all variables.";
       public const string GetSitesDefaultDesc = "Given an array of site numbers, this method returns the site metadata for each one. Send the array of site codes in this format: 'NetworkName:SiteCode'. Sending an empty array will return all sites, up to a limit of 50,000.";

       // web service descriptions text  are in the wsDescriptions

       // terms for tagging services as DEVELOPMENTAL
       public const string SvcDevelopementalWarning = "<div><strong>Developmental service. This service is internal CUAHSI use, and evaluation.</strong></div>";
       public const string SvcProvisionalWarning = "<div><strong>Provisional service. This service is stable, but has not been approved. This service may not be feature complete.</strong></div>";
       /// <summary>
       /// A Web service has been deemed production quality.
       /// Placing this value in the WebService attribute tells developers that the code is production quality.
       /// Note: This should only be seen on production branches, and not on the tree.
       /// </summary>
       public const string SvcProductionWarning = "";  // Placing this value in the service says that it is production quality.

       // I AM NOT REALLY SURE IF METHODS ARE NEEDED. But here they are.

       /// <summary>
       /// 
       /// </summary>
       public const string MthdDevelopemental = "<div><strong>Development method. This method is internal CUAHSI use, and evaluation.</strong>></div>";
       /// <summary>
       /// 
       /// </summary>
       public const string MthdProvisional = "<div><strong>Provisional method. This service is stable, but has not been approved. This service may not be feature complete.</strong></div>";

       /// <summary>
       /// A Web method has been deemed production quality.
       /// Placing this value in the WebService attribute tells developers that the code is production quality.
       /// Note: This should only be seen on produciton branches, and not on the tree.
       /// </summary>     
       public const string MthdProduction = ""; // Placing this value in the service says that it is production quality.
   }
}
