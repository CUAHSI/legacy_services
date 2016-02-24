using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using NCDC.RestService.v1;


namespace NCDC
{
    namespace RestService.v1
    {
        namespace Export
        {
            /// <summary>
            /// This is the type of update to apply.
            /// If a siteId-DatasetID record does not exist, then all the information from an imported site will be loaded.
            /// </summary>

            public enum ExportType
            {
                /// <summary>
                /// Update all columns
                /// </summary>
                ALL,
                /// <summary>
                /// Update the Time Interval columns
                /// </summary>      
                BeginEnd,
                /// <summary>
                /// Update only Geographic Latitude/Longitude columns
                /// </summary>
                LatLong
            }
            /// <summary>
            /// Load NCDCSiteInfo into a database.
            ///  on a NCDCSiteInfo or a List
            /// </summary>
            /// <remarks>There are two formats that the NCDC web services provide; xml and waterml. The WaterML does not contain the  series/period of record.
            /// <list type="bullet">
            /// <item>For daily, XML is the complete record.</item>
            /// <item>For ISD and ISH, the scaling in elevation and lat/long is incorrect (as of july 2008). The WaterML has the correct corrdinates. </item>
            /// 
            /// </list>  
            /// </remarks>
            /// 
            /// <remarks>Loading ISD and ISH may require two passes, one to load the coordinates, and one for series time range.</remarks>
            public class SitesToDb
            {

                private SqlConnection databaseConnection;

                /// <summary>
                /// Set the database connection
                /// </summary>
                public SqlConnection DatabaseConnection
                {
                    get { return databaseConnection; }
                    set { databaseConnection = value; }
                }

                /// <summary>
                /// Creates a SitesToDb export class, and sets the database connection
                /// </summary>
                /// <param name="connectionString"></param>
                public SitesToDb(string connectionString)
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    DatabaseConnection = con;

                }

                /// <summary>
                /// Adds a list of sites to the database.
                /// If site does not exist, all information will be added.
                /// If site exists, all information will be added. (ExportType.All)
                /// </summary>
                /// <param name="sites">List of sites</param>
                public void AddToDB(List<SiteInfoNCDC> sites, string tableName)
                {
                    AddToDB(sites, ExportType.ALL, tableName);
                }

                /// <summary>
                /// Adds a list of sites to the database.
                /// If site does not exist, all information will be added.
                /// If site exists, all information updated as described by ExportType.
                /// </summary>
                /// <param name="sites">List of sites</param>
                /// <param name="exportType">ExportType to apply to record UPDATES. <see cref="ExportType"/></param>
                /// <remarks><list type="bullet">
                /// <item>ExportType.All - Update </item>
                /// <item>ExportType.LatLon - Update only cooridate columns</item>
                /// <item>ExportType.BeginEnd - Update only time range</item>
                /// </list>
                /// </remarks>
                /// <seealso cref="AddToDB(NCDC.RestService.v1.SiteInfoNCDC,NCDC.RestService.v1.Export.ExportType,string)"/>
                public void AddToDB(List<SiteInfoNCDC> sites, ExportType exportType, string tableName)
                {
                    foreach (SiteInfoNCDC site in sites)
                    {
                        AddToDB(site, exportType, tableName);
                    }
                }

