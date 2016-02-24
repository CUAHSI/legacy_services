using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using NCDC.RestService.v1.Export;

namespace NCDC.RestService.v1
{
    public class ImportISDSites
    {
    

       public  static void Main(string[] args)
        {
            string datasetID = "11";
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
                    case "inputfileXML":
                        option = "inputfileXML"; 
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
                case "countryAbbrev":
                    sites = NCDC.RestService.v1.Sites.SitesByCountryXmlFormat(datasetID, optionValue, token);
                    sites2 = NCDC.RestService.v1.Sites.SitesByCountryWaterMLFormat(datasetID, optionValue, token);
                    break;
                case "stateAbbrev":
                    sites = NCDC.RestService.v1.Sites.SitesByStateXmlFormat(datasetID, optionValue, token);
                    sites2 = NCDC.RestService.v1.Sites.SitesByStateWaterMLFormat(datasetID, optionValue, token);
                    break;
                case "inputfileXML":
                    if (!File.Exists(fileName))
                    {
                        fileName = System.AppDomain.CurrentDomain.BaseDirectory + fileName;
                    }
                    string NcdcXmlfileName = "NCDC_ish_sites.xml";
                    StreamReader tReader = File.OpenText(NcdcXmlfileName);
                    XmlReader reader = XmlReader.Create(tReader);
                    sites = NCDC.RestService.v1.Sites.SiteObject(reader, datasetID);

                    // sites2 = NCDC.RestService.v1.Sites.SitesByCountryWaterMLFormat(datasetID, optionValue, token);
                    string waterMlFileName = "ncdc_ish_waterml_200807.xml";
                    StreamReader tReader2 = File.OpenText(waterMlFileName);
                    XmlReader reader2 = XmlReader.Create(tReader);
                    sites2 = NCDC.RestService.v1.Sites.SiteObject(reader2, datasetID); ;
                    break;
                default:
                    throw new NotSupportedException("not supported");
                    break;
            }

            //datasetID = "11";
            //string NcdcXmlfileName = "NCDC_ish_sites.xml";
            //StreamReader tReader = File.OpenText(NcdcXmlfileName);
            //XmlReader reader = XmlReader.Create(tReader);
            //sites = NCDC.RestService.v1.Sites.SiteObject(reader, datasetID);

            //// sites2 = NCDC.RestService.v1.Sites.SitesByCountryWaterMLFormat(datasetID, optionValue, token);
            //string waterMlFileName = "ncdc_ish_waterml_200807.xml";
            //StreamReader tReader2 = File.OpenText(waterMlFileName);
            //XmlReader reader2 = XmlReader.Create(tReader2);
            //sites2 = NCDC.RestService.v1.Sites.SiteObject(reader2, datasetID); ;

           // We do not need to ExportType.All. If the site does not exist, it will load all the values, no matter how bad.
            //exporter.AddToDB(sites2,ExportType.LatLong, "SiteInfo$");
            //exporter.AddToDB(sites,ExportType.BeginEnd, "SiteInfo$");

            //datasetID = "10";
            //NcdcXmlfileName = "NCDC_isd_sites.xml";
            // tReader = File.OpenText(NcdcXmlfileName);
            //reader = XmlReader.Create(tReader);
            //sites = NCDC.RestService.v1.Sites.SiteObject(reader, datasetID);

            //// sites2 = NCDC.RestService.v1.Sites.SitesByCountryWaterMLFormat(datasetID, optionValue, token);
            //waterMlFileName = "ncdc_isd_waterml_200807.xml";
            // tReader2 = File.OpenText(waterMlFileName);
            //reader2 = XmlReader.Create(tReader2);
            //sites2 = NCDC.RestService.v1.Sites.SiteObject(reader2, datasetID); ;

            // We do not need to ExportType.All. If the site does not exist, it will load all the values, no matter how bad.
            exporter.AddToDB(sites2, ExportType.LatLong, "SiteInfo$");
            exporter.AddToDB(sites, ExportType.BeginEnd, "SiteInfo$");
        }
    }
}
