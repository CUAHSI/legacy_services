using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using NwisWOFService.UsgsDbDailyValuesTableAdapters;
using WaterOneFlow.Schema.v1;
using WaterOneFlowImpl;
using WaterOneFlow.ws;

namespace NwisWOFService
{
    public  class GetDataInformationDailyDB
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GetDataInformationDailyDB));
 
      
#region variables

        public VariablesResponseType GetVariables(VariableParam[] variables)
        {
            UsgsDbDailyValues.VariablesDataTable vDs = new UsgsDbDailyValues.VariablesDataTable();

            UsgsDbDailyValuesTableAdapters.VariablesTableAdapter TableAdapter = new VariablesTableAdapter();
            
            List<VariableInfoType> vList = new List<VariableInfoType>();

            // if nothing. get it all
            if (variables == null || variables.Length == 0)
            {
                try
                {
                    TableAdapter.Fill(vDs);
               } catch
                {
                    log.Error("Cannot connect to USGS Database");
                    throw new WaterOneFlowServerException("Server Error: Cannot Connect to Database");
                }
                    
                if (vDs.Rows.Count > 0)
                    {
                        foreach (UsgsDbDailyValues.VariablesRow vRow
                            in vDs)
                        {


                            VariableInfoType vit = RowToVariable(vRow);

                            if (vit != null) vList.Add(vit);

                        }
                    }
                
            }
            else
            {
                foreach (VariableParam v in variables)
                {
                    UsgsDbDailyValues.VariablesRow[] vRows;
                    try
                    {
                        TableAdapter.FillByVariableCode(vDs, v.Code);
                        
             string where = VariableOptions2WhereClause(v);  /* Use Caution, where clause not SQL inject safe. */
                         vRows = (UsgsDbDailyValues.VariablesRow[])
                                                               vDs.Select(where);
                    }
                    catch
                    {
                        log.Error("Cannot connect to USGS Database");
                        throw new WaterOneFlowServerException("Server Error: Cannot Connect to Database");
                    }
                        if (vRows.Length > 0)
                        {
                            foreach (UsgsDbDailyValues.VariablesRow vRow
                                in vRows)
                            {


                                VariableInfoType vit = RowToVariable(vRow);

                                if (vit != null) vList.Add(vit);

                            }
                        }
                }
                 
            } 
         
                //if (vDs.Rows.Count > 0)
                //{
                //    foreach (UsgsDbDailyValues.VariablesRow vRow 
                //        in vDs)
                //    {
                        
                      
                //            VariableInfoType v = RowToVariable(vRow);
                      
                //        if (v != null) vList.Add(v);
                    
                //    }
                //}
                VariablesResponseType vRes = new VariablesResponseType();
                if (vList != null && vList.Count > 0)
                {
                    // build response

                    vRes.variables = vList.ToArray();
                }
                else
                {
                    log.Info("User Error: No Variables Returned");
                    throw new WaterOneFlowException("No Variables Returned. Submit with no values to get full list.");
                }
            return vRes;
        }

        private string VariableOptions2WhereClause(VariableParam vp)
        {
            /* 
             * Use Caution, not SQL inject sade.
             * But safe, since it is used to generate a where clause
             * for an unattached ADO.NET dataset.
             * 
             */

            /* this allows for renaming of the option values,
             * case insensetive comparison
             * multiple data types in where
             * */
            Dictionary<string, string> stringConstraints = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            stringConstraints.Add("statistic","stat_cd");
            stringConstraints.Add("datatype","DataType");
            stringConstraints.Add("samplemedium","SampleMedium");

            Dictionary<string, string> numericConstraints = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            numericConstraints.Add("variableID","VariableID");

            StringBuilder where = new StringBuilder();
            int constraintCount = 0;
            
            foreach (string opt in vp.options.Keys)
            {
                if (stringConstraints.ContainsKey(opt))
                {
                   if (constraintCount > 0)
                   {
                       where.Append(" AND ");
                   }
                    where.AppendFormat(" {0} = '{1}' ", stringConstraints[opt], vp.options[opt]);
                    constraintCount ++;
                }
                if (numericConstraints.ContainsKey(opt))
                {
                    if (constraintCount > 0)
                    {
                        where.Append(" AND ");
                    }
                    where.AppendFormat(" {0} = {1} ", numericConstraints[opt], vp.options[opt]);
                    constraintCount++;
                }

            }
            return where.ToString();
        }
  
        
            private VariableInfoType RowToVariable(UsgsDbDailyValues.VariablesRow vRow)
        {
            VariableInfoType vit;
            String vCode = vRow.IsVariableCodeNull() ? null : vRow.VariableCode;
            String vName = vRow.IsVariableNameNull() ? null : vRow.VariableName;
            //String vDescr = 
            String uName = vRow.IsUnitsNull() ? null : vRow.Units;
            String uAbbrev = vRow.IsUnitAbbreviationNull() ? null : vRow.UnitAbbreviation;
            String uType = vRow.IsUnitTypeNull() ? null : vRow.UnitType;
            String uCode = null; // ID is code

            if (!vRow.IsVariableUnitsIDNull())
            {
                uCode = vRow.VariableUnitsID.ToString();
            }

            UnitsTypeEnum uTypeEnum = (UnitsTypeEnum) CoreBuilder.GetTextAsEnum(uType,typeof(UnitsTypeEnum));
            
            units vUnit = CuahsiBuilder.CreateUnitsElement(
                uTypeEnum,
                uCode, uAbbrev, uName);

            /* this needs to be fixed to accept value type and data type
             *  and time options
             */
            vit = CuahsiBuilder.CreateVariableInfoType(
                null,   // don't want variable ID exposed in the NWIS service
                "NWIS",
                vRow.VariableCode,
                vRow.VariableName,
                null,
                vUnit // units
                );
            
            CoreBuilder.SetEnumFromText(vit,vRow,"valueType",typeof(valueTypeEnum));
            CoreBuilder.SetEnumFromText(vit, vRow, "dataType", typeof(dataTypeEnum));

                // add usgs statistic code options
                if (!vRow.Isstat_cdNull())
                {
                   List<option> opts = new List<option>(1);
                   option opt = new option();
                   opt.name = "statistic";
                   opt.optionCode = vRow.stat_cd;
                    opts.Add(opt);
                    vit.options = opts.ToArray();
                }

                if (!vRow.IsisRegularNull() && vRow.isRegular)
                {
                    vit.timeSupport = new VariableInfoTypeTimeSupport();
                    vit.timeSupport.isRegular = vRow.isRegular;
                    vit.timeSupport.isRegularSpecified = true;
                   
                    // add time support

                    // check to be sure we've got some vaild stuff
                   if (!vRow.IsTimeSupportNull())
                   {
                       int timeInterval;
                     if (  Int32.TryParse(vRow.TimeSupport,out timeInterval)) {
                         vit.timeSupport.timeInterval = timeInterval;
                         vit.timeSupport.timeIntervalSpecified = true;
}
                   }
                   if (!vRow.IsTimeUnitsIDNull())
                   {

                       vit.timeSupport.unit = new UnitsType();
                       vit.timeSupport.unit.UnitID = 104;
                       vit.timeSupport.unit.UnitIDSpecified = true;
                       vit.timeSupport.unit.UnitDescription = "day";
                       vit.timeSupport.unit.UnitAbbreviation ="d";
                       vit.timeSupport.unit.UnitType = (UnitsTypeEnum)CoreBuilder.GetTextAsEnum("Time", typeof(UnitsTypeEnum));;


                   }
                     


                }     

            return vit;
        }
        
            
       
    
