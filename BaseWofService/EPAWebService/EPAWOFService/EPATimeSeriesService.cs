using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using log4net;
using WaterOneFlow.Service.Constants.v1;
using WaterOneFlow.Service.Data;
using WaterOneFlow.Service.Data.V1_0;
using WaterOneFlow.Service.v1_0;
using WaterOneFlow.Schema.v1;
using WaterOneFlow.Service.v1_0.xsd;
using WaterOneFlowImpl;
using WaterOneFlowImpl.v1_0;

using variableParamVersion=WaterOneFlowImpl.v1_0.VariableParam;

namespace EPAWOFService
{
       using VariablesResponseTypeGeneric = WaterOneFlow.Service.Response.v1_0.VariablesResponseType;
        using SiteInfoResponseTypeGeneric = WaterOneFlow.Service.Response.v1_0.SiteInfoResponseType;
        using TimeSeriesResponseTypeGeneric = WaterOneFlow.Service.Response.v1_0.TimeSeriesResponseType;

        using VariablesResponseTypeObject = WaterOneFlow.Schema.v1.VariablesResponseType;
        using SiteInfoResponseTypeObject = WaterOneFlow.Schema.v1.SiteInfoResponseType;
        using TimeSeriesResponseTypeObject = WaterOneFlow.Schema.v1.TimeSeriesResponseType;
 
    public class GetValuesEPA : DataTimeSeriesWofService
    {
           
 
        private static ILog log = 
                LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
                );
     

        public GetValuesEPA(DataInfoService ds)
            : base(ds)
        {

        }

        [return: XmlElement(
    Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "timeSeriesResponse",
  IsNullable = false
 , Type = typeof(TimeSeriesResponse)   // set in above using statement
    )]
        public override object  GetTimeSeries(
           locationParam lp,
           variableParamVersion vp, 
            W3CDateTime? startDate, 
           W3CDateTime? endDate)
        {
            if ((endDate.HasValue && startDate.HasValue )&& endDate.Value.DateTime <startDate.Value.DateTime)
            {
                throw new WaterOneFlowException("No Data. End Date must be greater than Start Date");
            }

            TimeSeriesResponseType result = null;


            result = CuahsiBuilder.CreateTimeSeriesObject();

            string[] StationsList = new string[] { lp.SiteCode };

            SiteInfoType sit = null;
            try
            {
               sit = DataInfoService.GetSite(lp);
                result.timeSeries.sourceInfo = sit;
            }
            catch (WaterOneFlowException ex)
            {
                log.Info("EPA Bad Site Request" + vp.ToString());
                throw ex;
            }
            catch (WaterOneFlowServerException ex)
            {
                log.Error("EPA  server issued  with Site Request" + vp.ToString());
                throw ex;
            }
            catch (WaterOneFlowSourceException ex)
            {
                log.Error("EPA  source issued  with Site Request" + vp.ToString());
                throw ex;
            }
            catch (Exception ex)
            {
                log.Error("EPA  source issued  with Site Request" + vp.ToString());
                throw new WaterOneFlowServerException("Uncaught Exception in EPA Time series site reuqest", ex);

            }



            result.queryInfo.criteria.locationParam = lp.ToString();
            result.queryInfo.criteria.variableParam = vp.ToString();

            // not fully correct, but just choose the first one.
            VariableInfoType[] vits = null;
            try {

                vits = DataInfoService.GetVariableInfoObject(vp);
                  result.timeSeries.variable = vits[0];
            } catch (WaterOneFlowException ex)
                {
                    log.Info("EPA Bad variable Request" + vp.ToString());
                    throw ex;
                }
            catch (WaterOneFlowServerException ex)
            {
                log.Error("EPA  server issued  with variable Request" + vp.ToString());
                throw ex;      
            } catch (WaterOneFlowSourceException ex)
            {
                log.Error("EPA  source issued  with variable Request" + vp.ToString());
                throw ex;                     
            } catch (Exception ex)
            {
                log.Error("EPA  source issued  with variable Request" + vp.ToString());
                throw new WaterOneFlowServerException("Uncaught Exception in EPA Time series site reuqest", ex);                     
               
            }

            String variableName = result.timeSeries.variable.variableName;

            string agency = GetAgencyEpaSiteCode(lp);
            string siteCode = GetSiteIDEpaSiteCode(lp);

            EPAResults.StoretResultFlatDataTable table  =
                WqxResultsToDataset.GetStationResults(
                agency, siteCode,
                variableName, startDate, endDate);
             if (table.Rows.Count == 0 )
             { // no retults, just go back
                 result.timeSeries.values = new TsValuesSingleVariableType();
                 result.timeSeries.values.count = "0";
                 return result;
             }
            DataRowCollection unitNameRows = EPAResponseUnits(table);

            // for now
            if (unitNameRows.Count >1 )
            {
                            //throw new WaterOneFlowSourceException(
                            //    " EPA Returned more than one unit for request."
                            //    + " This is not supported at the present time" );
                // no longer want an error. return data
                log.Info("EPA STATION WITH MORE THAN ONE UNIT: '"+ lp.ToString());

              }
            /* Logic neded for multiple units
             * select one with max count or latest one?
             * if max get count for each unit
             * For the selected unit, 
             * * create a subtable,
             * * populate values
             * 
             * Future:
             * for each unit
             * *collect a subtable, populate values
             * */

 /* need to creat a units element
  * The units returned, are not necessarily the ones in the series catalog 
  */
            //string unitName = unitNameRows[0].ItemArray[0].ToString().Trim(); 
            //result.timeSeries.variable.units =  CuahsiBuilder.CreateUnitsElement(null, null, unitName, unitName);

            foreach (DataRow row in unitNameRows)
            {
                 string unitName = row.ItemArray[0].ToString().Trim(); 
            result.timeSeries.variable.units =  CuahsiBuilder.CreateUnitsElement(null, null, unitName, unitName);

            StringBuilder  select = new StringBuilder();
                select.AppendFormat("[VariableUnitsAbbreviation]='{0}'", WaterOneFlowImpl.WSUtils.SqlEncode(unitName));
                if (startDate.HasValue)
                {
                    select.AppendFormat(" AND  [localDateTime] > '{0}' ", startDate.Value.DateTime.ToString("s"));
                 }
                if (endDate.HasValue)
                {
                    select.AppendFormat(" AND  [localDateTime] < '{0}' ", endDate.Value.DateTime.AddDays(1).ToString("s"));
                     
                }
                EPAResults.StoretResultFlatRow[] rowsWithUnit = (EPAResults.StoretResultFlatRow[]) table.Select(select.ToString());
                result.timeSeries.values = DataValuesBuilder.CreateValuesElement(rowsWithUnit);

                result.timeSeries.values.unitsAbbreviation = unitName; // abbreviated name is presently returned

            }

            /* for now, just adding the methods, without the reference to the
    * value they came from. That will take a bit of work.
    * need to generate unique methodID's for distinct methods
    * then populate the methodID in the table, 
    * then send to the value generator
    * */
            /***** This can cause more method, if nore than one parameter is returned
             * eg pH presently returns phosphorous
             * */

            DataRowCollection methodNameRows = EPAResponseMethods(table);
            if (methodNameRows != null && methodNameRows.Count > 0)
            {
                List<MethodType> methods;
                if (result.timeSeries.values.method == null)
                {
                   methods = new List<MethodType>(); 
                } else
                {
                    methods = new List<MethodType>(result.timeSeries.values.method);
                }
                foreach (DataRow row in methodNameRows)
                {
                    MethodType method = new MethodType();
                    method.MethodDescription = row.ItemArray[0].ToString();
                methods.Add(method);
                }
                result.timeSeries.values.method = methods.ToArray();
            }
   

            return result;
        }

       
        private DataRowCollection  EPAResponseUnits(EPAResults.StoretResultFlatDataTable table)
        {
            // it is possible for the EPA to return units that are not the same
            // need to add translation, if this happens
            DataTable dt = DataSetHelper.SelectDistinct("units", table, "VariableUnitsAbbreviation");
            return dt.Rows;
        }

