
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

using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Addressing;
//using Microsoft.Web.Services3.Messaging;

using WaterOneFlowImpl;


namespace WaterOneFlow.Service
{
    namespace v1_0
    {
        using NwisWOFService.v1_0;
        using GetDataInformationDB = NwisWOFService.v1_0.GetDataInformationDB;
        using WaterOneFlow.Service.Response.v1;

        using DataTimeSeriesWofService = WaterOneFlow.Service.v1_0.DataTimeSeriesWofService;
        using WaterOneFlowImpl.v1_0;

        [WebService(Name = WsDescriptions.WsDefaultName, Namespace = Constants.WS_NAMSPACE, Description = WsDescriptions.WsDefaultDescription)]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
       // [SoapActor("*")]
        public class Service_Groundwater_1_0 : Service_1_0
        {



            public Service_Groundwater_1_0()
            {
                //log4net.Util.LogLog.InternalDebugging = true; 

                //log.Info("Starting " + "NWISDV");
                //  ODws = new WofService(this.Context);//INFO we can extend this for other service types

                //ODws = new GetDataInformationDailyDB();
                ODws = new GetDataInformationDB();
                ODws.VariableVocabulary = "NWISGW";
                ODws.SiteVocabulary = "NWISGW";
                QueryLoggger = new Logging(ODws.SiteVocabulary);

                // configure
                ConnectionStringSettings oddb = ConfigurationManager.ConnectionStrings["ODDB"];
                ODws.DataInfoConnection = oddb.ConnectionString;
                ODws.VariablesTableName = "odm_gw_variables";
                ODws.SitesTableName = "gw_flatfile";
                ODws.SeriesTableName = "gw_flatfile";

                dvSvc = new GetValuesGWNWIS(ODws, ConfigurationManager.AppSettings["USGSGWUrl"]);




            }
        }
    }
}