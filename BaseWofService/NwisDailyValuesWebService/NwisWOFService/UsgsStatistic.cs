using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NwisWOFService
{
    public static class UsgsStatistic
    {
        private static Dictionary<String, String> statisticField = new Dictionary<string, string>( StringComparer.InvariantCultureIgnoreCase);

        private static Dictionary<String, String> dataValueField = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        /// <summary>
        /// Provides a mapping from USGS Statistics code (stat_cd) to DataValue
        /// </summary>
        public static Dictionary<String, String> DataValue
        {
            get { return UsgsStatistic.dataValueField; }
            set { UsgsStatistic.dataValueField = value; }
        }

        /// <summary>
        /// Provides a mapping from Term to USGS Statistics code (stat_cd)
        /// </summary>
        public static Dictionary<String, String> Code
        {
            get { return UsgsStatistic.statisticField; }
            set { UsgsStatistic.statisticField = value; }
        }

        //public static Dictionary<string,string> DataType
        //{
        //    get { return UsgsStatistic.Code.; }
        //}
        public static string DefaultCode
        {
            get { return "00003"; }
        }
        public static string DefaultKey
        {
            get { return "mean"; }
        }


        static UsgsStatistic()
        {
            /* NOTE YOU CAN ONLY HAVE ONE KEY
             * But you can have multiple values
             * */
            statisticField.Add("Maximum", "00001");
            dataValueField.Add("00001", "Maximum");

            statisticField.Add("Minimum", "00002");
            dataValueField.Add("00002", "Minimum");

                statisticField.Add("mean", "00003");
                statisticField.Add("Average", "00003");
                dataValueField.Add("00003","Average"); // to match the ODM Terminology

                statisticField.Add("Cumulative", "00006");
                dataValueField.Add( "00006","Cumulative");

                statisticField.Add("Median", "00008");
                dataValueField.Add("00008", "Median");

                statisticField.Add("Variance", "00010");
                dataValueField.Add("00010","Variance");

                statisticField.Add("Instantaneous", "00011");
                dataValueField.Add("00011", "Instantaneous");
                /* not defined by ODM
                statMap.Add("mode",  "00007");    
                statMap.Add("STD",  "00009");
                statMap.Add("SKEWNESS",  "00013");
                 */

            // hack for column headers
                statisticField.Add("qualifiers", "cd");
         
        }
    }
}
