using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Text;
using System.Xml;

using log4net;

namespace NCDC
{

    namespace RestService.v1
    {
        public class Sites
        {

            private static ILog log =
                LogManager.GetLogger(
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
                    );
            public static List<SiteInfoNCDC> SitesGetAllXmlFormat(String DatasetID, String Country, String Token)
            {
                XmlReader reader = SitesGetAllXmlReaderXMLOutput(DatasetID,  Token);
                List<SiteInfoNCDC> sites = SiteObject(reader, DatasetID);
                return sites;
            }

            public static List<SiteInfoNCDC> SitesByCountryXmlFormat(String DatasetID, String Country, String Token)
            {
                XmlReader reader = SitesByCountryXmlReaderXMLOutput(DatasetID, Country, Token);
                List<SiteInfoNCDC> sites = SiteObject(reader, DatasetID);
                return sites;
            }
            public static List<SiteInfoNCDC> SitesByStateXmlFormat(String DatasetID, String State, String Token)
            {
                XmlReader reader = SitesByStateXmlReaderXMLOutput(DatasetID, State, Token);
                List<SiteInfoNCDC> sites = SiteObject(reader, DatasetID);
                return sites;
            }

            public static List<SiteInfoNCDC> SitesByCountryWaterMLFormat(String DatasetID, String Country, String Token)
            {
                XmlReader reader = SitesByCountryXmlReaderWaterMLOutput(DatasetID, Country, Token);
                List<SiteInfoNCDC> sites = SiteObject(reader, DatasetID);
                return sites;
            }
            public static List<SiteInfoNCDC> SitesByStateWaterMLFormat(String DatasetID, String State, String Token)
            {
                XmlReader reader = SitesByStateXmlReaderWaterMLOutput(DatasetID, State, Token);
                List<SiteInfoNCDC> sites = SiteObject(reader, DatasetID);
                return sites;
            }

            //public static List<SiteInfoNCDC> SiteObject(XmlReader xmlReader)
            //{
            //    return SiteObject(xmlReader, "0");
            //}

            public static List<SiteInfoNCDC> SiteObject(XmlReader xmlReader, string DefaultDatasetID)
            {
                xmlReader.MoveToContent();
                List<SiteInfoNCDC> sites = new List<SiteInfoNCDC>();
                if (xmlReader.IsStartElement("sites"))
                {
                    NCDCSitesXMLReader(sites, xmlReader);
                    return sites;
                }
                else if (
                    xmlReader.IsStartElement("sitesResponse"))
                {
                    WaterMLSitesXMLReader(sites, xmlReader, DefaultDatasetID);
                    return sites;
                }
                return sites;
            }

            private static void NCDCSitesXMLReader(List<SiteInfoNCDC> sites, XmlReader xmlReader)
            {
                xmlReader.ReadToDescendant("site");
                while (xmlReader.IsStartElement() && xmlReader.Name.Equals("site"))
                {
                    XmlReader siteReader = xmlReader.ReadSubtree();
                    SiteInfoNCDC site = new SiteInfoNCDC();

                    siteReader.ReadStartElement();
                    while (siteReader.IsStartElement())
                    {
                        if (siteReader.Name.Equals("site"))
                        {
                            break;
                        }
                        switch (siteReader.Name)
                        {
                            case "datasetid":
                                site.DatasetID = siteReader.ReadString();
                                break;
                            case "stationid":
                                site.StationID = siteReader.ReadString();
                                break;
                            case "name":
                                site.SiteName = siteReader.ReadString();
                                break;
                            case "lat":
                                site.SetLatitude(siteReader.ReadString());
                                break;
                            case "lon":
                                site.SetLongitude(siteReader.ReadString());
                                break;
                            case "lowdate":
                                site.SetBeginDate(siteReader.ReadString());
                                break;
                            case "highdate":
                                site.SetEndDate(siteReader.ReadString());
                                break;
                            case "elev":
                                site.SetElevation(siteReader.ReadString());
                                break;
                            case "abbrev":
                                siteReader.ReadString(); 
                                break;
                            
                            default:
                                log.Error("New Node name in site " + siteReader.Name);
                               siteReader.ReadString();
                                break;
                        }
                        try
                        {
                            if (!siteReader.IsEmptyElement )
                            {
                                siteReader.ReadEndElement();
                            } else
                            {
                               siteReader.Skip(); 
                            }
                           
                        } catch
                        {
                            siteReader.Read();
                            // ignore
                        }
                       
                        //siteReader.ReadStartElement();
                    }
                    sites.Add(site);
                   
                    if (!xmlReader.IsStartElement() )
                    {
                        xmlReader.ReadEndElement();
                    } 

                }
            }

