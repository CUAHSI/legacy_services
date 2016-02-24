
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
using Microsoft.Web.Services3.Messaging;

using WaterOneFlow.Service;
using WaterOneFlow.Service.Services.v1_0;
using WaterOneFlow.Service.Source.v1_0;
using WaterOneFlowImpl;

namespace WaterOneFlow.Service
{
    namespace v1_0
    {
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
   
       
        using WaterOneFlow.Schema.v1;

        using WaterOneFlowImpl.v1_0;

        [WebService(Name = WsDescriptions.WsDefaultName,
    Namespace = Constants.WS_NAMSPACE,
    Description = WsDescriptions.WsDefaultDescription)]
       // [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [SoapActor("*")]
    //    public class Service_1_0 : WebService, IService_1_0
        public class Service_1_0 : IWaterOneFlowWebService
        {
            protected static readonly ILog log = LogManager.GetLogger(typeof(Service_1_0));
            protected static readonly ILog queryLog = LogManager.GetLogger("QueryLog");
            protected static Logging queryLog2 = new Logging();

            public static Logging QueryLoggger
            {
                get { return Service_1_0.queryLog2; }
                set { Service_1_0.queryLog2 = value; }
            }


            // protected WofService ODws;
            protected DataTimeSeriesWofService dvSvc;
            //protected NwisWOFService.GetDataInformationDailyDB ODws;
            protected GetDataInformationDB ODws;

            protected Boolean useODForValues;
            protected Boolean requireAuthToken;


            /// <summary>
            /// Extend this class, and implement the constructor
            /// The constructor will be called before the child classes constructor.
            /// </summary>
            public Service_1_0()
            {
                //log4net.Util.LogLog.InternalDebugging = true; 

                //log.Info("Starting " + "NWIS Service Super Class");
                ////  ODws = new WofService(this.Context);//INFO we can extend this for other service types

                ////ODws = new GetDataInformationDailyDB();
                //ODws = new GetDataInformationDB();
                //// configure
                //ConnectionStringSettings oddb = ConfigurationManager.ConnectionStrings["ODDB"];
                //ODws.DataInfoConnection = oddb.ConnectionString;
                //ODws.VariablesTableName = "odm_dv_variables";
                //ODws.SitesTableName = "odm_dv_sites";
                //ODws.SeriesTableName = "odm_dv_SeriesCatalog";

                //dvSvc = new GetValuesDailyUSGS();

                try
                {
                    useODForValues = Boolean.Parse(ConfigurationManager.AppSettings["UseODForValues"]);
                }
                catch (Exception e)
                {
                    String error = "Missing or invalid value for UseODForValues. Must be true or false";
                    log.Fatal(error);

                    throw new SoapException("Invalid Server Configuration. " + error,
                                         new XmlQualifiedName(SoapExceptionGenerator.ServerError));
                }

                try
                {
                    requireAuthToken = Boolean.Parse(ConfigurationManager.AppSettings["requireAuthToken"]);
                }
                catch (Exception e)
                {
                    String error = "Missing or invalid value for requireAuthToken. Must be true or false";
                    log.Fatal(error);
                    throw new SoapException(error,
                                            new XmlQualifiedName(SoapExceptionGenerator.ServerError));

                }

            }

            #region IService Members

            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            public override string GetSitesXml(string[] site, String authToken)
            {

                SiteInfoResponseTypeGeneric aSite = (SiteInfoResponseTypeGeneric)GetSites(site, null);
                XmlSerializer xs = new XmlSerializer(
     typeof(WaterOneFlow.Service.v1_0.xsd.SiteInfoResponse));
                StringBuilder xml = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(xml, NoDocument());
               

                xs.Serialize(writer, aSite);
                return xml.ToString();

            }

