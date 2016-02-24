using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EPAWOFService;

namespace EPAWQXConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           WqxResultsToDataset ds = new WqxResultsToDataset();
           ds.Organization = "11NPSWRD";
           ds.MonitoringLocation = "CHIS_NPS_Q3";
           ds.CharacteristicName = "Dissolved oxygen (DO)";
            ds.MinimumActivityStartDate="01/01/1993";
           ds.MaximumActivityStartDate = "12/31/1993";

           DataTable dt = ds.getResults();

        }
    }
}
