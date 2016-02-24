
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
using NwisWOFService.v1_0;
using NwisWOFService.v1_0.Passthrough;
using WaterOneFlow.Service;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Addressing;
using Microsoft.Web.Services3.Messaging;
using WaterOneFlow.Service.Constants.v1;
using WaterOneFlowImpl;


namespace WaterOneFlow.Service
{

    namespace v1_0
    {

        using GetDataInformationDB = NwisWOFService.v1_0.GetDataInformationDB;
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

        using NwisWOFService.v1_0;

        using USGSwebService = NwisWOFService.gov.usgs.nwis.dailyValues;

        [WebService(Name = WsDescriptions.WsDefaultName, Namespace = Constants.WS_NAMSPACE, Description = WsDescriptions.WsDefaultDescription)]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1), 
         System.Web.Services.Protocols.SoapDocumentService()]
     //  [SoapActor("*")]
        public class Service_DV_1_0 : Service_1_0
        {



            public Service_DV_1_0()
            {
                //log4net.Util.LogLog.InternalDebugging = true; 

                //log.Info("Starting " + "NWISDV");
                //  ODws = new WofService(this.Context);//INFO we can extend this for other service types

                //ODws = new GetDataInformationDailyDB();
                ODws = new GetDataInformationDB();
                ODws.VariableVocabulary = "NWISDV";
                ODws.SiteVocabulary = "NWISDV";
                QueryLoggger = new Logging(ODws.SiteVocabulary);

                // configure
                ConnectionStringSettings oddb = ConfigurationManager.ConnectionStrings["ODDB"];
                ODws.DataInfoConnection = oddb.ConnectionString;
                ODws.VariablesTableName = "odm_dv_variables";
                ODws.SitesTableName = "odm_dv_sites";
                ODws.SeriesTableName = "odm_dv_SeriesCatalog";

               // dvSvc = new GetValuesDailyUSGS(ConfigurationManager.AppSettings["USGSDVUrl"]);
                dvSvc = new GetValuesDVRESTUSGS_xslt(ConfigurationManager.AppSettings["USGSDVUrl"]
                   , ConfigurationManager.AppSettings["USGSDVxlst"]);

                //    #endregion
            }

            /* need to override both mthods, since this actually does not return a
            * a standard timeSeriesResponseType
             * */
            [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
            public override string GetValues(string location, string variable, string startDate, string endDate, String authToken)
            {
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

             /*
             * override the standard MethodAccessException 
                 */
            [return: XmlElement(
            Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "timeSeriesResponse",
          IsNullable = false
                // , Type = typeof(NWISTimeSeriesResponse)
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


                    TimeSeriesResponseType res =
    (TimeSeriesResponseType)dvSvc.GetTimeSeries(lParam, vparam, startDt, endDt);

                    if (res != null && res.timeSeries != null &&
                        res.timeSeries.values != null)
                    {
                        queryLog2.LogEnd(Logging.Methods.GetValues,
                                         location,
                                         timer.ElapsedMilliseconds.ToString(),
                                         res.timeSeries.values.value.Length.ToString(),
                                         Context.Request.UserHostName);
                    } else
                    {
                        queryLog2.LogEnd(Logging.Methods.GetValues,
                                         location,
                                         timer.ElapsedMilliseconds.ToString(),
                                         0.ToString(),
                                         Context.Request.UserHostName);
                    }
                   
                    // return new NWISTimeSeriesResponse(res);

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
        }
    }
}