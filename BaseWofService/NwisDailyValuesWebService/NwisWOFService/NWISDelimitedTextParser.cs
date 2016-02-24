using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WaterOneFlowImpl;

namespace WaterOneFlow.Service.Nwis
{
    static class NWISDelimitedTextParser
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static List<List<string>> ParseFile(string data)
        {
            List<List<string>> metaList = new List<List<string>>();
            string line = null;
            System.IO.StringReader aReader = new System.IO.StringReader(data);
            while ((line = aReader.ReadLine()) != null)
            {
                if (line.StartsWith("#"))
                    continue;
                List<string> aList = new List<string>();
                aList.AddRange(line.Split(new string[] { "\t" }, StringSplitOptions.None));
                if (aList[0] == "agency_cd")
                    continue;
                if (aList[0].EndsWith("s"))
                    continue;
                metaList.Add(aList);
            }

            return metaList;
        }

        public static DataTable ParseFileIntoDT(string data)
        {
            string line = null;
            DataTable aTable = new DataTable("NWISData");
            aTable.CaseSensitive = false;
            System.IO.StringReader aReader = new System.IO.StringReader(data);
            while ((line = aReader.ReadLine()) != null)
            {
                if (line.StartsWith("#"))
                    continue;

                List<string> aList = new List<string>();
                aList.AddRange(line.Split(new string[] { "\t" }, StringSplitOptions.None));

                if (aList[0] == "agency_cd")
                {
                    CreateHeaders(aTable, aList);
                    continue;
                }
                if (aList[0].EndsWith("s"))
                    continue;
                DataRow aRow = aTable.NewRow();
                foreach (string anItem in aList)
                {
                    aRow[aList.IndexOf(anItem)] = anItem;
                }
                aTable.Rows.Add(aRow);
            }
            return aTable;
        }

        private static void CreateHeaders(DataTable aTable, List<string> aList)
        {
            foreach (string anItem in aList)
            {
                aTable.Columns.Add(anItem, typeof(string));
            }
        }
    }
}
