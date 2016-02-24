using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace NCDC.RestService
{
    public class ImportISDSites
    {
        //enum Options
        //{
        //    countryAbbrev,
        //    stateAbbrev
        //}

       public  static void Main(string[] args)
        {
            string datasetID = "10";
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
                    case "inputfile":
                        option = "inputfile"; 
                        fileName = commandOption[1];
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
                case "inputfile":
                    if(!File.Exists(fileName))
                    {
                        fileName = System.AppDomain.CurrentDomain.BaseDirectory + fileName;
                    }
                    StreamReader tReader = File.OpenText(fileName);
                    XmlReader reader = XmlReader.Create(tReader);
                    sites = NCDC.RestService.Sites.SiteObject(reader);
                    break;
                default:
                    throw new NotSupportedException("not supported");
                    break;
            }
            exporter.AddToDB(sites);
        }
    }
}
