
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using log4net;
using WaterOneFlowImpl;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Services.Protocols;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Addressing;
using Microsoft.Web.Services3.Messaging;
using NwisWOFService;


namespace WaterOneFlow.Service
{
    namespace v1_0 {
using NwisWOFService.v1_0;
        using GetDataInformationDB = NwisWOFService.v1_0.GetDataInformationDB;
        using WaterOneFlow.Schema.v1;
        using DataTimeSeriesWofService = WaterOneFlow.Service.v1_0.DataTimeSeriesWofService;
        using WaterOneFlowImpl.v1_0;
        using GetValuesDataNWIS = NwisWOFService.v1_0.GetValuesDataNWIS;

        [WebService(Name = WsDescriptions.WsDefaultName, Namespace = Constants.WS_NAMSPACE, Description = WsDescriptions.WsDefaultDescription)]
        [WebServiceBinding(Name = WsDescriptions.WsDefaultName, ConformsTo = WsiProfiles.BasicProfile1_1)]
    //    [SoapActor("*")]
        public class Service_Data_1_0 : Service_1_0
        {
   
            public Service_Data_1_0()
            {
                ODws = new GetDataInformationDB();
                ODws.VariableVocabulary = "NWISIID";
                ODws.SiteVocabulary = "NWISIID";
                QueryLoggger = new Logging(ODws.SiteVocabulary);

                // configure
                ConnectionStringSettings oddb = ConfigurationManager.ConnectionStrings["ODDB"];
                ODws.DataInfoConnection = oddb.ConnectionString;
                ODws.VariablesTableName = "odm_qw_variables";
                ODws.SitesTableName = "odm_qw_sites";
                ODws.SeriesTableName = "odm_qw_SeriesCatalog";

                dvSvc = new GetValuesDataNWIS(ODws, ConfigurationManager.AppSettings["USGSDataUrl"]);


 
            }
        }
    

    }
}