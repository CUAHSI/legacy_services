using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using log4net;
using WaterOneFlow.Service.Nwis;
using WaterOneFlowImpl;

namespace NwisWOFService
{
 using WaterOneFlow.Schema.v1;
    using WaterOneFlowImpl.v1_0;

    namespace v1_0
    {
    public class USGSCommon
    {
        private static ILog log = LogManager.GetLogger(typeof(USGSCommon));

        static string statCodeDefault = "00003";
        private static string agencyCodeDefault = "USGS";

             public static TsValuesSingleVariableType CreateTimeSeriesValuesElement(
            VariableParam vp,
            string aURL)
             {
                 return CreateTimeSeriesValuesElement(vp, aURL, false);
             }

       public static TsValuesSingleVariableType CreateTimeSeriesValuesElement(
            //TimeSeriesResponseType result,
            VariableParam vp,
            string aURL, 
           Boolean provisional)
        {
            // add the URL to be requested to the result
            //result.queryInfo.queryURL = aURL;

            // download the iformation
            String resultFile = GetHTTPFile(aURL, 10);

            //result.timeSeries.values = new TsValuesSingleVariableType();
            //result.TimeSeries.Values.valueUnits = units; // this needs to be done earlier
           TsValuesSingleVariableType values = new TsValuesSingleVariableType();

            DataTable aTable = NWISDelimitedTextParser.ParseFileIntoDT(resultFile);

            // dwv add code to get the code, and use that to find the correct columns
            int time = 2; // present location of time column
           // String code = result.timeSeries.variable.variableCode[0].Value;
             String code = vp.Code;
           String stat = null;
           
           try
           {
               stat = option2UsgsStatCode(vp);
           } catch (Exception ex)
           {
               log.Debug("option2UsgsStatCode() failed :"+ ex.ToString());
               stat = null;
           }

            int aValue;
            int qualifier;
            //if (result.timeSeries.variable.options != null)
            //{
            //    stat = result.timeSeries.variable.options[0].Value;
            //}

            try
            {
                aValue = getVarColumn(aTable, code, stat);
                qualifier = getVarQualifiersColumn(aTable, code, stat);
            }
            catch (WaterOneFlowException we)
            {
                /* even I'm confused here...
                 * parsing column names gives an error
                 * 
                 * This is post data rereiveal, so
                 * if we do not find the correct column, then throw an error
                 * */
                string mess = "BAD COLUMN HEADER FROM USGS URL: " + aURL ;
                // need to insert the URL in the exception
                if (string.IsNullOrEmpty(stat))
                {
                    log.Error("Bad Column varCode:" + code + " stat_cd:NULL "+ mess, we);
                    throw new WaterOneFlowSourceException("Improper COLUMN HEADER FROM USGS URL: "  + aURL, we);
                    //+"' variable '"+code+"' not found at site.");
                }
                else
                {
                    log.Error("Bad Column varCode:" + code + " Stat_cd: " +stat + "  "+ mess, we);
                    throw new WaterOneFlowSourceException("Improper COLUMN HEADER FROM USGS URL: "  + aURL, we);
                    //+ "' variable '"+code+"' statistic '"+stat +"' not found at site. Try not using the statistic", we);
                }
            }

            List<ValueSingleVariable> tsTypeList = new List<ValueSingleVariable>();

            TimeSeriesFromRDB(aTable, time, aValue, qualifier, 
                tsTypeList, provisional);

            values.count = tsTypeList.Count.ToString();
            values.value = tsTypeList.ToArray();
           if (provisional)
           {
               List<qualifier> quals = new List<qualifier>();
               if (values.qualifier !=  null)
               {
                   quals = new List<qualifier>(values.qualifier);
               } 
               // this code is take from the daily values remark code
               // unit values just says provisional data in the header
               qualifier qual = new qualifier();
               qual.qualifierCode = "P";
               qual.network = "USGS";
               qual.vocabulary = "dv_rmk_cd";
               qual.Value = "Provisional data subject to revision.";
               quals.Add(qual);
               values.qualifier = quals.ToArray();
               }
           
           return values;
        }

        

