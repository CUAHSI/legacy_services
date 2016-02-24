
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using log4net;
using NwisWOFService.v1_0;
using NwisWOFService.v1_0.Passthrough;
using WaterOneFlow.Service.v1_0;

using WaterOneFlowImpl;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Services.Protocols;
using WaterOneFlow.Service;

using NwisWOFService;


namespace WaterOneFlow.Service
{
    namespace v1_0 {

         using GetDataInformationDB = NwisWOFService.v1_0.GetDataInformationDB;
     using WaterOneFlow.Service.v1_0.xsd; 
        using WaterOneFlow.Schema.v1;
        using DataTimeSeriesWofService = WaterOneFlow.Service.v1_0.DataTimeSeriesWofService;
        using WaterOneFlowImpl.v1_0;
        using IWaterOneFlowWebService = WaterOneFlow.Service.Services.v1_0.IWaterOneFlowWebService;
        using ServiceDescriptions = Constants.v1.ServiceDescriptions;

        //using WaterOneFlow.Service.Response.v1;
        using VariablesResponseTypeGeneric = WaterOneFlow.Service.Response.v1.VariablesResponseType;
        using SiteInfoResponseTypeGeneric = WaterOneFlow.Service.Response.v1.SiteInfoResponseType;
        using TimeSeriesResponseTypeGeneric = WaterOneFlow.Service.Response.v1.TimeSeriesResponseType;
        //using VariablesResponseTypeGeneric = WaterOneFlow.Service.Abstract.VariablesResponseType;
        //using SiteInfoResponseTypeGeneric = WaterOneFlow.Service.Abstract.SiteInfoResponseType;
        //using TimeSeriesResponseTypeGeneric = WaterOneFlow.Service.Abstract.TimeSeriesResponseType;

        //
        //using WaterOneFlow.Schema.v1;
        using VariablesResponseTypeObject = WaterOneFlow.Schema.v1.VariablesResponseType;
        using SiteInfoResponseTypeObject = WaterOneFlow.Schema.v1.SiteInfoResponseType;
        using TimeSeriesResponseTypeObject = WaterOneFlow.Schema.v1.TimeSeriesResponseType;


        using USGSwebService=NwisWOFService.gov.usgs.waterservices.unitvalues;
        
        using WaterOneFlow.Schema.v1;
        using WaterOneFlowImpl.v1_0;
        using WaterOneFlow.Service.v1_0;


        [WebService(Name = WsDescriptions.WsDefaultName,
    Namespace = WaterOneFlow.Service.Constants.v1.ServiceDescriptions.WS_NAMSPACE,
    Description = WsDescriptions.WsDefaultDescription)]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
      //  [SoapActor("*")]
        public class Service_UnitValues_WS_1_0 : Service_1_0
        {

          //private static readonly ILog log = LogManager.GetLogger(typeof(Service_DV_1_0));
            //private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");
            //private static readonly Logging queryLog2 = new Logging();

            //// protected WofService ODws;
            //protected NwisWOFService.GetValuesDailyUSGS dvSvc;
            ////protected NwisWOFService.GetDataInformationDailyDB ODws;
            //protected NwisWOFService.GetDataInformationDB ODws;

            //private Boolean useODForValues;
            //private Boolean requireAuthToken;



            public Service_UnitValues_WS_1_0()
            {
                //log4net.Util.LogLog.InternalDebugging = true; 

                //log.Info("Starting " + "NWISDV");
                //  ODws = new WofService(this.Context);//INFO we can extend this for other service types

                //ODws = new GetDataInformationDailyDB();
                ODws = new GetDataInformationDB();
                ODws.VariableVocabulary = "NWISUV";
                ODws.SiteVocabulary = "NWISUV";
                QueryLoggger = new Logging(ODws.SiteVocabulary);

                // configure
                ConnectionStringSettings oddb = ConfigurationManager.ConnectionStrings["ODDB"];
                ODws.DataInfoConnection = oddb.ConnectionString;
                ODws.VariablesTableName = "odm_uv_variables";
                ODws.SitesTableName = "odm_uv_sites";
                ODws.SeriesTableName = "odm_uv_SeriesCatalog";


             

                
               // dvSvc = new GetValuesUnitNWIS(ODws);
                dvSvc = new GetValuesUnitWebserviceUSGS();

            }

            /* need to override both mthods, since this actually does not return a
                    * a standard timeSeriesResponseType
                     * */
            [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
            public  string GetValues(string location, string variable, string startDate, string endDate, String authToken)
            {
                NWISUVTimeSeriesResponse aSite = (NWISUVTimeSeriesResponse)GetValuesObject(location, variable, startDate, endDate, null);

                XmlSerializer xs = new XmlSerializer(
                    typeof(NWISUVTimeSeriesResponse));
                StringBuilder xml = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(xml, NoDocument());


                xs.Serialize(writer, aSite);
                return xml.ToString();
            }

            [return: XmlElement(
         Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "timeSeriesResponse",
       IsNullable = false
                // , Type = typeof(NWISTimeSeriesResponse)
        , Type = typeof(TimeSeriesResponseTypeGeneric)
         )]
            [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
            public  object GetValuesObject(string location, string variable, string startDate, string endDate, String authToken)
            {
                if (!useODForValues)
                    throw new SoapException(
                        "GetValues implemented external to this service. Call GetSiteInfo, and SeriesCatalog includes the service Wsdl for GetValues. Attribute:serviceWsdl on Element:seriesCatalog XPath://seriesCatalog/[@serviceWsdl]",
                        new XmlQualifiedName("ServiceException"));

                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogValuesStart(Logging.Methods.GetValues, // method
                                         location, //location
                                         variable, //variable
                                         startDate, // startdate
                                         endDate, //enddate
                                         Context.Request.UserHostName);

                try
                {
                    WaterOneFlowImpl.locationParam lParam = new locationParam(location);
                    VariableParam vparam = new VariableParam(variable);
                    W3CDateTime? startDt = null;
                    W3CDateTime? endDt = null;
                    if (!String.IsNullOrEmpty(startDate)) startDt = new W3CDateTime(DateTime.Parse(startDate));
                    if (!String.IsNullOrEmpty(endDate)) endDt = new W3CDateTime(DateTime.Parse(endDate));


                   USGSwebService.TimeSeriesResponseType res =
    (USGSwebService.TimeSeriesResponseType)dvSvc.GetTimeSeries(lParam, vparam, startDt, endDt);

          if (res.timeSeries.values.value != null )   {
              queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                       location, //location
                                         variable, //variable
                                         startDate, // startdate
                                         endDate, //enddate
                       timer.ElapsedMilliseconds,
                       res.timeSeries.values.value.Length,
                       Context.Request.UserHostName);
          } else
          {
              queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                      location, //location
                                         variable, //variable
                                         startDate, // startdate
                                         endDate, //enddate
                      timer.ElapsedMilliseconds,
                     0,
                      Context.Request.UserHostName);
          }

                   return new NWISUVTimeSeriesResponse(res);// this one is an original class
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                                           location, //locaiton
                                           variable, //variable
                                           startDate, // startdate
                                           endDate, //enddate
                                           timer.ElapsedMilliseconds, // processing time
                                           -9999, // count 
                                           Context.Request.UserHostName
                        );
                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);
                }
            }
        }
    }
}