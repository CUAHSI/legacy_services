using System;
using System.Collections.Generic;
using System.Text;
using WaterOneFlow.Schema.v1;
using WaterOneFlow.Service.v1_0;
using WaterOneFlowImpl;
using VariableParam=WaterOneFlowImpl.v1_0.VariableParam;

namespace RestServiceClient
{
    namespace Generic.v10
    {
        public class RestDataTimeSeriesWofService : DataTimeSeriesWofService
        {
            public override object GetTimeSeries(locationParam location, VariableParam variable, W3CDateTime? startDate, W3CDateTime? endDate)
            {
                BaseRestClient restServiceClient;
                string[] parameters;

                {
                    restServiceClient = new BaseRestClient();
                    restServiceClient.BaseUrl = "http://www2.mvr.usace.army.mil/watercontrol/webservices/rest/webserviceWaterML.cfm?";
                    restServiceClient.PathFormat = "Meth={0}&site={1}&variable={2}&beginDate={3}&endDate={4}";

                    string varCode = variable.Code; // prep for many test
                    string siteCode = location.SiteCode;


                    Type vType = typeof(TimeSeriesResponseType);
                    restServiceClient.ResponseType = vType;
                    parameters = new string[5];
                    parameters[0] = "getValues";
                    parameters[1] = siteCode;
                    parameters[2] = varCode;
                    parameters[3] = startDate.Value.DateTime.ToString("yyyy-MM-dd");
                    parameters[4] = endDate.Value.DateTime.ToString("yyyy-MM-dd");

                    object res = restServiceClient.GetResponseAsObject(parameters);
                    return res;
                }

            }

        }

    }
}