        private DataRowCollection EPAResponseMethods(EPAResults.StoretResultFlatDataTable table)
        {
            // it is possible for the EPA to return units that are not the same
            // need to add translation, if this happens
            DataTable dt = DataSetHelper.SelectDistinct("methods", table, "methodName");
            return dt.Rows;
        }

        private static string GetAgencyEpaSiteCode(locationParam lp)
        {
            if (lp.options.ContainsKey("agency"))
            {
                return lp.options["agency"];
            } else {
            string code = lp.SiteCode;
            string[] parts = code.Split(':');
            return parts[0];
            }
        }
        private static string GetSiteIDEpaSiteCode(locationParam lp)
        {
            if (lp.options.ContainsKey("agency"))
            {
                string code = lp.SiteCode;
                string[] parts = code.Split(':');
                // assme that if there is an agency, 
                // then there may be one or two parts to the EPA site code
                if (parts.Length > 1)
                {
                    return parts[1];
                }
                else
                {
                    return parts[0];
                }

            }
            else
            {
                // must be two parts to EPA site code agency:sitecode 
                // full code is EPA:agency:sitecode
                string code = lp.SiteCode;
                string[] parts = code.Split(':');
                if (parts.Length == 2)
                {
                                    return parts[1];
                } else
                {
                    if (parts.Length ==1 )
                    {
                         log.Error("EPA too few  site code should be agency:site" + lp.SiteCode);
                        throw  new WaterOneFlowException("EPA too few  site code should be agency:site" + lp.SiteCode);
                      
                    } else if (parts.Length >2)
                    {
                        
                    }
                        log.Error("EPA too  many parts to site codeshould be EPA:agency:site" + lp.SiteCode);
                    throw  new WaterOneFlowException("EPA too  many parts to site codeshould be EPA:agency:site" +
                                                     lp.SiteCode);
                }

            }
        }
    }
}
