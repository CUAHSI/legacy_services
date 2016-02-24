using System;
using System.Collections.Generic;
using System.Text;

namespace NCDC.RestService
{
    class ImportSites
    {
        //enum Options
        //{
        //    countryAbbrev,
        //    stateAbbrev
        //}

        static void Main(string[] args)
        {
            string datasetID = "30";
            string token = null;
            string option = "usa";
            string optionValue = ";";
            string connectionString = "";
            foreach (string s in args)
            {
                string[] commandOption = s.Split('=');

                switch (commandOption[0])
                {
                    case "datasetid":
                        datasetID = commandOption[1];
                        break;
                    case "token":
                        token = commandOption[1];
                        break;
                    case "option":
                        option = commandOption[1];
                        break;
                    case "optionValue":
                        optionValue = commandOption[1];
                        break;
                    case "country":
                        option = "countryAbbrev";
                        optionValue = commandOption[1];
                        break;
                    case "state":
                        option = "stateAbbrev";
                        optionValue = commandOption[1];
                        break;
 default:
                        throw new NotSupportedException("Unknown Parameter '" + s);
                        break;
                }
            }

            NCDC.RestService.Export.SitesToDb exporter = new NCDC.RestService.Export.SitesToDb(connectionString);
            List<NCDC.RestService.SiteInfoNCDC> sites = null;
            switch (option)
            {
                case "countryAbbrev":
                    sites = NCDC.RestService.Sites.SitesByCountry(datasetID, optionValue, token);
                    break;
                case "stateAbbrev":
                    sites = NCDC.RestService.Sites.SitesByState(datasetID, optionValue, token);
                    break;
                default:
                    throw new NotSupportedException("not supported");
                    break;
            }
            exporter.AddToDB(sites);
        }
    }
}
