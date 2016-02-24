
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
using WaterOneFlow.Ogc;
using WaterOneFlow.Service;
using WaterOneFlow.Service.Source.v1_1;
using WaterOneFlowImpl;
// Load the configuration from the 'wateroneflow.logging.log4net' file
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "wateroneflow.logging.log4net", Watch = true)]

namespace WaterOneFlow.Service
{
    namespace v1_1
    {
       
        using WaterOneFlow.Schema.v1_1;
        using WaterOneFlowImpl.v1_1;
using WaterOneFlow.Service.Services.v1_1;

        //using WaterOneFlow.Service.Response.v1;
        using VariablesResponseTypeGeneric = WaterOneFlow.Service.Response.v1_1.VariablesResponseType;
        using SiteInfoResponseTypeGeneric = WaterOneFlow.Service.Response.v1_1.SiteInfoResponseType;
        using TimeSeriesResponseTypeGeneric = WaterOneFlow.Service.Response.v1_1.TimeSeriesResponseType;
        //using VariablesResponseTypeGeneric = WaterOneFlow.Service.Abstract.VariablesResponseType;
        //using SiteInfoResponseTypeGeneric = WaterOneFlow.Service.Abstract.SiteInfoResponseType;
        //using TimeSeriesResponseTypeGeneric = WaterOneFlow.Service.Abstract.TimeSeriesResponseType;

        //
        //using WaterOneFlow.Schema.v1;
        using VariablesResponseTypeObject = WaterOneFlow.Schema.v1_1.VariablesResponseType;
        using SiteInfoResponseTypeObject = WaterOneFlow.Schema.v1_1.SiteInfoResponseType;
        using TimeSeriesResponseTypeObject = WaterOneFlow.Schema.v1_1.TimeSeriesResponseType;
   

        [WebService(Name = WsDescriptions.WsDefaultName,
    Namespace = Constants.WS_NAMSPACE,
    Description = WsDescriptions.WsDefaultDescription)]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [SoapActor("*")]
        public class Service : IWaterOneFlowWebService
        {
            private static readonly ILog log = LogManager.GetLogger(typeof(Service));
            private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");
            private static Logging queryLog2 = new Logging();

            public static Logging QueryLoggger
            {
                get { return Service.queryLog2; }
                set { Service.queryLog2 = value; }
            }


            // protected WofService ODws;
            protected DataTimeSeriesWofService dvSvc;
            //protected NwisWOFService.GetDataInformationDailyDB ODws;
            protected GetDataInformationDB ODws;

            private Boolean useODForValues;
            private Boolean requireAuthToken;


            /// <summary>
            /// Extend this class, and implement the constructor
            /// The constructor will be called before the child classes constructor.
            /// </summary>
            public Service()
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

            public override string GetSitesXml(string[] site, String authToken)
            {

                SiteInfoResponseTypeGeneric aSite = GetSitesObject(site, null);
                string xml = WSUtils.ConvertToXml(aSite, typeof(xsd.SiteInfoResponse));
                return xml;

            }

            public override string GetSiteInfo(string site, String authToken)
            {
                SiteInfoResponseTypeGeneric aSite = GetSiteInfoObject(site, null);
                string xml = WSUtils.ConvertToXml(aSite, typeof(xsd.SiteInfoResponse));
                return xml;
            }

            public override string GetVariableInfo(string variable, String authToken)
            {
                VariablesResponseTypeGeneric aVType = GetVariableInfoObject(variable, null);
                string xml = WSUtils.ConvertToXml(aVType, typeof(xsd.VariablesResponse));
                return xml;
            }

            public override SiteInfoResponseTypeGeneric GetSites(string[] site, String authToken)
            {
                return  GetSitesObject(site, null);
            }

            public  SiteInfoResponseTypeGeneric GetSitesObject(string[] site, String authToken)
            {
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogStart(Logging.Methods.GetSites, site.ToString(),
                   Context.Request.UserHostName);
                try
                {
                    List<locationParam> lParams = new List<locationParam>();
                    foreach (String s in site)
                    {
                        try
                        {
                            if (!String.IsNullOrEmpty(s))
                            {
                                locationParam lp = new locationParam(s);
                                lParams.Add(lp);
                            }
                        }
                        catch
                        {
                            log.Info("Bad Location parameter submitted");
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
                    WaterOneFlow.Schema.v1_1.


                        SiteInfoResponseTypeSite[] sites = new SiteInfoResponseTypeSite[siteList.Length];
                    for (int i = 0; i < siteList.Length; i++)
                    {
                        sites[i] = new SiteInfoResponseTypeSite();
                        sites[i].siteInfo = siteList[i];
                    }
                    sit.site = sites;

                    queryLog2.LogEnd(Logging.Methods.GetSites,
                        site.ToString(),
                        timer.ElapsedMilliseconds.ToString(),
                        sit.site.Length.ToString(),
                        Context.Request.UserHostName);

                    // add query info
                    if (sit.queryInfo == null) sit.queryInfo = new QueryInfoType();
                    sit.queryInfo.creationTime = DateTime.Now.ToLocalTime();
                    sit.queryInfo.creationTimeSpecified = true;
                    QueryInfoTypeCriteria crit = new QueryInfoTypeCriteria();
                    if (sites == null || sites.Length == 0)
                    {
                        crit.locationParam = "ALL (empty request)";
                    }
                    else
                    {
                        crit.locationParam = sites.ToString();
                    }

                    sit.queryInfo.criteria = crit;


                    return new WaterOneFlow.Service.v1_1.xsd.SiteInfoResponse(sit);



                }
                catch (Exception we)
                {
                    log.Warn(we.Message);

                    queryLog2.LogEnd(Logging.Methods.GetSites,
                              site.ToString(),
                              timer.ElapsedMilliseconds.ToString(),
                              "-9999",
                              Context.Request.UserHostName
                             );

                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }
            }

            public override SiteInfoResponseTypeGeneric GetSiteInfoObject(string site, String authToken)
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
                        SiteInfoResponseTypeSite[] sites = new SiteInfoResponseTypeSite[siteList.Length];
                        // only one site
                        sites[0] = new SiteInfoResponseTypeSite();
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
                        return new WaterOneFlow.Service.v1_1.xsd.SiteInfoResponse(sit);

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

            public override VariablesResponseTypeGeneric GetVariableInfoObject(string variable, String authToken)
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

                    return new WaterOneFlow.Service.v1_1.xsd.VariablesResponse(res);
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

            public override string GetValues(string location, string variable, string startDate, string endDate, String authToken)
            {
                TimeSeriesResponseTypeGeneric aSite = GetValuesObject(location, variable, startDate, endDate, null);
                return WSUtils.ConvertToXml(aSite, typeof(xsd.TimeSeriesResponse));
            }

            public override TimeSeriesResponseTypeGeneric GetValuesObject(string location, string variable, string startDate, string endDate, String authToken)
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


                    TimeSeriesResponseTypeObject res = (TimeSeriesResponseTypeObject) dvSvc.GetTimeSeries(lParam, vparam, startDt, endDt);

                    return new xsd.TimeSeriesResponse(res);
                
                    //throw new NotImplementedException("Reimplement 1.1");
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

  


            public override WofCapabilities GetCapabilties()
            {
                throw new NotImplementedException();
            }
        }
    }
}