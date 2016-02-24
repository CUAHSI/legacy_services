
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using log4net;
using NwisWOFService.v1_0;
using WaterOneFlow.Service.v1_0;
using WaterOneFlowImpl.v1_0;
using WaterOneFlowImpl;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Services.Protocols;
using WaterOneFlow.Schema.v1;
using WaterOneFlow;





namespace WaterOneFlow.Service
{
    namespace v1_0
    {
        using NwisWOFService = NwisWOFService.v1_0;
        using VariableParam = WaterOneFlowImpl.v1_0.VariableParam;
        [WebService(Name = WsDescriptions.WsDefaultName,
    Namespace = WaterOneFlowImpl.v1_0.Constants.WS_NAMSPACE,
    Description = WsDescriptions.WsDefaultDescription)]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
       // [SoapActor("*")]
        public class Service_DV_1_0_scrape : Service_1_0
        {
            private static readonly ILog log = LogManager.GetLogger(typeof(Service_DV_1_0_scrape));
            private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");
            private static readonly Logging queryLog2 = new Logging();

            // protected WofService ODws;
            //protected NwisWOFService.GetValuesDailyUSGS dvSvc;
            ////protected NwisWOFService.GetDataInformationDailyDB ODws;
            //protected NwisWOFService.GetDataInformationDB ODws;

            private Boolean useODForValues;
            private Boolean requireAuthToken;