            private static void WaterMLSitesXMLReader(List<SiteInfoNCDC> sites, XmlReader xmlReader, string DefaultDatasetID)
            {
                xmlReader.ReadToDescendant("site", Utility.WaterMlNs);
                while (xmlReader.IsStartElement())
                {
                    xmlReader.ReadToDescendant("siteInfo", Utility.WaterMlNs);

                    XmlReader siteReader = xmlReader.ReadSubtree();
                    SiteInfoNCDC site = new SiteInfoNCDC();

                    site.DatasetID = DefaultDatasetID;
                    /*
             <ns2:siteInfo>
<ns2:siteCode siteID="99999925226" network="NCDC" defaultId="true">SMITH RIVER</ns2:siteCode>
<ns2:geoLocation>
<ns2:geogLocation xsi:type="ns2:LatLonPointType" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
<ns2:latitude>0.0599</ns2:latitude>
<ns2:longitude>-0.12643333</ns2:longitude>
</ns2:geogLocation>
</ns2:geoLocation>
</ns2:siteInfo>
            */
                    siteReader.ReadStartElement();
                    while (siteReader.IsStartElement())
                    {
                        switch (siteReader.LocalName)
                        {
                            case "siteCode":

                                /* 
         <ns2:siteCode 
            siteID="99999925226"
            network="NCDC" 
            defaultId="true">SMITH RIVER</ns2:siteCode>
        */
                                if (siteReader.HasAttributes)
                                {
                                    // siteReader.MoveToFirstAttribute();

                                    while (siteReader.MoveToNextAttribute())
                                    {
                                        switch (siteReader.LocalName)
                                        {
                                            case "siteID":
                                                site.StationID = siteReader.ReadContentAsString();
                                                break;
                                            case "network":
                                                break;
                                            default:
                                                break;
                                        }
                                        ;
                                    }
                                }
                                siteReader.MoveToElement();
                                site.SiteName = siteReader.ReadElementContentAsString();
                                break;
                            case "geoLocation":

                                /*        <ns2:geoLocation>
                    <ns2:geogLocation xsi:type="ns2:LatLonPointType" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
                        <ns2:latitude>0.0599</ns2:latitude>
                        <ns2:longitude>-0.12643333</ns2:longitude>
                    </ns2:geogLocation>
        */
                                try
                                {
                                    siteReader.ReadToDescendant("latitude", Utility.WaterMlNs);
                                    if (siteReader.NodeType != XmlNodeType.None)
                                    {
                                        double lat = 0.0;
                                        string lString =
                                            siteReader.ReadElementContentAsString("latitude", Utility.WaterMlNs);
                                        if (double.TryParse(
                                            lString, out lat))
                                        {
                                            site.Latitude = lat;
                                        }

                                    }
                                    //siteReader.ReadEndElement(); // not needed after read content
                                    if (siteReader.LocalName != "longitude")
                                    {
                                        siteReader.ReadToFollowing("longitude", Utility.WaterMlNs);
                                    }

                                    if (siteReader.NodeType != XmlNodeType.None)
                                    {

                                        double lon = 0.0;
                                        string lString =
                                            siteReader.ReadElementContentAsString("longitude", Utility.WaterMlNs);
                                        if (double.TryParse(
                                            lString, out lon))
                                        {
                                            site.Longitude = lon;
                                        }
                                    }
                                    //siteReader.ReadEndElement(); //long // not needed after read content
                                    siteReader.ReadEndElement(); //geoglocation
                                    siteReader.ReadEndElement(); // geolocation
                                    break;
                                }
                                catch
                                {
                                    ReadState state = siteReader.ReadState;
                                    if (siteReader.NodeType == null)
                                    {
                                        siteReader.Skip();
                                    }
                                    else
                                    {
                                        siteReader.ReadEndElement();
                                    }
                                    break;
                                }
                            default:
                                log.Error("New Node name in site " + siteReader.Name);
                                siteReader.ReadEndElement();
                                break;
                        }
                        //siteReader.ReadEndElement();
                        //siteReader.ReadStartElement();
                    }
                    sites.Add(site);
                    xmlReader.ReadEndElement();// siteInfo
                    xmlReader.ReadEndElement(); //site
                }
            }
            /*
                 <sites>
            <site>
                <datasetid>30</datasetid>
                <stationid>01000899999</stationid>
                <name>ABBEVILLE</name>
                <lat>31.57028</lat>
                <lon>-85.24833</lon>
                <elev>456</elev>
                <lowdate>194807</lowdate>
                <highdate>200802</highdate>
            </site>
                 */

