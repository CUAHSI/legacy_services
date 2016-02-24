
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using GaDotNet.Common;
using GaDotNet.Common.Data;
using GaDotNet.Common.Helpers;

using log4net;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Services.Protocols;
using NwisWOFService.v1_0;
using NwisWOFService.v1_0.Passthrough;
using WaterOneFlow.Service;

using WaterOneFlow.Service.Constants.v1;
using WaterOneFlowImpl;
using WaterOneFlow.Service.v1_0.xsd;
namespace WaterOneFlow.Service
{

    namespace v1_0
    {
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


        using USGSwebService = NwisWOFService.gov.usgs.waterservices.unitvalues;

        using WaterOneFlow.Schema.v1;
        using WaterOneFlowImpl.v1_0;
        using WaterOneFlow.Service.v1_0;


        [WebService(Name = WsDescriptions.WsDefaultName, Namespace = WaterOneFlow.Service.Constants.v1.ServiceDescriptions.WS_NAMSPACE, Description = WsDescriptions.WsDefaultDescription)]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1), System.Web.Services.Protocols.SoapDocumentService()]
        //[SoapActor("*")]
        public class Service_DailyValues_1_0 : Service_1_0
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



            public Service_DailyValues_1_0()
            {
                //log4net.Util.LogLog.InternalDebugging = true; 

                //log.Info("Starting " + "NWISDV");
                //  ODws = new WofService(this.Context);//INFO we can extend this for other service types
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("SeriesType", TimeSeriesTypeEnum.Interval);
                // set in db view
               // parameters.Add("MaxRealTimePeriod", ConfigurationManager.AppSettings["USGSUVdays"]);

                //ODws = new GetDataInformationDailyDB();
                ODws = new GetDataInformationDB();
                ODws.Parameters = parameters;
                ODws.VariableVocabulary = "NWISDV";
                ODws.SiteVocabulary = "NWISDV";
                QueryLoggger = new Logging(ODws.SiteVocabulary);

                // configure
                ConnectionStringSettings oddb = ConfigurationManager.ConnectionStrings["ODDB"];
                ODws.DataInfoConnection = oddb.ConnectionString;
                ODws.VariablesTableName = "odm_dv_variables";
                ODws.SitesTableName = "odm_dv_sites";
                ODws.SeriesTableName = "odm_dv_Series";
                ODws.UseVariableCodeMatch = true; //use full variable name
                ODws.UseSitesCodeMatch = true;



                // dvSvc = new GetValuesUnitNWIS(ODws);
                // dvSvc = new GetValuesUnitWebserviceUSGS();
                //  dvSvc = new GetValuesUnitRestUSGS(ConfigurationManager.AppSettings["USGSUVUrl"]);
                dvSvc = new GetValuesDailyRESTUSGS_11to10(ConfigurationManager.AppSettings["USGSDVUrl"]
                    , 
                     ConfigurationManager.AppSettings["USGSDVxlst"]);
            }

            /* need to override both mthods, since this actually does not return a
                    * a standard timeSeriesResponseType
                     * */
            [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
            public string GetValues(string location, string variable, string startDate, string endDate, String authToken)
            {
                //NWISUVTimeSeriesResponse aSite = (NWISUVTimeSeriesResponse)GetValuesObject(location, variable, startDate, endDate, null);

                //XmlSerializer xs = new XmlSerializer(
                //    typeof(NWISUVTimeSeriesResponse));
                TimeSeriesResponseTypeGeneric aSite = (TimeSeriesResponseTypeGeneric)GetValuesObject(location, variable, startDate, endDate, null);
                XmlRootAttribute tsrRoot = new XmlRootAttribute("timeSeriesResponse");
                Type[] xsdTypes = new Type[1];
                xsdTypes[0] = typeof(WaterOneFlow.Service.v1_0.xsd.TimeSeriesResponse);
                XmlSerializer xs = new XmlSerializer(typeof(TimeSeriesResponseTypeGeneric),
                    null,
                    xsdTypes,
                    tsrRoot, WaterOneFlowImpl.v1_0.Constants.XML_SCHEMA_NAMSPACE);

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
            public object GetValuesObject(string location, string variable, string startDate, string endDate, String authToken)
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
                    int estimateCount =0;
                    if (!String.IsNullOrEmpty(startDate)) startDt = new W3CDateTime(DateTime.Parse(startDate));
                    if (!String.IsNullOrEmpty(endDate)) endDt = new W3CDateTime(DateTime.Parse(endDate));

                    try
                    {
                        if (startDt.HasValue && endDt.HasValue)
                        {
                            estimateCount = (endDt.Value - startDt.Value).Hours*4;
                            log.DebugFormat("{0}/{1}:estimated count: {2}", endDt.Value, startDt.Value, estimateCount);
                        }
                    }
                    catch
                    {

                    }
                    //               USGSwebService.TimeSeriesResponseType res =
                    //(USGSwebService.TimeSeriesResponseType)dvSvc.GetTimeSeries(lParam, vparam, startDt, endDt);
                    TimeSeriesResponseType res =
                    (TimeSeriesResponseType)dvSvc.GetTimeSeries(lParam, vparam, startDt, endDt);

                    if (res.timeSeries != null
                        && res.timeSeries.values != null 
                        && res.timeSeries.values.value != null)
                    {
                        queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                                 location, //location
                                                   variable, //variable
                                                   startDate, // startdate
                                                   endDate, //enddate
                                 timer.ElapsedMilliseconds,
                                 res.timeSeries.values.value.Length,
                                 Context.Request.UserHostName);
                    }
                    else
                    {
                        queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                                location, //location
                                                   variable, //variable
                                                   startDate, // startdate
                                                   endDate, //enddate
                                timer.ElapsedMilliseconds,
                               estimateCount,
                                Context.Request.UserHostName);
                    }

                    // return new NWISUVTimeSeriesResponse(res);// this one is an original class
                    TrackEvent(location, variable, startDate, endDate, estimateCount, Context);
                    return new WaterOneFlow.Service.v1_0.xsd.TimeSeriesResponse(res);
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    TrackEvent(location, variable, startDate, endDate, null, Context);
                    //queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                    //                       location, //locaiton
                    //                       variable, //variable
                    //                       startDate, // startdate
                    //                       endDate, //enddate
                    //                       timer.ElapsedMilliseconds, // processing time
                    //                       -9999, // count 
                    //                       Context.Request.UserHostName
                    //    );
                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);
                }
            }
            private static void TrackEvent(string location, string variable, string startDate, string endDate, int? count, HttpContext httpContext)
            {

                try
                {
                    GoogleEvent googleEvent = new GoogleEvent("river.sdsc.edu",
                    "NWISUV",
                    "GetValuesObject",
                    String.Format("{0}|{1}|{2}|{3}",
                    location, variable, startDate, endDate),
                    count
                    );

                    TrackingRequest request =
                        new RequestFactory().BuildRequest(googleEvent, httpContext);

                    request.RequestedByIpAddress = httpContext.Request.UserHostAddress;


                    GoogleTracking.FireTrackingEvent(request);
                }
                catch
                {
                    return;
                }
            }
        }
    }
}

