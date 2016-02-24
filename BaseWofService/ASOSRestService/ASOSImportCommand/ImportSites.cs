using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace NCDC.RestService.v1
{
    public class ImportSites
    {
        // 30 = daily
        // 10 = isd
        // 11 = ish

        //enum Options
        //{
        //    countryAbbrev,
        //    stateAbbrev
        //}

       public  static void Main(string[] args)
        {
            string datasetID = "30";
            string token = null;
            string option = "usa";
            string optionValue = ";";
            string connectionString = "";
           string fileName = null;
            foreach (string s in args)
            {
                if (s.StartsWith("connectionString="))
                {
                    connectionString = s.Substring("connectionString=".Length);
                    break;
                }
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
                    case "all":
                        option = "all";
                        optionValue = commandOption[1];
                        break;
                    case "inputfile":
                        option = "inputfile"; 
                        fileName = commandOption[1];
                        break;
 default:
                        throw new NotSupportedException("Unknown Parameter '" + s);
                        break;
                }
            }

            NCDC.RestService.v1.Export.SitesToDb exporter = new NCDC.RestService.v1.Export.SitesToDb(connectionString);
            List<NCDC.RestService.v1.SiteInfoNCDC> sites = null;
            List<NCDC.RestService.v1.SiteInfoNCDC> sites2 = null;
            switch (option)
            {
                case "all":
                    sites = NCDC.RestService.v1.Sites.SitesGetAllXmlFormat(datasetID, optionValue, token);
                    break;
                case "countryAbbrev":
                    sites = NCDC.RestService.v1.Sites.SitesByCountryXmlFormat(datasetID, optionValue, token);
                    break;
                case "stateAbbrev":
                    sites = NCDC.RestService.v1.Sites.SitesByStateXmlFormat(datasetID, optionValue, token);
                    break;
                case "inputfile":
                    if(!File.Exists(fileName))
                    {
                        fileName = System.AppDomain.CurrentDomain.BaseDirectory + fileName;
                    }
                    StreamReader tReader = File.OpenText(fileName);
                    XmlReader reader = XmlReader.Create(tReader);
                    sites = NCDC.RestService.v1.Sites.SiteObject(reader, datasetID);
                    break;
                default:
                    throw new NotSupportedException("not supported");
                    break;
            }
           string tableName = "siteInfo$";
          
            exporter.AddToDB(sites, tableName);
        }

      
    }
}