            [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
            public override string GetSiteInfo(string site, String authToken)
            {
                SiteInfoResponseTypeGeneric aSite = (SiteInfoResponseTypeGeneric)GetSiteInfoObject(site, null);
                XmlSerializer xs = new XmlSerializer(
                     typeof(WaterOneFlow.Service.v1_0.xsd.SiteInfoResponse));
                StringBuilder xml = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(xml, NoDocument());
                

                xs.Serialize(writer, aSite);
                return xml.ToString();
            }

            [WebMethod(Description = WsDescriptions.GetVariableInfoDefaultDesc)]
            public override string GetVariableInfo(string variable, String authToken)
            {
                VariablesResponseTypeGeneric aVType = (VariablesResponseTypeGeneric)GetVariableInfoObject(variable, null);
                XmlSerializer xs = new XmlSerializer(
                    typeof(WaterOneFlow.Service.v1_0.xsd.VariablesResponse));
                StringBuilder xml = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(xml, NoDocument());
               

                xs.Serialize(writer, aVType);
                return xml.ToString();
            }


            [return: XmlElement(
              Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
  ElementName = "sitesResponse", IsNullable = false
                ,Type = typeof(SiteInfoResponseTypeGeneric)
                )]
            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            public override object GetSites(string[] site, String authToken)
            {
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                string siteListString ;
                if (site != null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string s in site)
                    {
                        sb.AppendFormat("{0};", s);
                    }
                        siteListString = sb.ToString();

                } else
                {
                    siteListString = "All Sites";
                }

                queryLog2.LogStart(Logging.Methods.GetSites, siteListString,
                   Context.Request.UserHostName);
                try
                {
                    List<locationParam> lParams = new List<locationParam>();
                    StringBuilder siteNumbersAsString = new StringBuilder();
                    if (site != null ){
                    foreach (String s in site)
                    {
                        try
                        {
                            if (!String.IsNullOrEmpty(s))
                            {
                                locationParam lp = new locationParam(s);
                                lParams.Add(lp);
                                siteNumbersAsString.AppendFormat("{0};", s);
                            }
                        }
                        catch
                        {
                            log.Info("Bad Location parameter submitted");
                        }
                    }
                    }
                    SiteInfoType[] siteList;
                    if (lParams.Count > 0)
                    {
                        siteList = ODws.GetSites(lParams.ToArray());
                    }
                    else
                    {
                        siteList = ODws.GetSites(null);
                    }
                
                    SiteInfoResponseType sit = new SiteInfoResponseType();
                    site[] sites = new site[siteList.Length];
                    for (int i = 0; i < siteList.Length; i++)
                    {
                        sites[i] = new site();
                        sites[i].siteInfo = siteList[i];
                    }
                    sit.site = sites;

                    queryLog2.LogEnd(Logging.Methods.GetSites,
                        siteListString,
                        timer.ElapsedMilliseconds.ToString(),
                        sit.site.Length.ToString(),
                        Context.Request.UserHostName);

                    // add query info
                    if (sit.queryInfo == null) sit.queryInfo = new QueryInfoType();
                    sit.queryInfo.creationTime = DateTime.Now.ToLocalTime();
                    sit.queryInfo.creationTimeSpecified = true;
                    QueryInfoTypeCriteria crit = new QueryInfoTypeCriteria();
                    if (site == null || site.Length == 0)
                    {
                        crit.locationParam = "ALL (empty request)";
                    }
                    else
                    {
                        crit.locationParam = siteNumbersAsString.ToString();
                    }

                    sit.queryInfo.criteria = crit;


                   // return sit;
                    return new WaterOneFlow.Service.v1_0.xsd.SiteInfoResponse(sit);



                }
                catch (Exception we)
                {
                    log.Warn(we.Message);

                    queryLog2.LogEnd(Logging.Methods.GetSites,
                              siteListString,
                              timer.ElapsedMilliseconds.ToString(),
                              "-9999",
                              Context.Request.UserHostName
                             );

                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }
            }