            public static XmlReader SitesGetAllXmlReaderXMLOutput(String DatasetID,  String Token)
            {
                string datasetCode = Utility.DatasetIDToCode(DatasetID);

                string Url = NCDC.RestService.Properties.Settings.Default.BaseURL
                             + String.Format(NCDC.RestService.Properties.Settings.Default.SitesGetAllPath, datasetCode);

                return Utility.RestByUrl(Url, NCDC.RestService.Properties.Settings.Default.XmlOutputFormat, Token);
            }

            /// <summary>
            /// Returns the XML version of the sites
            /// </summary>
            /// <param name="Country"></param>
            /// <param name="Token"></param>
            /// <returns></returns>
            public static XmlReader SitesByCountryXmlReaderXMLOutput(String DatasetID, String Country, String Token)
            {
                string datasetCode = Utility.DatasetIDToCode(DatasetID);

                string Url = NCDC.RestService.Properties.Settings.Default.BaseURL
                             + UrlPathByCountry(datasetCode, Country);

                return Utility.RestByUrl(Url, NCDC.RestService.Properties.Settings.Default.XmlOutputFormat, Token);
            }

            public static XmlReader SitesByCountryXmlReaderWaterMLOutput(String DatasetID, String Country, String Token)
            {
                string datasetCode = Utility.DatasetIDToCode(DatasetID);

                string Url = NCDC.RestService.Properties.Settings.Default.BaseURL
                             + UrlPathByCountry(datasetCode, Country);

                return Utility.RestByUrl(Url, NCDC.RestService.Properties.Settings.Default.WaterMLOuputFormat, Token);
            }

            public static XmlReader SitesByStateXmlReaderXMLOutput(String DatasetID, String Country, String Token)
            {
                string datasetCode = Utility.DatasetIDToCode(DatasetID);
                string Url = NCDC.RestService.Properties.Settings.Default.BaseURL
                             + UrlPathByState(datasetCode, Country);

                return Utility.RestByUrl(Url, NCDC.RestService.Properties.Settings.Default.XmlOutputFormat, Token);
            }

            public static XmlReader SitesByStateXmlReaderWaterMLOutput(String DatasetID, String Country, String Token)
            {
                string datasetCode = Utility.DatasetIDToCode(DatasetID);
                string Url = NCDC.RestService.Properties.Settings.Default.BaseURL
                             + UrlPathByState(datasetCode, Country);

                return Utility.RestByUrl(Url, NCDC.RestService.Properties.Settings.Default.WaterMLOuputFormat, Token);
            }

            private static string UrlPathByCountry(string datasetCode, String Country)
            {
                return String.Format(NCDC.RestService.Properties.Settings.Default.SitesCountryPath, datasetCode, Country);
            }