//namespace WaterOneFlow.Service
//{

//    namespace v1_0
//    {

//        using GetDataInformationDB = NwisWOFService.v1_0.GetDataInformationDB;
//        using WaterOneFlow.Schema.v1;
//        using DataTimeSeriesWofService = WaterOneFlow.Service.v1_0.DataTimeSeriesWofService;
//        using WaterOneFlowImpl.v1_0;
//        using IWaterOneFlowWebService = WaterOneFlow.Service.Services.v1_0.IWaterOneFlowWebService;
//        using ServiceDescriptions = Constants.v1.ServiceDescriptions;

//        //using WaterOneFlow.Service.Response.v1;
//        using VariablesResponseTypeGeneric = WaterOneFlow.Service.Response.v1.VariablesResponseType;
//        using SiteInfoResponseTypeGeneric = WaterOneFlow.Service.Response.v1.SiteInfoResponseType;
//        using TimeSeriesResponseTypeGeneric = WaterOneFlow.Service.Response.v1.TimeSeriesResponseType;
//        //using VariablesResponseTypeGeneric = WaterOneFlow.Service.Abstract.VariablesResponseType;
//        //using SiteInfoResponseTypeGeneric = WaterOneFlow.Service.Abstract.SiteInfoResponseType;
//        //using TimeSeriesResponseTypeGeneric = WaterOneFlow.Service.Abstract.TimeSeriesResponseType;

