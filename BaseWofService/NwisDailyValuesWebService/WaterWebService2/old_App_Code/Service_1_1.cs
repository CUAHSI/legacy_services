
using System;
using System.Configuration;
using System.Text;
using log4net;
using WaterOneFlow.Ogc;
using WaterOneFlow.Service.BaseService.v1_1;
using WaterOneFlow.Service.Services.v1_1;
using WaterOneFlowImpl;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Services.Protocols;
using WaterOneFlow.Schema.v1_1;
using WaterOneFlow;



namespace WaterOneFlow.Service.v1_1
{

    [WebService(Name = WsDescriptions.WsDefaultName,
Namespace = WaterOneFlowImpl.Constants.WS_NAMSPACE,
Description = WsDescriptions.SvcDevelopementalWarning + WsDescriptions.WsDefaultDescription)]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    
    public class Service_1_1 : WebService, IWaterOneFlowWebService
    {

        protected WofService ODws;
        private Boolean useODForValues;
        private Boolean requireAuthToken;

        private static readonly ILog log = LogManager.GetLogger(typeof(Service_1_1));
        private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");

        public Service_1_1()
        {
           //log4net.Util.LogLog.InternalDebugging = true; 

           // ODws = new WofService(this.Context);//INFO we can extend this for other service types
            ODws = new WofService(); 
            try {
            useODForValues = Boolean.Parse(ConfigurationManager.AppSettings["UseODForValues"]);
           } catch(Exception e)
           {
               String error = "Missing or invalid value for UseODForValues. Must be true or false";
                  log.Fatal(error);
 
                  throw new SoapException("Invalid Server Configuration. " + error,
                                       new XmlQualifiedName(SoapExceptionGenerator.ServerError));
           }
            
        try {
                    requireAuthToken = Boolean.Parse(ConfigurationManager.AppSettings["requireAuthToken"]);
           } catch(Exception e)
           {
             String error ="Missing or invalid value for requireAuthToken. Must be true or false";
              log.Fatal(error);
              throw new SoapException(error,
                                      new XmlQualifiedName(SoapExceptionGenerator.ServerError));

           }
            
        }

        #region IService Members

        public string GetSites(string[] SiteNumbers, String authToken)
        {
            SiteInfoResponseType aSite = GetSitesObject(SiteNumbers, null);
            string xml = WSUtils.ConvertToXml(aSite, typeof(SiteInfoResponseType));
            return xml;
           
        }

        object IWaterOneFlowWebService.GetSiteInfoObject(string site, string authToken)
        {
            return GetSiteInfoObject(site, authToken);
        }

        object IWaterOneFlowWebService.GetVariableInfoObject(string variable, string authToken)
        {
            return GetVariableInfoObject(variable, authToken);
        }

        object IWaterOneFlowWebService.GetValuesObject(string location, string variable, string startDate, string endDate, string authToken)
        {
            return GetValuesObject(location, variable, startDate, endDate, authToken);
        }

        public WofCapabilities GetCapabilties()
        {
            throw new NotImplementedException();
        }

        object Services.v1_1.IService.GetSitesObject(string[] site, string authToken)
        {
            return GetSitesObject(site, authToken);
        }

        object IWaterOneFlowWebService.GetSites(string[] site, string authToken)
        {
            return GetSites(site, authToken);
        }

        object Services.v1_1.IService.GetSiteInfoObject(string site, string authToken)
        {
            return GetSiteInfoObject(site, authToken);
        }

        object Services.v1_1.IService.GetVariableInfoObject(string variable, string authToken)
        {
            return GetVariableInfoObject(variable, authToken);
        }

        object Services.v1_1.IService.GetValuesObject(string location, string variable, string startDate, string endDate, string authToken)
        {
            return GetValuesObject(location, variable, startDate, endDate, authToken);
        }

      

        public string GetSitesXml(string[] sites, string authToken)
        {
            throw new NotImplementedException();
        }

        public virtual string GetSiteInfo(string SiteNumber, String authToken)
        {
            SiteInfoResponseType aSite = GetSiteInfoObject(SiteNumber, null);
            string xml = WSUtils.ConvertToXml(aSite, typeof(SiteInfoResponseType));
            return xml;
        }

        public string GetVariableInfo(string Variable, String authToken)
        {
            VariablesResponseType aVType = GetVariableInfoObject(Variable, null);
            string xml = WSUtils.ConvertToXml(aVType, typeof(VariablesResponseType));
            return xml;
        }

  
        public SiteInfoResponseType GetSitesObject(string[] SiteNumbers, String authToken)
        {
            try
            {
                return ODws.GetSites(SiteNumbers);
            }
            catch (Exception we)
            {
                log.Warn(we.Message);
                throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

            }
          }

      

        public virtual SiteInfoResponseType GetSiteInfoObject(string SiteNumber, String authToken)
        {
            try
            {
                return ODws.GetSiteInfo(SiteNumber);
            }
            catch (Exception we)
            {
                log.Warn(we.Message);
                throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

            }

        }

        public VariablesResponseType GetVariableInfoObject(string Variable, String authToken)
        {
            try
            {
                return ODws.GetVariableInfo(Variable);
            }
            catch (Exception we)
            {
                log.Warn(we.Message);
                throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

            }
         
        }

        public virtual string GetValues(string locationParam, string VariableCode, string StartDate, string EndDate, String authToken)
        {
            TimeSeriesResponseType aSite = GetValuesObject(locationParam, VariableCode, StartDate, EndDate, null);
            return WSUtils.ConvertToXml(aSite, typeof(TimeSeriesResponseType));
        }

        public virtual TimeSeriesResponseType GetValuesObject(string locationParam, string VariableCode, string StartDate, string EndDate, String authToken)
        {
            if (!useODForValues) throw new SoapException("GetValues implemented external to this service. Call GetSiteInfo, and SeriesCatalog includes the service Wsdl for GetValues. Attribute:serviceWsdl on Element:seriesCatalog XPath://seriesCatalog/[@serviceWsdl]", new XmlQualifiedName("ServiceException"));
                
            try
            {
                return ODws.GetValues(locationParam, VariableCode, StartDate, EndDate);
            }
            catch (Exception we)
            {
                log.Warn(we.Message);
                throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

            }
  
        }

       
        #endregion

    
    }
}