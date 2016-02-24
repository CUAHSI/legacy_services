using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using WaterOneFlow.Service.Data.V1_0;
using WaterOneFlowImpl;
using DataValuesService = WaterOneFlow.Service.v1_0.DataTimeSeriesWofService;

namespace WaterOneFlow.Service.Source
{
    namespace v1_0
    {
        
    
    using VariableParam = WaterOneFlowImpl.v1_0.VariableParam;
    using DataInfoService = WaterOneFlow.Service.v1_1.DataInfoService;

       public  class GetDataValuesDB : DataValuesService
    {

           private SqlConnection sqlConn;

           public SqlConnection Connnection
           {
               get { return sqlConn; }
               set { sqlConn = value; }
           }


           public override object GetTimeSeries(locationParam location, VariableParam variable, W3CDateTime? startDate, W3CDateTime? endDate)
           {
               if (DataInfoService == null)
               {
                   throw new Exception("You Must set the DataInfoService");
               }

               /* get SiteID and VariableID from dataInfoService
                * Setup Query
                * If boths dates valid use one query
                * Else use second 
                * 
                */
               using (sqlConn)
               {
                   
                   throw new System.NotImplementedException();
               }
           }

    }
}
}