        #region http wrapper
        public static string GetHTTPFile(string strURL, int SecondsToRespond)
        {
            Encoding encode = Encoding.GetEncoding("utf-8");
            WebRequest myWebRequest = WebRequest.Create(strURL);
#if DEBUG
            HttpWebRequest aRequest = myWebRequest as HttpWebRequest;
            if (aRequest != null)
               log.Info("Answering IPAddress: " + (aRequest).Address.OriginalString);
#endif
            myWebRequest.Timeout = SecondsToRespond * 10000;
            WebResponse myWebResponse;
            myWebResponse = myWebRequest.GetResponse();
            if (myWebResponse.ContentType.StartsWith(@"text/html"))
                throw new WaterOneFlowSourceException("No Data (HTML) response from external resource. Requested Service URL: '" + strURL + "'");
            Stream ReceiveStream = myWebResponse.GetResponseStream();
            StreamReader readStream = new StreamReader(ReceiveStream, encode);
            string returnable = readStream.ReadToEnd();
            readStream.Close();
            return returnable;
        }
#endregion

        #region parseColumn Headers

        #region varColumn
        /// <summary>
        /// This class is to allow for the matching of the varcolum
        /// 
        /// </summary>
        private class varColumn
        {

            public string columnTitle = null;
            public string instrument = null;
            public string parameter = null;
            public string statistic = null;
            public Boolean isCd = false;