//        //
//        //using WaterOneFlow.Schema.v1;
//        using VariablesResponseTypeObject = WaterOneFlow.Schema.v1.VariablesResponseType;
//        using SiteInfoResponseTypeObject = WaterOneFlow.Schema.v1.SiteInfoResponseType;
//        using TimeSeriesResponseTypeObject = WaterOneFlow.Schema.v1.TimeSeriesResponseType;

//        using NwisWOFService.v1_0;

//        using USGSwebService = NwisWOFService.gov.usgs.nwis.dailyValues;

//        [WebService(Name = WsDescriptions.WsDefaultName, Namespace = Constants.WS_NAMSPACE, Description = WsDescriptions.WsDefaultDescription)]
//        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1),
//         System.Web.Services.Protocols.SoapDocumentService()]
//        //  [SoapActor("*")]
//        public class Service_DV_1_0 : Service_1_0
//        {



//            public Service_DV_1_0()
//            {
//                //log4net.Util.LogLog.InternalDebugging = true; 

//                //log.Info("Starting " + "NWISDV");
//                //  ODws = new WofService(this.Context);//INFO we can extend this for other service types

//                //ODws = new GetDataInformationDailyDB();
//                ODws = new GetDataInformationDB();
//                ODws.VariableVocabulary = "NWISDV";
//                ODws.SiteVocabulary = "NWISDV";
//                QueryLoggger = new Logging(ODws.SiteVocabulary);

//                // configure
//                ConnectionStringSettings oddb = ConfigurationManager.ConnectionStrings["ODDB"];
//                ODws.DataInfoConnection = oddb.ConnectionString;
//                ODws.VariablesTableName = "odm_dv_variables";
//                ODws.SitesTableName = "odm_dv_sites";
//                ODws.SeriesTableName = "odm_dv_SeriesCatalog";
//                ODws.UseVariableCodeMatch = true;

//                // dvSvc = new GetValuesDailyUSGS(ConfigurationManager.AppSettings["USGSDVUrl"]);
//                dvSvc = new GetValuesDVRESTUSGS_xslt(ConfigurationManager.AppSettings["USGSDVUrl"]
//                   , ConfigurationManager.AppSettings["USGSDVxlst"]);

//                //    #endregion
//            }

//            /* need to override both mthods, since this actually does not return a
//            * a standard timeSeriesResponseType
//             * */
//            [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
//            public  string GetValues(string location, string variable, string startDate, string endDate, String authToken)
//            {
//                TimeSeriesResponseTypeGeneric aSite = (TimeSeriesResponseTypeGeneric)GetValuesObject(location, variable, startDate, endDate, null);
//                XmlRootAttribute tsrRoot = new XmlRootAttribute("timeSeriesResponse");
//                Type[] xsdTypes = new Type[1];
//                xsdTypes[0] = typeof(WaterOneFlow.Service.v1_0.xsd.TimeSeriesResponse);
//                XmlSerializer xs = new XmlSerializer(typeof(TimeSeriesResponseTypeGeneric),
//                    null,
//                    xsdTypes,
//                    tsrRoot, WaterOneFlowImpl.v1_0.Constants.XML_SCHEMA_NAMSPACE);

//                StringBuilder xml = new StringBuilder();
//                XmlWriter writer = XmlWriter.Create(xml, NoDocument());


//                xs.Serialize(writer, aSite);
//                return xml.ToString();
//            }

//            /*
//            * override the standard MethodAccessException 
//                */
//            [return: XmlElement(
//            Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
//ElementName = "timeSeriesResponse",
//          IsNullable = false
//                // , Type = typeof(NWISTimeSeriesResponse)
//           , Type = typeof(TimeSeriesResponseTypeGeneric)
//            )]
//            [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
//            public  object GetValuesObject(string location, string variable, string startDate, string endDate, String authToken)
//            {
//                if (!useODForValues) throw new SoapException("GetValues implemented external to this service. Call GetSiteInfo, and SeriesCatalog includes the service Wsdl for GetValues. Attribute:serviceWsdl on Element:seriesCatalog XPath://seriesCatalog/[@serviceWsdl]", new XmlQualifiedName("ServiceException"));



