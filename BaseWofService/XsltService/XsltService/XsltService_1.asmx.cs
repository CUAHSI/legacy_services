using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

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

        /// <summary>
        /// Summary description for Service1
        /// </summary>
        [WebService(Name = WsDescriptions.WsDefaultName,
       Namespace = Constants.WS_NAMSPACE,
       Description = WsDescriptions.WsDefaultDescription)]
        [ToolboxItem(false)]
        public class XsltService_1_0 : IWaterOneFlowWebService
        {

            [WebMethod]
            public string HelloWorld()
            {
                return "Hello World";
            }
        }
    }
}
