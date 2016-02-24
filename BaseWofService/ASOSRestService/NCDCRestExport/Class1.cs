using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NCDC
{
    namespace RestServices
    {
        namespace Export
        {
            public class SitesToDb
            {
                private SqlConnection databaseConection;

public SqlConnection DatabaseConection
{
  get { return databaseConection; }
  set { databaseConection = value; }
}

                public SitesToDB(string connectionString)
                {
                    SqlConnection con = new SqlConnection(connectionString);

                }
                
            }
        }
    }
 
}