            private static string UrlPathByState(string DatasetCode, String State)
            {
                return String.Format(NCDC.RestService.Properties.Settings.Default.SitesStatePath, DatasetCode, State);
            }
        }
        public class SiteInfoNCDC
        {

            private string datasetID;

            public string DatasetID
            {
                get { return datasetID; }
                set { datasetID = value.Trim(); }
            }

            private string regionField;

            public string RegionAbbreviation
            {
                get { return regionField; }
                set { regionField = value.Trim(); }
            }

            private string siteNameField;

            public string SiteName
            {
                get { return siteNameField; }
                set { siteNameField = value.Trim(); }
            }
            private string stationIDField;

            public string StationID
            {
                get { return stationIDField; }
                set { stationIDField = value.Trim(); }
            }
            private double? latitudeField = null;

            public double? Latitude
            {
                get { return latitudeField; }
                set
                {
                    if ((value.Value >= -90.0) && (value.Value <= 90.0))
                    {
                        latitudeField = value;
                    }
                }
            }
            private double? longitudeField = null;

            public double? Longitude
            {
                get { return longitudeField; }
                set
                {
                    if ((value.Value >= -180.0) && (value.Value <= 180.0))
                    {
                        longitudeField = value;
                    }
                }
            }

            private double? elev = null;

            public double? Elevation
            {
                get { return elev; }
                set
                {
                    if (elev.Equals(-99999)) return;
                    elev = value;
                }
            }

            private string stateField;

            public string State
            {
                get { return stateField; }
                set { stateField = value.Trim(); }
            }

            private string countyField;

            public string County
            {
                get { return countyField; }
                set { countyField = value.Trim(); }
            }
            private string countryField;

            public string Country
            {
                get { return countryField; }
                set { countryField = value.Trim(); }
            }

            private DateTime? endDate = null;

            public DateTime? EndDate
            {
                get { return endDate; }
                set { endDate = value; }
            }
            private DateTime? beginDate = null;

            public DateTime? BeginDate
            {
                get { return beginDate; }
                set { beginDate = value; }
            }

            #region elevation
            public void SetElevation(String elevation)
            {
                if (elevation.Equals("-99999")) return;
                try
                {
                    double e;
                    if (double.TryParse(elevation, out e))
                    {
                        elev = e;
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            #endregion

            #region LatLon

            public void SetLatitude(string LatString)
            {
                try
                {
                    double l;
                    if (double.TryParse(LatString.Trim(), out l))
                    {
                        Latitude = l;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public void SetLongitude(string LonString)
            {
                try
                {
                    double l;
                    if (double.TryParse(LonString.Trim(), out l))
                    {
                        Longitude = l;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            #endregion

            #region datetime
            public void SetEndDate(string DateYYYYmm)
            {
                EndDate = DateTimeFromDateString(DateYYYYmm);
            }
            public void SetBeginDate(string DateYYYYmm)
            {
                BeginDate = DateTimeFromDateString(DateYYYYmm);
            }

            private static DateTime? DateTimeFromDateString(String YYYYmmDD)
            {
                YYYYmmDD = YYYYmmDD.Trim();
                if (!String.IsNullOrEmpty(YYYYmmDD) && YYYYmmDD.Length > 2)
                {
                    int year;
                    int month = 01;
                    int day = 01;
                    try
                    {
                        year = int.Parse(YYYYmmDD.Substring(0, 4));
                        if (YYYYmmDD.Length > 4)
                        {
                            month = int.Parse(YYYYmmDD.Substring(4, 2));
                        }
                        if (YYYYmmDD.Length > 6)
                        {
                            day = int.Parse(YYYYmmDD.Substring(6, 2));
                        }
                    }
                    catch
                    {
                        return null;
                        //throw new ArgumentException("Invalid year month. Submit as YYYYmm");
                    }

                    DateTime date = new DateTime(year, month, day);
                    return date;
                }
                else
                {
                    return null;
                    //throw new ArgumentException("Submitted date is not YYYYmm (year month) or null");
                }
            }
            #endregion
        }
    }
}