            public Service_DV_1_0_scrape()
            {
                //log4net.Util.LogLog.InternalDebugging = true; 

                log.Info("Starting " + "NWISDV");
                //  ODws = new WofService(this.Context);//INFO we can extend this for other service types

                //ODws = new GetDataInformationDailyDB();
                ODws = new GetDataInformationDB();
                // configure
                ConnectionStringSettings oddb = ConfigurationManager.ConnectionStrings["ODDB"];
                ODws.DataInfoConnection = oddb.ConnectionString;
                ODws.VariablesTableName = "odm_dv_variables";
                ODws.SitesTableName = "odm_dv_sites";
                ODws.SeriesTableName = "odm_dv_SeriesCatalog";

                dvSvc = new GetValuesDailyUSGS();

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

            //public string GetSitesXml(string[] SiteNumbers, String authToken)
            //{
            //    SiteInfoResponseType aSite = GetSites(SiteNumbers, null);
            //    string xml = WSUtils.ConvertToXml(aSite, typeof(SiteInfoResponseType));
            //    return xml;

            //}

            //public virtual string GetSiteInfo(string SiteNumber, String authToken)
            //{
            //    SiteInfoResponseType aSite = GetSiteInfoObject(SiteNumber, null);
            //    string xml = WSUtils.ConvertToXml(aSite, typeof(SiteInfoResponseType));
            //    return xml;
            //}

            //public string GetVariableInfo(string Variable, String authToken)
            //{
            //    VariablesResponseType aVType = GetVariableInfoObject(Variable, null);
            //    string xml = WSUtils.ConvertToXml(aVType, typeof(VariablesResponseType));
            //    return xml;
            //}


            public SiteInfoResponseType GetSites(string[] SiteNumbers, String authToken)
            {
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogStart(Logging.Methods.GetSites, SiteNumbers.ToString(),
                   Context.Request.UserHostName);
                try
                {
                    List<locationParam> lParams = new List<locationParam>();
                    foreach (String site in SiteNumbers)
                    {
                        try
                        {
                            if (!String.IsNullOrEmpty(site))
                            {
                                locationParam lp = new locationParam(site);
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
                    site[] sites = new site[siteList.Length];
                    for (int i = 0; i < siteList.Length; i++)
                    {
                        sites[i] = new site();
                        sites[i].siteInfo = siteList[i];
                    }
                    sit.site = sites;

                    queryLog2.LogEnd(Logging.Methods.GetSites,
                        SiteNumbers.ToString(),
                        timer.ElapsedMilliseconds.ToString(),
                        sit.site.Length.ToString(),
                        Context.Request.UserHostName);

                    return sit;



                }
                catch (Exception we)
                {
                    log.Warn(we.Message);

                    queryLog2.LogEnd(Logging.Methods.GetSites,
                              SiteNumbers.ToString(),
                              timer.ElapsedMilliseconds.ToString(),
                              "-9999",
                              Context.Request.UserHostName
                             );

                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }
            }

            public virtual SiteInfoResponseType GetSiteInfoObject(string SiteNumber, String authToken)
            {
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogStart(Logging.Methods.GetSiteInfo, SiteNumber,
        Context.Request.UserHostName);

                try
                {
                    if (String.IsNullOrEmpty(SiteNumber))
                    {
                        throw new WaterOneFlowException("Bad Location parameter submitted:'" +
                                 SiteNumber + "'");
                    }

                    List<locationParam> lParams = new List<locationParam>();
                    //foreach (String site in SiteNumbers)
                    //{
                    try
                    {
                        locationParam lp = new locationParam(SiteNumber);
                        lParams.Add(lp);
                    }
                    catch
                    {
                        // only one here
                        log.Info("Bad Location parameter submitted:'" +
                            SiteNumber + "'");
                        throw new WaterOneFlowException("Bad Location parameter submitted:'" +
                            SiteNumber + "'");
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
                           SiteNumber,
                           timer.ElapsedMilliseconds.ToString(),
                           sit.site.Length.ToString(),
                               Context.Request.UserHostName);

                        return sit;

                    }
                    else
                    {
                        queryLog2.LogEnd(Logging.Methods.GetSiteInfo,
                              SiteNumber,
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
                              SiteNumber,
                              timer.ElapsedMilliseconds.ToString(),
                              "-9999",
                                  Context.Request.UserHostName);
                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }
            }

            public VariablesResponseType GetVariableInfoObject(string Variable, String authToken)
            {
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogStart(Logging.Methods.GetVariables, Variable,
                            Context.Request.UserHostName);

                try
                {
                    VariableParam[] vars = null;
                    if (!String.IsNullOrEmpty(Variable))
                    {
                        vars = new VariableParam[1];

                        VariableParam vp = new VariableParam(Variable);
                        vars[0] = vp;
                    }
                    VariablesResponseType res = ODws.GetVariables(vars);

                    // don't always have variables
                    if (res.variables != null)
                    {
                        queryLog2.LogEnd(Logging.Methods.GetVariables,
                                         Variable,
                                         timer.ElapsedMilliseconds.ToString(),
                                         res.variables.Length.ToString(),
                                         Context.Request.UserHostName);
                    }
                    else
                    {
                        queryLog2.LogEnd(Logging.Methods.GetVariables,
                      Variable,
                      timer.ElapsedMilliseconds.ToString(),
                      "0",
                      Context.Request.UserHostName);

                    }


                    return res;
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    queryLog2.LogEnd(Logging.Methods.GetVariables,
                            Variable,
                            timer.ElapsedMilliseconds.ToString(),
                            "-9999",
                            Context.Request.UserHostName);

                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }

            }

            //public virtual string GetValues(string locationParam, string VariableCode, string StartDate, string EndDate, String authToken)
            //{
            //    TimeSeriesResponseType aSite = GetValuesObject(locationParam, VariableCode, StartDate, EndDate, null);
            //    return WSUtils.ConvertToXml(aSite, typeof(TimeSeriesResponseType));
            //}

            public virtual TimeSeriesResponseType GetValuesObject(string LP, string VariableCode, string StartDate, string EndDate, String authToken)
            {
                if (!useODForValues) throw new SoapException("GetValues implemented external to this service. Call GetSiteInfo, and SeriesCatalog includes the service Wsdl for GetValues. Attribute:serviceWsdl on Element:seriesCatalog XPath://seriesCatalog/[@serviceWsdl]", new XmlQualifiedName("ServiceException"));

                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogValuesStart(Logging.Methods.GetValues, // method
                            LP, //location
                            VariableCode, //variable
                            StartDate, // startdate
                            StartDate, //enddate
                            Context.Request.UserHostName);

                try
                {
                    WaterOneFlowImpl.locationParam lParam = new locationParam(LP);
                    VariableParam vparam = new VariableParam(VariableCode);
                    W3CDateTime? startDt = null;
                    W3CDateTime? endDt = null;
                    if (!String.IsNullOrEmpty(StartDate)) startDt = new W3CDateTime(DateTime.Parse(StartDate));
                    if (!String.IsNullOrEmpty(EndDate)) endDt = new W3CDateTime(DateTime.Parse(EndDate));


                    TimeSeriesResponseType res = (TimeSeriesResponseType)dvSvc.GetTimeSeries(lParam, vparam, startDt, endDt);

                    if (res != null && res.timeSeries != null &&
                        res.timeSeries.values != null &&
                        res.timeSeries.values.value != null)
                    {
                        queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                              LP, //locaiton
                            VariableCode, //variable
                            StartDate, // startdate
                            StartDate, //enddate
                            timer.ElapsedMilliseconds, // processing time
                            res.timeSeries.values.value.Length, // count 
                             Context.Request.UserHostName
                             );
                    }
                    else
                    {
                        queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                                 LP, //locaiton
                                 VariableCode, //variable
                                 StartDate, // startdate
                                 StartDate, //enddate
                                 timer.ElapsedMilliseconds, // processing time
                                 0, // count 
                                 Context.Request.UserHostName
                                 );
                    }

                    return res;
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                                LP, //locaiton
                                VariableCode, //variable
                                StartDate, // startdate
                                StartDate, //enddate
                                timer.ElapsedMilliseconds, // processing time
                                -9999, // count 
                                Context.Request.UserHostName
                                );
                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }

            }


            #endregion


        }
    }
}