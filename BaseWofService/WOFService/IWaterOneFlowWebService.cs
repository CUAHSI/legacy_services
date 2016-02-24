using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Services;

using System.Xml.Serialization;
using WaterOneFlow.Ogc;
using WaterOneFlow.Service.Constants;


namespace WaterOneFlow.Service
{
    namespace Services.v1_0
    {

        using WaterOneFlow.Service.Response.v1; 
        //using WaterOneFlow.Service.Abstract;
using WaterOneFlow.Service.Constants.v1;
        public interface IService_1_0
        {

            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            string GetSitesXml(
                [XmlArray("site"), XmlArrayItem("string", typeof(string))]
                string[] site, 
                String authToken);

            [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
            string GetSiteInfo(string site, String authToken);

            [WebMethod(Description = WsDescriptions.GetVariableInfoDefaultDesc)]
            string GetVariableInfo(string variable, String authToken);


            [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
            string GetValues(string location, string variable, string startDate, string endDate, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "sitesResponse", IsNullable = false, Type = typeof(SiteInfoResponseType))]
            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            object GetSites(
                [XmlArray("site"), XmlArrayItem("string", typeof(string))]
                string[] site, 
                String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "sitesResponse", IsNullable = false, Type = typeof(SiteInfoResponseType))]
            [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
            object GetSiteInfoObject(string site, String authToken);


            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "variablesResponse", IsNullable = false, Type = typeof(VariablesResponseType))]
            [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
            object GetVariableInfoObject(string variable, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
  ElementName = "timeSeriesResponse", IsNullable = false, Type = typeof(TimeSeriesResponseType))]
            [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
            object GetValuesObject(string location, string variable, string startDate, string endDate, String authToken);


        }

        //        ConformsTo = WsiProfiles.BasicProfile1_1,
        //[WebServiceBinding(Name = WsDescriptions.WsDefaultName, 
        //    ConformsTo = WsiProfiles.BasicProfile1_1, 
        //Namespace = ServiceDescriptions.WS_NAMSPACE )]
        public interface IWaterOneFlowWebService : IService_1_0
        {
            // [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc )]
            string GetSitesXml(string[] sites, String authToken);

            // [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
            string GetSiteInfo(string site, String authToken);

            // [WebMethod(Description = WsDescriptions.GetVariableInfoDefaultDesc)]
            string GetVariableInfo(string variable, String authToken);


            //  [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
            string GetValues(string location, string variable, string startDate, string endDate, String authToken);


            //   [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            object GetSites(string[] site, String authToken);

            //    [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
            object GetSiteInfoObject(string site, String authToken);


            //    [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
            object GetVariableInfoObject(string variable, String authToken);

            //   [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
            object GetValuesObject(string location, string variable, string startDate, string endDate, String authToken);

        }
    }// namespace v1
    namespace Services.v1_1
    {

       using WaterOneFlow.Service.Response.v1_1;
        //using WaterOneFlow.Service.Abstract;
        
        using WaterOneFlow.Service.Constants.v1_1;
          using WaterOneFlow.Schema.v1_1;

        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1,
            Name = WsDescriptions.WsDefaultName,
            Namespace = WaterOneFlow.Service.Constants.v1.ServiceDescriptions.WS_NAMSPACE)]

       public interface IService
        {
            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            string GetSites(string[] site, String authToken);

            [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
            string GetSiteInfo(string site, String authToken);

            [WebMethod(Description = WsDescriptions.GetVariableInfoDefaultDesc)]
            string GetVariableInfo(string variable, String authToken);


            [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
            string GetValues(string location, string variable, string startDate, string endDate, String authToken);

            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            object GetSitesObject(string[] site, String authToken);

            [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
            object GetSiteInfoObject(string site, String authToken);

            [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
            object GetVariableInfoObject(string variable, String authToken);

            [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
            object GetValuesObject(string location, string variable, string startDate, string endDate, String authToken);


        }
   

        //        ConformsTo = WsiProfiles.BasicProfile1_1,
        [WebServiceBinding(Name = WsDescriptions.WsDefaultName,
            ConformsTo = WsiProfiles.BasicProfile1_1,
        Namespace = ServiceDescriptions.WS_NAMSPACE)]
        public interface IWaterOneFlowWebService : IService
        { 
            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
              string GetSitesXml(string[] sites, String authToken);

            [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
              string GetSiteInfo(string site, String authToken);

            [WebMethod(Description = WsDescriptions.GetVariableInfoDefaultDesc)]
              string GetVariableInfo(string variable, String authToken);


            [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
              string GetValues(string location, string variable, string startDate, string endDate, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "sitesResponse", IsNullable = false)]
            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            object GetSites(string[] site, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "sitesResponse", IsNullable = false)]
            [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
            object GetSiteInfoObject(string site, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "variablesResponse", IsNullable = false)]
            [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
            object GetVariableInfoObject(string variable, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "timeSeriesResponse", IsNullable = false)]
            [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
            object GetValuesObject(string location, string variable, string startDate, string endDate, String authToken);

            [return: XmlElement(Namespace = "http://www.cuahsi.org/his/wof",
ElementName = "WOF_Capabilities", IsNullable = false)]
            [WebMethod(Description = "Get Capabilities")]
              WofCapabilities GetCapabilties();
        }
    }// namespace v1_1

    namespace Services.v2_0
    {

       using WaterOneFlow.Service.Response.v2_0;
         //using WaterOneFlow.Service.Abstract;
        using WaterOneFlow.Service.Constants.v1_1;


        //        ConformsTo = WsiProfiles.BasicProfile1_1,
        [WebServiceBinding(Name = WsDescriptions.WsDefaultName,
            ConformsTo = WsiProfiles.BasicProfile1_1,
        Namespace = ServiceDescriptions.WS_NAMSPACE)]
        public abstract class IWaterOneFlowWebService : System.Web.Services.WebService
        {
            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            public abstract string GetSitesString(string[] sites, String authToken);

            [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
            public abstract string GetSiteInfoString(string site, String authToken);

            [WebMethod(Description = WsDescriptions.GetVariableInfoDefaultDesc)]
            public abstract string GetVariableInfoString(string variable, String authToken);


            [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
            public abstract string GetValuesString(string location, string variable, string startDate, string endDate, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "sitesResponse", IsNullable = false)]
            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            public abstract SiteInfoResponseType GetSitesObject(string[] site, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "sitesResponse", IsNullable = false)]
            [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
            public abstract SiteInfoResponseType GetSiteInfoObject(string site, String authToken);


            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "variablesResponse", IsNullable = false)]
            [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
            public abstract VariablesResponseType GetVariableInfoObject(string variable, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "timeSeriesResponse", IsNullable = false)]
            [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
            public abstract TimeSeriesResponseType GetValuesObject(string location, string variable, string startDate, string endDate, String authToken);
            /* 
             * Add methods for
             * * GetMethods
             * * GetSources
             * * GetCapabilities - returns vocabularies/CodeLists
             * */
            [return: XmlElement(Namespace = "http://www.cuahsi.org/his/wof",
       ElementName = "WOF_Capabilities")]
            [WebMethod(Description = "Get Capabilities")]
            public abstract WofCapabilities GetCapabilties();

        }

    }// namespace v2
}