            public varColumn(string colHeader)
            {
                // create that statistic values
                  
                columnTitle = colHeader;
                string[] temp = colHeader.Split(new string[] { "_" }, StringSplitOptions.None);
                switch (temp.Length)
                {
                    case 1:
                        parameter = temp[0];
                        break;
                    case 2:
                        if (temp[1].Equals(UsgsStatistic.Code["qualifiers"]))
                        {
                            isCd = true;
                            parameter = temp[0];
                        }
                        else
                        {
                            instrument = temp[0];
                            parameter = temp[1];
                        }
                        break;
                    case 3:
                        instrument = temp[0];
                        parameter = temp[1];
                        if (temp[2].Equals(UsgsStatistic.Code["qualifiers"]))
                        {
                            isCd = true;
                        }
                        else
                        {
                            statistic = temp[2];
                        }
                        break;
                    case 4:
                        instrument = temp[0];
                        parameter = temp[1];
                        statistic = temp[2];
                        if (temp[3].Equals(UsgsStatistic.Code["qualifiers"]))
                        {
                            isCd = true;
                        }
                        break;
                    default: // >4
                        if (colHeader.Equals("sample_start_time_datum_cd"))
                        {
                            instrument = "sample";
                            parameter = "start_time";
                            statistic = "datum";
                            isCd = true;

                        }
                        else
                        {
                            instrument = temp[0];
                            parameter = temp[1];
                            statistic = temp[2];
                            if (temp[temp.Length - 1].Equals(UsgsStatistic.Code["qualifiers"]))
                            {
                                isCd = true;
                            }
                        }
                        break;
                    // default should really should log an error... its a bad column name
                }



            }
            public Boolean match(String var)
            {
                if (parameter.Equals(var)) { return true; }
                else
                {
                    return false;
                }

            }
            public Boolean match(String var, String stat)
            {
                if (parameter.Equals(var))
                {
                    if (statistic.Equals(stat))
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            public Boolean exactMatch(String var)
            {
                if (columnTitle.Equals(var))
                {
                    return true;

                }
                else
                {
                    return false;

                }
            }
        }
#endregion

        #region stat_cd creator
       private static string option2UsgsStatCode(VariableParam vp)
       {
           string usgsStatCode = null;

           if (vp.options.ContainsKey("statistic"))
           {
               usgsStatCode = vp.options["statistic"];

           }
           else if (vp.options.ContainsKey("datatype"))
           {
               Hashtable statMap = new Hashtable(CaseInsensitiveHashCodeProvider.DefaultInvariant,
                   CaseInsensitiveComparer.DefaultInvariant);
               statMap.Add("average", "00003");
               statMap.Add("minimum", "00002");
               statMap.Add("maximum", "00001");
               statMap.Add("Cumulative", "00006");
               statMap.Add("median", "00008");
               statMap.Add("variance", "00010");
               statMap.Add("instantaneous", "00011");
               /* not defined by ODM
               statMap.Add("mode",  "00007");    
               statMap.Add("STD",  "00009");
               statMap.Add("SKEWNESS",  "00013");
                */
               string stat = vp.options["datatype"];
               if (statMap.ContainsKey(stat))
               {
                   usgsStatCode = (string)statMap[stat];

               }
               else
               {
/* unrecognized code... 
 * send an ERROR back
 *   build a list of possible values
 * reutrn error
 * */
                   StringBuilder statNames = new StringBuilder();
                   foreach (String key in statMap.Keys)
                   {
                        //   build a list of possible values
                       statNames.AppendFormat(" '{0}'", key);
                      
                   }
                   throw new WaterOneFlowException("Bad datatype option: " +
                       "Only Accepted names:" +
                       statNames.ToString());
               }

           }
           else
           {
               usgsStatCode = statCodeDefault;
           }

           return usgsStatCode;

       }
        #endregion

       public static int getVarColumn(DataTable aTable, String aCode, String stat)
        {
            int colCode = -1;
            //String colCode ;

            /* NOTE: This will return only the first matching instrument.
             * logic needed
            / this will look at column names that are formated as:
            * insturment_code_statistic  (statistic:min=00001,mean=00002,max=00004)
            * insturment_code_cd

            if variable/parameter has a stat
            */

            /*
             * if (aCode.Equals("00060"))
            {
                colCode = aCode + "_" + Statistic["mean"];
            } else {
                colCode = aCode;
            }
             */
            // NOTE SAME CODE BLOCK IS USED IN getVarQualifiersColum
            // except for break after new vc.
            foreach (DataColumn aCol in aTable.Columns)
            {

                /*
                 * if (aCol.ColumnName.EndsWith(colCode))

                {
                    stat = aCol.Ordinal;
                    break;
                }
                 */
                if (colCode > -1) break; // column has already been found
                varColumn vc = new varColumn(aCol.ColumnName);
                if (vc.isCd) continue;

                if (vc.exactMatch(aCode))
                {
                    colCode = aCol.Ordinal;
                    break;
                }

                if (aCode.Equals("00060") || aCode.Equals("00065"))
                {
                    // logic match if there is or is not a stat
                    // TODO: find place to look up stat
                    if (vc.statistic != null) // has a statistic
                    {
                        // if there is an option passed in, then use it
                        if (string.IsNullOrEmpty(stat))
                        {
                            if (vc.match(aCode, UsgsStatistic.Code["mean"]))
                            {
                                colCode = aCol.Ordinal;
                                break;
                            }
                        }
                        else
                        {
                            if (vc.match(aCode, UsgsStatistic.Code[stat]))
                            {
                                colCode = aCol.Ordinal;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (vc.match(aCode))
                        {
                            colCode = aCol.Ordinal;
                            break;
                        }
                    }
                }
                else
                {
                    if (vc.match(aCode))
                    {
                        colCode = aCol.Ordinal;
                        break;
                    }
                }



            }
            if (colCode == -1)
            {
                if (string.IsNullOrEmpty(stat))
                {
                    throw new WaterOneFlowException(" Variable '" + aCode + "' not found at site");
                }
                else
                {
                    throw new WaterOneFlowException(" Variable '" + aCode + " statistic:'" + stat + "' not found at site.");
                }
            }
            else
            {
                return colCode;
            }
        }
        
        public static int getVarQualifiersColumn(DataTable aTable, String aCode, String stat)
        {
            int colCode = -1;
            //String colCode ;
            /*  NOTE: This will return only the last matching instrument.
             * logic needed
            / this will look at column names that are formated as:
            * insturment_code_statistic  (statistic:min=00001,mean=00002,max=00004)
            * insturment_code_cd

            if variable/parameter has a stat
            */

            // NOTE SAME CODE BLOCK IS USED IN getVarsColumn
            foreach (DataColumn aCol in aTable.Columns)
            {
                /*
                * if (aCol.ColumnName.EndsWith(colCode))

               {
                   stat = aCol.Ordinal;
                   break;
               }
                */
                if (colCode > -1) break; // column has already been found                
                varColumn vc = new varColumn(aCol.ColumnName);
                if (!vc.isCd) continue;

                if (vc.exactMatch(aCode))
                {
                    colCode = aCol.Ordinal;
                    break;
                }
                if (aCode.Equals("00060") || aCode.Equals("00065"))
                {
                    // logic match if there is or isnot a stat
                    // TODO: find palce to look up stat
                    if (vc.statistic != null) // has a statistic
                    {
                        // if there is an option passed in, then use it
                        if (String.IsNullOrEmpty(stat))
                        {
                            if (vc.match(aCode, UsgsStatistic.Code["mean"]))
                            {
                                colCode = aCol.Ordinal;
                                break;
                            }
                        }
                        else
                        {
                            if (vc.match(aCode, UsgsStatistic.Code[stat]))
                            {
                                colCode = aCol.Ordinal;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (vc.match(aCode))
                        {
                            colCode = aCol.Ordinal;
                            break;
                        }
                    }
                }
                else
                {
                    if (vc.match(aCode))
                    {
                        colCode = aCol.Ordinal;
                        break;
                    }
                }
            }
            if (colCode == -1)
            {
                throw new WaterOneFlowException("Variable '" + aCode + "' not found at site");
            }
            else
            {
                return colCode;
            }
        }
#endregion

        public static String usgsTime(Nullable<W3CDateTime> dt)
        {
            string dateOnly;
            if (dt.HasValue)
            {
                dateOnly = dt.Value.DateTime.ToString("yyyy-MM-dd");
                return dateOnly;
            }
            else
            {
                return "";
            }

        }

       public static string usgsTimePeriodQP(Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate)
        {
            StringBuilder qp = new StringBuilder("&date_format=YYYY-MM-DD");
            qp.Append("&begin_date=");
            qp.Append(usgsTime(startDate));
            if (endDate != null)
            {
                qp.Append("&end_date=");
                qp.Append(usgsTime(endDate));
            }
            return qp.ToString();
        }

       public static string usgsUnitValuesPeriod(Nullable<W3CDateTime> startDate, Nullable<W3CDateTime> endDate)
        {
            string period = "&period=";
            if (startDate.HasValue)
            {
                try
                {
                    TimeSpan span = DateTime.Today.Subtract(startDate.Value.DateTime);

                    return period + (span.Days + 1).ToString();

                }
                catch
                {
                    // log an error
                    return period + "7";
                }
            }
            else
            {
                return period + "7";
            }


        }

       public static string usgsStationQP(String[] stations)
        {
            StringBuilder qp = new StringBuilder();
            if (stations.Length > 0)
            {
                qp.Append("&site_no=");
                qp.Append(stations[0]);
                for (int i = 1; i < stations.Length; i++)
                {
                    qp.Append(",");
                    qp.Append(stations[i]);
                }

            }
            return qp.ToString();
        }
       public static string usgsVariablesQP(String[] variables)
        {
            StringBuilder qp = new StringBuilder();
            if (variables.Length > 0)
            {
                qp.Append("&parameter_cd=");
                qp.Append(variables[0]);
                for (int i = 1; i < variables.Length; i++)
                {
                    qp.Append(",");
                    qp.Append(variables[i]);
                }

            }
            return qp.ToString();
        }



        /// <summary>
        /// This will add a qualifer, and if appropriate censorCode value to the  tsTypeValue type, if appropriate.
        ///  
        /// </summary>
        /// <param name="tsTypeValue">tsValuesTypeValue to populate</param>
        /// <param name="qualifier">qualifier field to parse, and look for tags that indicate that an item should be censored.</param>
        public static void parseQualifiersForCensorCode(ValueSingleVariable tsTypeValue, String qualifier)
        {
            if (!string.IsNullOrEmpty(qualifier))
            {

                if (qualifier.Contains("<"))
                {
                    tsTypeValue.censorCode = CensorCodeEnum.lt;
                    tsTypeValue.censorCodeSpecified = true;
                    qualifier = qualifier.Replace("<", "");

                }
                if (qualifier.Contains(">"))
                {
                    tsTypeValue.censorCode = CensorCodeEnum.gt;
                    tsTypeValue.censorCodeSpecified = true;
                    qualifier = qualifier.Replace(">", "");
                }
                if (!string.IsNullOrEmpty(qualifier)) tsTypeValue.qualifiers = qualifier;
            }
        }

        public static void TimeSeriesFromRDB(DataTable aTable, int time, int aValue, int qualifier, List<ValueSingleVariable> tsTypeList, bool provisional)
        {
            TimeSeriesFromRDB(aTable, time, aValue, qualifier, tsTypeList, provisional, 0, 0, "Unknown");
        }

        public static void TimeSeriesFromRDB(DataTable aTable, int time, int aValue, int qualifier, List<ValueSingleVariable> tsTypeList, bool provisional, int sourceId, int methodId, string qualityControlLevel)
        {
            foreach (DataRow aRow in aTable.Rows)
            {
                try
                {
                    ValueSingleVariable tsTypeValue = new ValueSingleVariable();
                    tsTypeValue.dateTime = Convert.ToDateTime(aRow[time]);
                    //tsTypeValue.dateTimeSpecified = true;
                    //tsTypeValue.censored = string.Empty;
                    if (string.IsNullOrEmpty(aRow[aValue].ToString()))
                        continue;
                    else
                        tsTypeValue.Value = Convert.ToDecimal(aRow[aValue]);
                    parseQualifiersForCensorCode(tsTypeValue, aRow[qualifier].ToString()); // this will add censored, if appropariate
                    
                    if (provisional)
                    {
                        if(tsTypeValue.qualifiers!= null) {
                            if (string.IsNullOrEmpty(tsTypeValue.qualifiers) )
                        {
                            tsTypeValue.qualifiers = "P";
                        } else
                            {
                                tsTypeValue.qualifiers += "P";
                            }
                        } else
                        {
                            tsTypeValue.qualifiers = "P";
                        }
                    }
                    tsTypeList.Add(tsTypeValue);
                }
                catch (Exception e)
                {
                    // just ignore any value errors
                }
            }
        }

        public static SourceType USGSSourceInformation(int sourceId)
        {
            SourceType usgsSource = new SourceType();
            usgsSource.sourceID = sourceId;
            usgsSource.sourceIDSpecified = true;
            usgsSource.SourceLink = "http://waterdata.usgs.gov/";
            usgsSource.Organization = "USGS";
            usgsSource.SourceDescription = "US Geological Survey";

            return usgsSource;
        }

        public static MethodType UnknownMethod(int sourceId)
        {
            MethodType method = new MethodType();
            method.methodID = sourceId;
            method.methodIDSpecified = true;
            method.MethodLink = "http://waterdata.usgs.gov/";
            method.MethodDescription = "Unknown";
            

            return method;
        }
        public static qualityControlLevel UnknownQualityControlLevel(int sourceId)
        {
            qualityControlLevel qualityControlLevel = new qualityControlLevel();
            qualityControlLevel.qualityControlLevelID = sourceId.ToString();
            qualityControlLevel.qualityControlLevelCode = "Unknown";
            qualityControlLevel.vocabulary = "CUAHSI" ;
            qualityControlLevel.@default = true;
            qualityControlLevel.defaultSpecified = true;
            return qualityControlLevel;
        }

        public static string option2AgencyCode(VariableParam vp)
        {
            string usgsAgencyCode = agencyCodeDefault;

            if (vp.options.ContainsKey("agency"))
            {
                usgsAgencyCode = vp.options["agency"];

            }
            return usgsAgencyCode;
        }

        public static string option2AgencyCode(locationParam vp)
        {
            string usgsAgencyCode = agencyCodeDefault;

            if (vp.options.ContainsKey("agency"))
            {
                usgsAgencyCode = vp.options["agency"];

            }
            return usgsAgencyCode;
        }

    }
}
}
