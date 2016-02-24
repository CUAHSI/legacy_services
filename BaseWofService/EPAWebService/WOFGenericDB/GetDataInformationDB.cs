using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using log4net;
using WaterOneFlow.Schema.v1;
using WaterOneFlowImpl;
using WaterOneFlow.ws;

namespace WaterOneFlow.GenericDB
{
    /// <summary>
    /// This class provides access to an database that has ODM tables sructures.
    /// The tables names do not need to match the ODM specification, but they do 
    /// need to have columns as per to ODM 1.0 specification.
    /// <para>
    /// Internally, settings contain the SQL queries.</para>
    /// </summary>
    public class GetDataInformationDB : DataInfoService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GetDataInformationDB));

        private string siteVocabularyField = "Unspecified";

        /// <summary>
        /// Site Vocabuylary, aka Network part of web services location
        /// <para>Network:SiteCode</para>
        /// </summary>
        public string SiteVocabulary
        {
            get { return siteVocabularyField; }
            set { siteVocabularyField = value; }
        }
        private string variableVocabularyField = "Unspecified";

        /// <summary>
        /// Variable Vocabulary
        /// /// <para>Vocabulary:VariableCode</para>
        /// </summary>
        public string VariableVocabulary
        {
            get { return variableVocabularyField; }
            set { variableVocabularyField = value; }
        }

        private string variablesTableNameField;

        /// <summary>
        /// View or Table name of variables
        /// <para>Columns should match the ODM 1.0 spec. Additional Columns are ok.</para>
        /// </summary>
        public string VariablesTableName
        {
            get { return variablesTableNameField; }
            set { variablesTableNameField = value; }
        }
        private string seriesTableNameField;

        /// <summary>
        /// View or Table name of Series
        /// <para>Columns should match the ODM 1.0 spec. Additional Columns are ok.</para>
        /// </summary>
        public string SeriesTableName
        {
            get { return seriesTableNameField; }
            set { seriesTableNameField = value; }
        }
        private string sitesTableNameField;

        /// <summary>
        /// View or Table name of Sites
        /// <para>Columns should match the ODM 1.0 spec. Additional Columns are ok.</para>
        /// </summary>
        public string SitesTableName
        {
            get { return sitesTableNameField; }
            set { sitesTableNameField = value; }
        }

        private string[] SitesParameterNamesField = { "SiteCode"};

        /// <summary>
        /// name of parameter in the application property, SiteCodeQueryFormat
        /// </summary>
        public string[] SitesParameterNames
        {
            get { return SitesParameterNamesField; }
            set { SitesParameterNamesField = value; }
        }

        private string dataInfoConnectionField;

        public string DataInfoConnection
        {
            get { return dataInfoConnectionField; }
            set { dataInfoConnectionField = value; }
        }

        // future
        // private string dataValueConnectionField;

        #region internalstrings
        private static string variablesName = "variables";
        private static string seriesName = "seriesCatalog";
        private static string sitesName = "sites";
        #endregion

        # region Service
        public GetDataInformationDB():base()
        {
        }

        # endregion

        #region variables

        public override VariableInfoType[] GetVariableInfoObject(VariableParam variable)
        {
            if(variable == null)
            {
                throw new WaterOneFlowException("No Variables submitted");
            }

            VariableParam[] variables = new VariableParam[1];
            variables[0] = variable;

            VariableInfoType[] vit = GetVariableInfoObject(variables);

            
            if (vit != null && vit.Length > 0)
            {
                // build response

               return  vit;
            }
            else
            {
                log.Info("User Error: No Variables Returned");
                throw new WaterOneFlowException("No Variables Returned. Submit with no values to get full list.");
            }

        }

        public override VariableInfoType[] GetVariableInfoObject(VariableParam[] variables)
        {
 

            DataSet vDs = new DataSet();
            List<VariableInfoType> vList = new List<VariableInfoType>();

            // if nothing. get it all
            if (variables == null || variables.Length == 0)
            {
                try
                {
                    // TableAdapter.Fill(vDs);
                    string variableQuery = string.Format(Properties.Settings.Default.getAllQueryFormat, VariablesTableName);
                    SqlDataAdapter dst = new SqlDataAdapter(variableQuery, DataInfoConnection);
                    dst.Fill(vDs, variablesName); // populate variable table name

                }
                catch
                {
                    log.Error("Cannot connect to CUASHI USGS Database");
                    throw new WaterOneFlowServerException("Server Error: Cannot Connect to required Database");
                }

                DataTable vDt = vDs.Tables[variablesName];

                if (vDt.Rows.Count > 0)
                {
                    foreach (DataRow vRow
                        in vDt.Rows)
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
                    DataRow[] vRows;
                    try
                    {
                        // TableAdapter.FillByVariableCode(vDs, v.Code);
                        using (SqlConnection conn = new SqlConnection(DataInfoConnection))
                        {
                            string variableQuery = string.Format(Properties.Settings.Default.VariableCodeQueryFormat, VariablesTableName);

                            SqlCommand command = new SqlCommand(variableQuery, conn);
                            SqlParameter vCodeParam = new SqlParameter("variableCode", v.Code);
                            command.Parameters.Add(vCodeParam);
                            SqlDataAdapter dst = new SqlDataAdapter(command);
                            dst.Fill(vDs, variablesName); // populate variable table name
                        }
                        DataTable vDt = vDs.Tables[variablesName];

                        string where = VariableOptions2WhereClause(v);  /* Use Caution, where clause not SQL inject safe. */
                        vRows = vDt.Select(where);
                    }
                    catch
                    {
                        log.Error("Cannot connect to USGS Database");
                        throw new WaterOneFlowServerException("Server Error: Cannot Connect to Database");
                    }
                    if (vRows.Length > 0)
                    {
                        foreach (DataRow vRow
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
            if (vList != null && vList.Count > 0)
            {
                // build response

                return  vList.ToArray();
            }
            else
            {
                log.Info("User Error: No Variables Returned");
                throw new WaterOneFlowException("No Variables Returned. Submit with no values to get full list.");
            }

        }

        public VariablesResponseType GetVariables(VariableParam[] variables)
        {
            VariableInfoType[] vit = GetVariableInfoObject(variables);

            VariablesResponseType vRes = new VariablesResponseType();
            if (vit != null && vit.Length > 0)
            {
                // build response

                vRes.variables = vit;
            }
            else
            {
                log.Info("User Error: No Variables Returned");
                throw new WaterOneFlowException("No Variables Returned. Submit with no values to get full list.");
            }
            return vRes;
        }
 
        /// <summary>
        /// add clauses to the where portion of the sql query, as  parameters.
        /// <para>
        /// Selection of a specific variable is done through the addition of
        /// key=value pairs appened to the Vocabulary:VariableCode parameter of a web service method
        /// This method creates a where clause using parameters to make calls SQL injection safe.</para>
        /// </summary>
        /// <param name="vp"></param>
        /// <returns></returns>
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
            stringConstraints.Add("statistic", "stat_cd");
            stringConstraints.Add("datatype", "DataType");
            stringConstraints.Add("samplemedium", "SampleMedium");

            Dictionary<string, string> numericConstraints = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            numericConstraints.Add("variableID", "VariableID");

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
                    constraintCount++;
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

        /// <summary>
        /// Uses the CoreBuilder class
        /// <para>Extend this to add information from additional columns returned in a database query</para>
        /// </summary>
        /// <param name="vRow"></param>
        /// <returns></returns>
        private VariableInfoType RowToVariable(DataRow vRow)
        {

            DataColumnCollection columns = vRow.Table.Columns;

            VariableInfoType vit;
            vit = CoreBuilder.CreateVariableRecord(vRow);

 

            return vit;
        }




        #endregion

        #region site

        public override SiteInfoType GetSite(locationParam lp)
        {
            locationParam[] sites = new locationParam[1];
            sites[0] = lp;
            SiteInfoType[] sit = GetSites(sites);
            if (sit != null && sit.Length > 0)
            {
                if (sit.Length >1 )
                {
                    log.Error("More than one site returned for "+ lp.ToString());
                }
                return sit[0];
            } else
            {
                log.Info("No sites returned for "+ lp.ToString());
                throw new WaterOneFlowException("No Site information for '" + lp.ToString() + "'");
            }
            
        }


        public override SiteInfoType[] GetSites(locationParam[] lp)
        {

            List<SiteInfoType> sites = new List<SiteInfoType>();

            DataSet sDs = new DataSet();


            if (lp == null || lp.Length == 0)
            {
                // get all sites
                // tableAdaptor.Fill(sDs);

                string query = string.Format(Properties.Settings.Default.getAllQueryFormat, SitesTableName);
                SqlDataAdapter dst = new SqlDataAdapter(query, DataInfoConnection);
                dst.Fill(sDs, sitesName); // populate variable table name
                dst.Dispose();
            }
            else
            {
                foreach (locationParam loc in lp)
                {

                    //tableAdaptor.FillBySiteCode(sDs, loc.SiteCode);
                    using (SqlConnection conn = new SqlConnection(DataInfoConnection))
                    {
                        // same format string for both sites and series. Table Name changes
                        string query = string.Format(Properties.Settings.Default.SiteCodeQueryFormat, SitesTableName);

                        SqlCommand comm = new SqlCommand(query, conn);
                        foreach (string s in SitesParameterNames)
                        {
                        if (s.Equals("sitecode",StringComparison.InvariantCultureIgnoreCase))
                        {                     
                            SqlParameter param = new SqlParameter("siteCode", loc.SiteCode);
                        comm.Parameters.Add(param);

} else {
                        //  if (loc.)
                        //    SqlParameter param2 = new SqlParameter(s, "USGS"); // need to check location for agency
                        //comm.Parameters.Add(param2); 
                        
         }               
                        }

                        SqlDataAdapter dst = new SqlDataAdapter(comm);

                        dst.Fill(sDs, sitesName); // populate variable table name
                        dst.Dispose();

                    }

                }
            }

            DataTable sDt = sDs.Tables[sitesName];
            foreach (DataRow row in sDt.Rows)
            {
                SiteInfoType sit = row2SiteInfoType(row);
                if (sit != null) sites.Add(sit);
            }

            if (sites.Count > 0)
            {
                return sites.ToArray();
            }
            else
            {
                throw new WaterOneFlowException("No Sites Found");
            }
        }


        private static SiteInfoType row2SiteInfoType(DataRow row)
        {
            SiteInfoType sit = null;

            DataColumnCollection columns = row.Table.Columns;

            if (row == null) return null;
            if (columns.Contains("SiteCode"))
            {
                if (row["SiteCode"].Equals(DBNull.Value)) return null;

            }
            else
            {
                // no SiteCode
                return null;
            }
            if (columns.Contains("SiteName"))
            {
                if (row["SiteName"].Equals(DBNull.Value)) return null;

            }
            else
            {
                // no SiteName
                return null;
            }

            sit = CoreBuilder.createSiteInfoRecord(row);

            //TODO: USGS items as notes
            // add agency note
            if (columns.Contains("agencyCode"))
            {
                note n = new note();
                n.title = "agency";
                n.Value = (string)row["agencyCode"];
                sit.note = CoreBuilder.addNote(sit.note, n);

            }
            //if (!row.Isusgs_agencyNull())
            //{
            //    note n = new note();
            //    n.title = "agency";
            //    n.Value = row.usgs_agency;
            //    sit.note = CoreBuilder.addNote(sit.note, n);
            //}

            // add siteType note
            if (columns.Contains("siteType"))
            {
                note n = new note();
                n.title = "SiteType";
                n.Value = (string)row["siteType"];
                sit.note = CoreBuilder.addNote(sit.note, n);

            }
            //if (!row.Isusgs_station_typeNull())
            //{
            //    note n = new note();
            //    n.title = "SiteType";
            //    n.Value = row.usgs_station_type;
            //    sit.note = CoreBuilder.addNote(sit.note, n);
            //}

            return sit;
        }

        #endregion sites

        #region series
        // do one at a time

        public override seriesCatalogType[] GetSeries(locationParam lp)
        {

            // for this we are only doing one, but multiple can come back
            List<seriesCatalogType> seriesCatalogs = new List<seriesCatalogType>();

            // seriesCatalog is built from array of series
            #region build series
            {

                List<seriesCatalogTypeSeries> series = new List<seriesCatalogTypeSeries>();

                //UsgsDbDailyValues.seriesCatalogDataTable scDs = new UsgsDbDailyValues.seriesCatalogDataTable();
                //UsgsDbDailyValuesTableAdapters.seriesCatalogTableAdapter tableAdaptor = new seriesCatalogTableAdapter();

                DataSet scDs = new DataSet();


                if (lp != null)
                {
                    if (lp.SiteCode != null)
                    {
                        // tableAdaptor.FillBySiteCode(scDs, lp.SiteCode);
                        using (SqlConnection conn = new SqlConnection(DataInfoConnection))
                        {
                            // same format string for both sites and series. Table Name changes
                            string query = string.Format(Properties.Settings.Default.SiteCodeQueryFormat, SeriesTableName);

                            SqlCommand comm = new SqlCommand(query, conn);
                            SqlParameter param = new SqlParameter("siteCode", lp.SiteCode);
                            comm.Parameters.Add(param);
                            SqlParameter param2 = new SqlParameter("agency", "USGS"); // need to check location for agency
                            comm.Parameters.Add(param2);

                            SqlDataAdapter da = new SqlDataAdapter(comm);

                            da.Fill(scDs, seriesName);

                            da.Dispose();
                            comm.Dispose();
                        }
                    }

                }

                DataTable scDt = scDs.Tables[seriesName];

                foreach (DataRow row in scDt.Rows)
                {
                    seriesCatalogTypeSeries s = row2Series(row);
                    if (s != null) series.Add(s);

                }

                // add the list of series to the 
                seriesCatalogType aCatalog = new seriesCatalogType();
                aCatalog.series = series.ToArray();
                seriesCatalogs.Add(aCatalog);
            }
            #endregion
            return seriesCatalogs.ToArray();
        }

        /// <summary>
        /// Uses the CoreBuilder class
        /// <para>Extend this to add information from additional columns returned in a database query</para>
        /// </summary>
        /// <param name="vRow"></param>
        /// <returns></returns>
        private static seriesCatalogTypeSeries row2Series(DataRow aRow)
        {
 

            seriesCatalogTypeSeries aSeries = CoreBuilder.CreateSeriesRecord(aRow);

            return aSeries;
        }

        #endregion series

        # region SiteInfo

       public override SiteInfoType GetSiteInfoObject(locationParam site)
        {
            
            locationParam[] sites = new locationParam[1];
            sites[0] = site;
            SiteInfoType[] sit = GetSiteInfoObjects(sites);
            if (sit != null && sit.Length >0 )
            {
                if (sit.Length > 1)
                {
                    log.Error("More than One site returned for " + site.ToString());
                }
                return sit[0];
            } else
            {
                log.Info("No site returned for " + site.ToString());
                throw new WaterOneFlowException("No Site Information and series for " + site.ToString());
            }
        }

        public override SiteInfoType[] GetSiteInfoObjects(locationParam[] sites)
        {
          if (sites == null || sites.Length == 0)
          {
              log.Debug("Null or zero length location parameter to GetSiteInfoOnjects");
              throw new WaterOneFlowException("Please submit a location parameter.");
          }
            // get the site Information
            SiteInfoType[] siteInfoArray = GetSites(sites);

            foreach (SiteInfoType siteInfo in siteInfoArray)
            {
                    String siteCode = siteInfo.siteCode[0].Value;
                    String siteVocabulary = siteInfo.siteCode[0].network;

                    locationParam lp = new locationParam(siteVocabulary +":"+siteCode);
                try
                {
                    seriesCatalogType[] series = GetSeries(lp);
                } catch (WaterOneFlowException ex)
                {
                    log.Info("No Series Info for " + lp.ToString() +" " + ex.Message);
                } catch(WaterOneFlowServerException ex)
                {
                    log.Info("Server Exception  Error on Series Info for " + lp.ToString() + " " + ex.Message);
                } catch (WaterOneFlowSourceException ex)
                {
                    log.Info("Soruce Exception on Series Info for " + lp.ToString() + " " + ex.Message);
                    
                }
            }

            return siteInfoArray;
         
            
        }

        #endregion SiteInfo
    }
}