#endregion

        #region site

    public SiteInfoType[] GetSites (locationParam[] lp )
    {
        
        List<SiteInfoType> sites = new List<SiteInfoType>();
        UsgsDbDailyValues.sitesDataTable sDs = new UsgsDbDailyValues.sitesDataTable();
        UsgsDbDailyValuesTableAdapters.sitesTableAdapter tableAdaptor = new sitesTableAdapter();


        if (lp == null || lp.Length == 0 )
        {
            // get all sites
            tableAdaptor.Fill(sDs);
            
        } else
        {
            foreach (locationParam loc in lp )
            {
                tableAdaptor.FillBySiteCode(sDs,loc.SiteCode);
            } 
        }

        foreach (UsgsDbDailyValues.sitesRow row in sDs.Rows)
        {
            SiteInfoType sit = row2SiteInfoType(row);
            if (sit != null) sites.Add(sit);
        }
         
        if (sites.Count > 0) {
        return sites.ToArray();
        } else
        {
            throw new WaterOneFlowException("No Sites Found");
        }
    }


        private static SiteInfoType row2SiteInfoType(UsgsDbDailyValues.sitesRow row)
        {
            SiteInfoType sit = null;

            if (row == null ||row.IsSiteCodeNull()|| row.IsSiteNameNull()) return null;

            //string siteCode = row.SiteCode;
            //string siteName = row.SiteName;
            //float? lat = null, lon=null;
            //string srs;

            //if (! row.IsLatitudeNull() )  lat = row.Latitude;
            //if(!row.IsLatitudeNull()) lon = row.Longitude;


            //sit =  CoreBuilder.CreateASiteInfoTypeWithLatLongPoint(
            //    "NWIS", siteCode, siteName, lat, lon
            //    );
            sit = CoreBuilder.createSiteInfoRecord(row);

            //TODO: USGS items as notes
            // add agency note
            if (!row.Isusgs_agencyNull()){
                note n = new note();
                n.title = "agency";
                n.Value = row.usgs_agency;
                sit.note = CoreBuilder.addNote(sit.note, n);
            }

            // add siteType note
            if(!row.Isusgs_station_typeNull())
            {
                note n = new note();
                n.title = "SiteType";
                n.Value = row.usgs_station_type;
                sit.note = CoreBuilder.addNote(sit.note, n);
            }
            return sit;
        }

        #endregion sites 

        #region series
        // do one at a time

        public seriesCatalogType[] GetSeries(locationParam lp)
        {

            // for this we are only doing one, but multiple can come back
            List<seriesCatalogType> seriesCatalogs = new List<seriesCatalogType>();
        
// seriesCatalog is built from array of series
#region build series
            {

List<seriesCatalogTypeSeries> series = new List<seriesCatalogTypeSeries>();
            UsgsDbDailyValues.seriesCatalogDataTable scDs =  new UsgsDbDailyValues.seriesCatalogDataTable();
            UsgsDbDailyValuesTableAdapters.seriesCatalogTableAdapter tableAdaptor = new seriesCatalogTableAdapter();
            

            if (lp != null)
            {
                 if (lp.SiteCode != null)   tableAdaptor.FillBySiteCode(scDs, lp.SiteCode);

            }

            
            foreach (UsgsDbDailyValues.seriesCatalogRow row in scDs.Rows)
            {
               seriesCatalogTypeSeries s = row2Series(row);
                if (s!=null) series.Add(s);

            }

                // add the list of series to the 
              seriesCatalogType aCatalog = new seriesCatalogType();
                aCatalog.series = series.ToArray();
                seriesCatalogs.Add(aCatalog);
        }
#endregion
            return seriesCatalogs.ToArray();
        }

        private static seriesCatalogTypeSeries row2Series(UsgsDbDailyValues.seriesCatalogRow aRow)
        {
           if (aRow.IsVariableCodeNull() ) return null;

            string VariableCode = aRow.VariableCode;

            string VariableName = null;
            string VariableUnitName = null;
            string VariableUnitAbrreviation = null;
            string VariableUnitCode = null;
            string sampleMedium = null;
            string dataType = null;
            string valueType = null;
            string generalCategory = null;
            W3CDateTime? beginDateTime = null,  endDateTime = null;
            int? valueCount = null;
            bool? valueCountIsEstimated = null;
            int? TimeInterval = null;
            string TimeIntervalUnits = null;
            bool isRealTime = false;
            string QualityControlLevelTerm = null;
            string methodName = null;
            string organization = null;
            string sourceDescription = null;
            if (!aRow.IsVariableNameNull()) VariableName = aRow.VariableName;
            
            if (!aRow.IsVariableUnitsAbbreviationNull()) VariableUnitAbrreviation = aRow.VariableUnitsAbbreviation;
            if (!aRow.IsVariableUnitsNameNull()) VariableUnitName = aRow.VariableUnitsName;

            if (!aRow.IsDataTypeNull()) dataType = aRow.DataType;
            if (!aRow.IsValueTypeNull()) valueType = aRow.ValueType;
            if (!aRow.IsGeneralCategoryNull()) generalCategory = aRow.GeneralCategory;
           
            if (!aRow.IsSampleMediumNull()) sampleMedium = aRow.SampleMedium;
            if (!aRow.IsMethodNameNull()) methodName = aRow.MethodName;



            if (!aRow.IsSourceDescriptionNull()) sourceDescription = aRow.SourceDescription;
            if (!aRow.IsOrganizationNull()) organization = aRow.Organization;

            if (!aRow.IsValueCountNull())
            {
                int v;
                if (Int32.TryParse(aRow.ValueCount,out v)) valueCount = v;
                
            }

            
            if (!aRow.IsBeginDateTimeNull())
            {
               beginDateTime = new W3CDateTime(aRow.BeginDateTime);   
            }
            if (!aRow.IsEndDateTimeNull())
            {
                endDateTime = new W3CDateTime(aRow.EndDateTime);
            }

            if (!aRow.IsTimeSupportNull())
            {
                TimeInterval = aRow.TimeSupport;
                if (!aRow.IsTimeUnitsNameNull())
                {
                    TimeIntervalUnits = aRow.TimeUnitsName;
                }
            }



// public static seriesCatalogTypeSeries CreateSeriesRecord(
//           string VariableCode,
//           string VariableName,
//           string VariableUnitName,
//           string VariableUnitAbrreviation,
//           string VariableUnitCode,
//           string sampleMedium,
//           string dataType,
//           string valueType,
//           string generalCategory,
//           W3CDateTime? beginDateTime, W3CDateTime? endDateTime,
//           int? valueCount,  bool? valueCountIsEstimated,
//           string TimeInterval,
//           string TimeIntervalUnits,
//           bool isRealTime,
//           string QualityControlLevelTerm,
//           string methodName, 
//           string organization, string sourceDescription
           
//)
         seriesCatalogTypeSeries aSeries =  CoreBuilder.CreateSeriesRecord(
                VariableCode,
                VariableName,
                VariableUnitName,
                VariableUnitAbrreviation,
                VariableUnitCode,
                sampleMedium,
                dataType,
                valueType,
                generalCategory,
                beginDateTime, endDateTime,
                valueCount, valueCountIsEstimated,
                TimeInterval,
                TimeIntervalUnits,
                isRealTime,
                QualityControlLevelTerm,
                methodName,
                organization,
                sourceDescription, "NWIS" );

         // add usgs statistic code options
         if (!aRow.Isusgs_stat_cdNull())
         {
             List<option> opts = new List<option>(1);
             option opt = new option();
             opt.name = "statistic";
             opt.optionCode = aRow.usgs_stat_cd;
             opts.Add(opt);
             aSeries.variable.options = opts.ToArray();
         }
            return aSeries;
        }

        #endregion series 
 }
    }