//                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
//                queryLog2.LogValuesStart(Logging.Methods.GetValues, // method
//                            location, //location
//                            variable, //variable
//                            startDate, // startdate
//                            startDate, //enddate
//                            Context.Request.UserHostName);

//                try
//                {
//                    WaterOneFlowImpl.locationParam lParam = new locationParam(location);
//                    VariableParam vparam = new VariableParam(variable);
//                    W3CDateTime? startDt = null;
//                    W3CDateTime? endDt = null;
//                    if (!String.IsNullOrEmpty(startDate)) startDt = new W3CDateTime(DateTime.Parse(startDate));
//                    if (!String.IsNullOrEmpty(endDate)) endDt = new W3CDateTime(DateTime.Parse(endDate));


//                    TimeSeriesResponseType res =
//    (TimeSeriesResponseType)dvSvc.GetTimeSeries(lParam, vparam, startDt, endDt);
//                    int days = 0;
//                    try
//                    {
//                        if (startDt.HasValue && endDt.HasValue)
//                        {
//                            days = (endDt.Value - startDt.Value).Days;
//                            log.DebugFormat("{0}/{1}:estimated count: {2}", endDt.Value, startDt.Value, days);
//                        }
//                        else
//                        {
//                            log.DebugFormat("open date range: no estimated count: ");
//                        }
//                    }
//                    catch
//                    {
                        
//                    }

//                    if (res != null && res.timeSeries != null &&
//                        res.timeSeries.values != null)
//                    {
//                        queryLog2.LogEnd(Logging.Methods.GetValues,
//                                         location,
//                                         timer.ElapsedMilliseconds.ToString(),
//                                         res.timeSeries.values.value.Length.ToString(),
//                                         Context.Request.UserHostName);
//                        TrackEvent(location, variable, startDate, endDate, null, Context);

//                    }
//                    else
//                    {

//                        queryLog2.LogEnd(Logging.Methods.GetValues,
//                                         location,
//                                         timer.ElapsedMilliseconds.ToString(),
//                                         days.ToString(),
//                                         Context.Request.UserHostName);
//                        TrackEvent(location, variable, startDate, endDate, days, Context);
//                    }

//                    // return new NWISTimeSeriesResponse(res);

//                    return new WaterOneFlow.Service.v1_0.xsd.TimeSeriesResponse(res);

//                }
//                catch (Exception we)
//                {
//                    log.Warn(we.Message);
//                    queryLog2.LogValuesEnd(Logging.Methods.GetValues,
//                                location, //locaiton
//                                variable, //variable
//                                startDate, // startdate
//                                startDate, //enddate
//                                timer.ElapsedMilliseconds, // processing time
//                                -9999, // count 
//                                Context.Request.UserHostName
//                                );
//                    TrackEvent(location, variable, startDate, endDate, null, Context);
//                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

//                }

//            }
//            private static void TrackEvent(string location, string variable, string startDate, string endDate, int? count, HttpContext httpContext)
//            {

//                try
//                {
//                    GoogleEvent googleEvent = new GoogleEvent("river.sdsc.edu",
//                                                              "NWISDV",
//                                                              "GetValuesObject",
//                                                              String.Format("{0}|{1}|{2}|{3}",
//                                                                            location, variable, startDate, endDate),
//                                                              count
//                        );


//                    TrackingRequest request =
//                        new RequestFactory().BuildRequest(googleEvent, httpContext);

//                    request.RequestedByIpAddress = httpContext.Request.UserHostAddress;
//                    log.Info("userIP:" + httpContext.Request.UserHostAddress);
//                    log.Info("userHost:" + httpContext.Request.UserHostName);

//                    GoogleTracking.FireTrackingEvent(request);
//                }
//                catch
//                {
//                    return;
//                }
//            }
//        }


//    }
//}