using System;
using System.Collections.Generic;
using System.Text;
using WaterOneFlowImpl;
using WaterOneFlowImpl.geom;

namespace WaterOneFlow.Utilities
{
    public class ODMSqlQueries
    {
        const string boxSqlFormat = " SELECT top 50000 * FROM {0} " +
                                         "WHERE ( Latitude BETWEEN {1} AND {2} ) " +
                                         " AND ( Longitude BETWEEN {3} AND {4} )";


        public static String GeomToSiteSqlWhere (basicGeometry geom)
        {
         return GeomToSqlWhere(geom, "Sites");
        }

        public static String GeomToSeriesSqlWhere(basicGeometry geom)
        {
            return GeomToSqlWhere(geom, "Series");
        }

  /// <summary>
     /// An SQL where clause for an ODM sites table
     /// </summary>
     /// <param name="geom"></param>
     /// <param name="tableName"></param>
     /// <returns></returns>

         public static String GeomToSqlWhere (basicGeometry geom, string tableName)
        {
            if(geom.GetType().Equals(typeof(box)))
            {
                box queryBox = (box) geom;
                string sqlClause = string.Format(boxSqlFormat,
                                             tableName, queryBox.South, queryBox.North,
                                             queryBox.West, queryBox.East);
                return sqlClause;
            } else
            {
                throw new WaterOneFlowException("Only Box is understood at this time"); 
            }
        }
    }
}