                /// <summary>
                /// Adds a single to the database.
                /// If site does not exist, all information will be added.
                /// If site exists, all information updated as described by ExportType.
                /// </summary>
                /// <param name="site">List of sites</param>
                /// <param name="exportType">ExportType to apply to record UPDATES. <see cref="ExportType"/></param>
                /// <remarks><list type="bullet">
                /// <item>ExportType.All - Update </item>
                /// <item>ExportType.LatLon - Update only cooridate columns</item>
                /// <item>ExportType.BeginEnd - Update only time range</item>
                /// </list>
                /// </remarks>
                public void AddToDB(SiteInfoNCDC site, ExportType exportType, string tableName)
                {
                     string sqlDuplicateCheck = "select count(siteID) from "+tableName+" where siteID =@SiteID and DatasetId=@datasetid";

                     string sqlInsert = "Insert into "+tableName+"(datasetID,siteID,SiteName,latitude,longitude,elevation,beginDate,endDate, state, country, dateAdded, DateUpdated)"
                                       +
                                       " Values(@datasetID,@siteID,@SiteName,@latitude,@longitude,@elevation,@beginDate,@endDate,@state,@country,getdate(),getdate())";

                    string sqlUpdate = "Update  "+tableName
                                        + " set SiteName= @siteName, "
                                        + " siteId=@siteID, "
                                        + " latitude=@latitude, "
                                        + " longitude=@longitude, "
                                        + " beginDate=@beginDate, "
                                        + " endDate=@endDate, "
                                        + " state= @state, "
                                        + " country = @country, "
                                        + " DateUpdated = getdate() " 
                                        + " where siteID = @siteId "
                                        + "AND DatasetId=@datasetid";

                    switch (exportType)
                    {
                        case ExportType.LatLong:
                            sqlUpdate = "Update  "+tableName
                                                 + " set "
                                                 + " latitude=@latitude, "
                                                 + " longitude=@longitude, "
                                                  + " DateUpdated = getdate() " 
                                                 + " where siteID = @siteId "
                                                 + "AND DatasetId=@datasetid";

                            break;
                        case ExportType.BeginEnd:
                            sqlUpdate = "Update  "+tableName
                                                 + " set "
                                                 + " beginDate=@beginDate, "
                                                 + " endDate=@endDate, "
                                                  + " DateUpdated = getdate() " 
                                                 + " where siteID = @siteId "
                                                 + "AND DatasetId=@datasetid";
                            break;
                        case ExportType.ALL:
                        default:
                            sqlUpdate = "Update  "+tableName
                                                 + " set SiteName= @siteName, "
                                                 + " siteId=@siteID, "
                                                 + " latitude=@latitude, "
                                                 + " longitude=@longitude, "
                                                 + " beginDate=@beginDate, "
                                                 + " endDate=@endDate, "
                                                 + " state= @state, "
                                                 + " country = @country, "
                                                  + " DateUpdated = getdate() " 
                                                 + " where siteID = @siteId "
                                                 + "AND DatasetId=@datasetid";
                            break;


                    }

                    if (DatabaseConnection == null)
                    {
                        throw new Exception("Configure object with DatabaseConnection prior to export");
                    }


                    DatabaseConnection.Open();
                    SqlCommand command = DatabaseConnection.CreateCommand();
                    command.CommandText = sqlDuplicateCheck;
                    command.Parameters.AddWithValue("@siteid", site.StationID);
                    command.Parameters.AddWithValue("@datasetID", ValueOrDBNull(site.DatasetID));
                    command.Parameters.AddWithValue("@SiteName", ValueOrDBNull(site.SiteName));
                    command.Parameters.AddWithValue("@latitude", ValueOrDBNull(site.Latitude));
                    command.Parameters.AddWithValue("@longitude", ValueOrDBNull(site.Longitude));
                    command.Parameters.AddWithValue("@beginDate", ValueOrDBNull(site.BeginDate));
                    command.Parameters.AddWithValue("@endDate", ValueOrDBNull(site.EndDate));
                    command.Parameters.AddWithValue("@elevation", ValueOrDBNull(site.Elevation));
                    command.Parameters.AddWithValue("@state", ValueOrDBNull(site.State));
                    command.Parameters.AddWithValue("@country", ValueOrDBNull(site.Country));

                    int result = (int)command.ExecuteScalar();
                    if (result < 1)
                    {
                        command.CommandText = sqlInsert;
                        command.ExecuteNonQuery();
                        DatabaseConnection.Close();
                        return;
                    }
                    else
                    {
                        command.CommandText = sqlUpdate;
                        command.ExecuteNonQuery();
                        DatabaseConnection.Close();
                        return;
                    }

                }


                private static Object ValueOrDBNull(Object value)
                {
                    if (null == value)
                    {
                        return DBNull.Value;

                    }
                    else
                    {
                        return value;
                    }
                }

            }
        }
    }

}
