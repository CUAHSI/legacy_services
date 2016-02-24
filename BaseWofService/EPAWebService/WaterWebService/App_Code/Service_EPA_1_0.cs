
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using log4net;


using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Services.Protocols;
using WaterOneFlow.Schema.v1;
using WaterOneFlow;



namespace WaterOneFlow.Service.EPA
{
    using WaterOneFlow.Service.v1_0;
    using WaterOneFlowImpl;
    using WaterOneFlow.Service.Source.v1_0;

    [WebService(Name = WsDescriptions.WsDefaultName,
Namespace = Constants.WS_NAMSPACE,
Description = WsDescriptions.WsDefaultDescription)]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
   
    public class Service_EPA_1_0 : Service_1_0
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(Service_DV_1_0));
        private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");
        private static readonly Logging queryLog2 = new Logging();

        //// protected WofService ODws;
        //protected NwisWOFService.GetValuesDailyUSGS dvSvc;
        ////protected NwisWOFService.GetDataInformationDailyDB ODws;
        //protected NwisWOFService.GetDataInformationDB ODws;

        //private Boolean useODForValues;
        //private Boolean requireAuthToken;



        public Service_EPA_1_0()
        {
            //log4net.Util.LogLog.InternalDebugging = true; 

            log.Info("Starting " + "EPA");
            //  ODws = new WofService(this.Context);//INFO we can extend this for other service types

            //ODws = new GetDataInformationDailyDB();
            ODws = new GetDataInformationDB();
            // WaterOneFlow.GenericDB DBws = (WaterOneFlow.GenericDB) ODws;

            ODws.VariableVocabulary = "EPA";
            ODws.SiteVocabulary = "EPA";
            // queryLog = new Logging(ODws.SiteVocabulary);

            // configure
            ConnectionStringSettings oddb = ConfigurationManager.ConnectionStrings["ODDB"];
            ODws.DataInfoConnection = oddb.ConnectionString;
            //ODws.VariablesTableName = "odm_variables";
            //ODws.SitesTableName = "sites";
            //ODws.SeriesTableName = "SeriesCatalog";
            ODws.VariablesTableName = "odm_variables";
           // ODws.SitesTableName = "ws_odm_sites";
            ODws.SitesTableName = "odm_sites";
           // ODws.SeriesTableName = "epa_SERIESCATALOG_no_medium";
            //ODws.SeriesTableName = "odm_SERIESCATALOG";
            ODws.SeriesTableName = "odm_SERIESCATALOG";

            //dvSvc = new GetValuesProxy();

            dvSvc = new EPAWOFService.GetValuesEPA(ODws);

         //   for when the new WaterOneFlow is ready
            //dvSvc = new WaterOneFlow.Service.values.v1_0.GetValuesXslt(
            //    ConfigurationManager.AppSettings["ServiceXmlUrl"]
            //    , ConfigurationManager.AppSettings["xsltName"]);



        }
    }
}