            [return: XmlElement(
                Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "sitesResponse", IsNullable = false
                , Type = typeof(SiteInfoResponseTypeGeneric)
                )]
            [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
            public override object GetSiteInfoObject(string site, String authToken)
            {
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogStart(Logging.Methods.GetSiteInfo, site,
        Context.Request.UserHostName);

                try
                {
                    if (String.IsNullOrEmpty(site))
                    {
                        throw new WaterOneFlowException("Bad Location parameter submitted:'" +
                                 site + "'");
                    }

                    List<locationParam> lParams = new List<locationParam>();
                    //foreach (String site in SiteNumbers)
                    //{
                    try
                    {
                        locationParam lp = new locationParam(site);
                        lParams.Add(lp);
                    }
                    catch
                    {
                        // only one here
                        log.Info("Bad Location parameter submitted:'" +
                            site + "'");
                        throw new WaterOneFlowException("Bad Location parameter submitted:'" +
                            site + "'");
                    }
                    //}
                    if (lParams.Count > 0)
                    {
                        SiteInfoType[] siteList = ODws.GetSites(lParams.ToArray());
                        SiteInfoResponseType sit = new SiteInfoResponseType();
                        site[] sites = new site[siteList.Length];
                        // only one site
                        sites[0] = new site();
                        sites[0].siteInfo = siteList[0];
                        // now add series
                        sites[0].seriesCatalog = ODws.GetSeries(lParams[0]);

                        sit.site = sites;
                        queryLog2.LogEnd(Logging.Methods.GetSiteInfo,
                           site,
                           timer.ElapsedMilliseconds.ToString(),
                           sit.site.Length.ToString(),
                               Context.Request.UserHostName);

                        // add query info
                        if (sit.queryInfo == null) sit.queryInfo = new QueryInfoType();
                        sit.queryInfo.creationTime = DateTime.Now.ToLocalTime();
                        sit.queryInfo.creationTimeSpecified = true;
                        QueryInfoTypeCriteria crit = new QueryInfoTypeCriteria();
                        if (String.IsNullOrEmpty(site))
                        {
                            crit.locationParam = "none";
                        }
                        else
                        {
                            crit.locationParam = site;
                        }

                        sit.queryInfo.criteria = crit;

                        //return sit;
                        return new WaterOneFlow.Service.v1_0.xsd.SiteInfoResponse(sit);
                    }
                    else
                    {
                        queryLog2.LogEnd(Logging.Methods.GetSiteInfo,
                              site,
                              timer.ElapsedMilliseconds.ToString(),
                              "-9999",
                                  Context.Request.UserHostName);
                        throw new WaterOneFlowException("No Valid Site Code submitted");
                    }

                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    queryLog2.LogEnd(Logging.Methods.GetSiteInfo,
                              site,
                              timer.ElapsedMilliseconds.ToString(),
                              "-9999",
                                  Context.Request.UserHostName);
                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }
            }

            [return: XmlElement(
               Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "variablesResponse", IsNullable = false
                , Type = typeof(VariablesResponseTypeGeneric)
                )]
            [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
            public override object GetVariableInfoObject(string variable, String authToken)
            {
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogStart(Logging.Methods.GetVariables, variable,
                            Context.Request.UserHostName);

                try
                {
                    VariableParam[] vars = null;
                    if (!String.IsNullOrEmpty(variable))
                    {
                        vars = new VariableParam[1];

                        VariableParam vp = new VariableParam(variable);
                        vars[0] = vp;
                    }
                    VariablesResponseType res = ODws.GetVariables(vars);

                    // don't always have variables
                    if (res.variables != null)
                    {
                        queryLog2.LogEnd(Logging.Methods.GetVariables,
                                         variable,
                                         timer.ElapsedMilliseconds.ToString(),
                                         res.variables.Length.ToString(),
                                         Context.Request.UserHostName);
                    }
                    else
                    {
                        queryLog2.LogEnd(Logging.Methods.GetVariables,
                      variable,
                      timer.ElapsedMilliseconds.ToString(),
                      "0",
                      Context.Request.UserHostName);

                    }
                    WaterOneFlow.Service.v1_0.xsd.VariablesResponse obj =
                        new WaterOneFlow.Service.v1_0.xsd.VariablesResponse(res);
                    // if (DEBUG) {
                   // XmlSerializer xs = new XmlSerializer(
                   //     typeof (WaterOneFlow.Service.v1_0.xsd.VariablesResponse));
                   // StringBuilder sb = new StringBuilder();
                   // XmlWriterSettings settings = new XmlWriterSettings();
                    
                   // settings.OmitXmlDeclaration = true;
                   //// settings.ConformanceLevel = ConformanceLevel.Fragment;
                   // XmlWriter writer = XmlWriter.Create(sb, settings);
                   // xs.Serialize(writer, obj);
                    //}
                    //return res;
                    return new WaterOneFlow.Service.v1_0.xsd.VariablesResponse(res);
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    queryLog2.LogEnd(Logging.Methods.GetVariables,
                            variable,
                            timer.ElapsedMilliseconds.ToString(),
                            "-9999",
                            Context.Request.UserHostName);

                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }

            }

            [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
            public override string GetValues(string location, string variable, string startDate, string endDate, String authToken)
            {
                TimeSeriesResponseTypeGeneric aSite = (TimeSeriesResponseTypeGeneric)GetValuesObject(location, variable, startDate, endDate, null);

                XmlSerializer xs = new XmlSerializer(
                    typeof(WaterOneFlow.Service.v1_0.xsd.TimeSeriesResponse));
                StringBuilder xml = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(xml, NoDocument());
                

                xs.Serialize(writer, aSite); 
                return xml.ToString();
            }

            [return: XmlElement(
                Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "timeSeriesResponse",
              IsNullable = false
              , Type = typeof(TimeSeriesResponseTypeGeneric)
                )]
            [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
            public override object GetValuesObject(string location, string variable, string startDate, string endDate, String authToken)
            {
                if (!useODForValues) throw new SoapException("GetValues implemented external to this service. Call GetSiteInfo, and SeriesCatalog includes the service Wsdl for GetValues. Attribute:serviceWsdl on Element:seriesCatalog XPath://seriesCatalog/[@serviceWsdl]", new XmlQualifiedName("ServiceException"));

                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogValuesStart(Logging.Methods.GetValues, // method
                            location, //location
                            variable, //variable
                            startDate, // startdate
                            startDate, //enddate
                            Context.Request.UserHostName);

                try
                {
                    WaterOneFlowImpl.locationParam lParam = new locationParam(location);
                    VariableParam vparam = new VariableParam(variable);
                    W3CDateTime? startDt = null;
                    W3CDateTime? endDt = null;
                    if (!String.IsNullOrEmpty(startDate)) startDt = new W3CDateTime(DateTime.Parse(startDate));
                    if (!String.IsNullOrEmpty(endDate)) endDt = new W3CDateTime(DateTime.Parse(endDate));


                    TimeSeriesResponseTypeObject res = (TimeSeriesResponseTypeObject)dvSvc.GetTimeSeries(lParam, vparam, startDt, endDt);

                    //if (res != null && res.timeSeries != null &&
                    //    res.timeSeries.values != null &&
                    //    res.timeSeries.values.value != null)
                    //{
                    //    queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                    //          location, //locaiton
                    //        variable, //variable
                    //        startDate, // startdate
                    //        startDate, //enddate
                    //        timer.ElapsedMilliseconds, // processing time
                    //        res.timeSeries.values.value.Length, // count 
                    //         Context.Request.UserHostName
                    //         );
                    //}
                    //else
                    //{
                    //    queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                    //             location, //locaiton
                    //             variable, //variable
                    //             startDate, // startdate
                    //             startDate, //enddate
                    //             timer.ElapsedMilliseconds, // processing time
                    //             0, // count 
                    //             Context.Request.UserHostName
                    //             );
                    //}

                    //// add query info
                    //if (res.queryInfo == null) res.queryInfo = new QueryInfoType();
                    //res.queryInfo.creationTime = DateTime.Now.ToLocalTime();
                    //res.queryInfo.creationTimeSpecified = true;
                    //QueryInfoTypeCriteria crit = new QueryInfoTypeCriteria();
                    //if (String.IsNullOrEmpty(location))
                    //{
                    //    crit.locationParam = "none";
                    //}
                    //else
                    //{
                    //    crit.locationParam = location;
                    //}

                    //if (String.IsNullOrEmpty(variable))
                    //{
                    //    crit.locationParam = "none";
                    //}
                    //else
                    //{
                    //    crit.variableParam = variable;
                    //}
                    //crit.timeParam =
                    //    CuahsiBuilder.createQueryInfoTimeCriteria(startDate, endDate);

                    //res.queryInfo.criteria = crit;


                    //return res;
                    return new WaterOneFlow.Service.v1_0.xsd.TimeSeriesResponse(res);
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                                location, //locaiton
                                variable, //variable
                                startDate, // startdate
                                startDate, //enddate
                                timer.ElapsedMilliseconds, // processing time
                                -9999, // count 
                                Context.Request.UserHostName
                                );
                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }

            }


            #endregion
            private static XmlWriterSettings NoDocument()
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
              
                return settings;
            }

        }
    }
}