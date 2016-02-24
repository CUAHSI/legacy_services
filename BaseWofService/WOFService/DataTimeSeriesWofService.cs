using System;
using System.Collections.Generic;
using System.Text;

using WaterOneFlowImpl;

namespace WaterOneFlow.Service
{
    namespace v1_0
    {
        using WaterOneFlow.Service.Response.v1;

        using WaterOneFlowImpl.v1_0;
        public abstract class DataTimeSeriesWofService : BaseService.v1_0.WofService
        {
            protected DataInfoService dataInfoServiceField;

            public DataInfoService DataInfoService
            {
                get { return dataInfoServiceField; }
                set { dataInfoServiceField = value; }
            }

            protected DataTimeSeriesWofService()
            {

            }

            protected DataTimeSeriesWofService(DataInfoService InfoService)
            {
                DataInfoService = InfoService;
            }


            /// <summary>
            /// Return an object that serializes to 'timeSeriesResponse' 
            /// as defined by the XML schema
            /// <para>TimeSeriesResponseType as compiled by xsd.exe, or a web service response from a different service </para> 
            /// </summary>
            /// <param name="location"></param>
            /// <param name="variable"></param>
            /// <param name="startDate"></param>
            /// <param name="endDate"></param>
            /// <returns></returns>
            public abstract object GetTimeSeries(
                 locationParam location,
                VariableParam variable,
                W3CDateTime? startDate,
                W3CDateTime? endDate);
        }
    }

    namespace v1_1
    {
        using WaterOneFlow.Service.Response.v1_1;

        using WaterOneFlowImpl.v1_1;
        public abstract class DataTimeSeriesWofService: BaseService.v1_1.WofService
        {
            protected DataInfoService dataInfoServiceField;

            public DataInfoService DataInfoService
            {
                get { return dataInfoServiceField; }
                set { dataInfoServiceField = value; }
            }

            protected DataTimeSeriesWofService()
            {

            }

            protected DataTimeSeriesWofService(DataInfoService InfoService)
            {
                DataInfoService = InfoService;
            }



            public abstract object GetTimeSeries(
                 locationParam location,
                VariableParam variable,
                W3CDateTime? startDate,
                W3CDateTime? endDate);
        }
    }
}
