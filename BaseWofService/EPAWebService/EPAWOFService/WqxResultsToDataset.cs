using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;
using log4net;
using WaterOneFlowImpl;

namespace EPAWOFService
{
    /// <summary>
    /// Retrieves data from EPAStationResultsService, and returns a dataset
    /// <para>
    /// In order to get Performance, this is implemented as XMLReader (EPa Returns a string)
    /// </para>
    /// <para>
    /// To use this class, create an instance, and set the Organizaiton, MonitoringLocation, and CharacteristicName
    /// A shortcut is to call GetStationResults
    /// </para>
    /// </summary>
    /// 
    public class WqxResultsToDataset
    {
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected static readonly string messageLead = "EPA StationResults: ";
        private Epa.StoretResultsService.StoretResultService svc
            = new Epa.StoretResultsService.StoretResultService();

        private string OrganizationIdField;

        /// <summary>
        /// Organization
        /// OrganizationIdField
        /// </summary>

        public string Organization
        {
            get { return OrganizationIdField; }
            set { OrganizationIdField = value; }
        }
        private string MonitoringLocationIdField;

        /// <summary>
        /// MonitoringLocationId, equal to SiteCode,  
        /// </summary>
        public string MonitoringLocation
        {
            get { return MonitoringLocationIdField; }
            set { MonitoringLocationIdField = value; }
        }

        /// <summary>
        /// Format: MM/DD/YYYY 
        /// .net ToString("MM/dd/yyyy");
        /// </summary>
        public string MinimumActivityStartDate
        {
            get { return MinimumActivityStartDateField; }
            set
            {
                DateTime dt = new DateTime();
                if (DateTime.TryParse(value, out dt)) MinimumActivityStartDateField = value;
            }
        }

        /// <summary>
        /// Format: MM/DD/YYYY 
        /// .net ToString("MM/dd/yyyy");
        /// </summary>
        public string MaximumActivityStartDate
        {
            get { return MaximumActivityStartDateField; }
            set
            {
                DateTime dt = new DateTime();
                if (DateTime.TryParse(value, out dt)) MaximumActivityStartDateField = value;
            }
        }

        private string MonitoringLocationTypeField = "";
        private string MinimumActivityStartDateField = "";
        private string MaximumActivityStartDateField = "";
        private string MinimumLatitudeField = "";
        private string MaximumLatitudeField = "";
        private string MinimumLongitudeField = "";
        private string MaximumLongitudeField = "";
        string CharacteristicTypeField = "";
        private string CharacteristicNameField = "";

        public string CharacteristicName
        {
            get { return CharacteristicNameField; }
            set { CharacteristicNameField = value; }
        }
        // regular, biological,habitat
        private string ResultTypeField = "regular";


        public void SetDateRange(W3CDateTime? begin, W3CDateTime? end)
        {
            if (begin.HasValue) MinimumActivityStartDate = begin.Value.DateTime.ToString("MM/dd/yyyy");
            // expand end date by one day to handle errors in EPA, and Hydrodesktop
            if (end.HasValue) MaximumActivityStartDate = end.Value.DateTime.AddDays(1).ToString("MM/dd/yyyy");
        }

        public static EPAResults.StoretResultFlatDataTable GetStationResults(string Agency, string SiteCode, string VariableName, W3CDateTime? BeginDate, W3CDateTime? EndDate)
        {
            WqxResultsToDataset svc = new WqxResultsToDataset();
            svc.Organization = Agency;
            svc.MonitoringLocation = SiteCode;
            svc.CharacteristicName = VariableName;
            svc.SetDateRange(BeginDate, EndDate);

            if (svc.getCount() < 20000)
            {
                EPAResults.StoretResultFlatDataTable results = svc.getResults();
                return results;
            }

            return null;
        }

        public int getCount()
        {
            int count =
                svc.getResultCount(Organization,
                                   MonitoringLocation,
                                   MonitoringLocationTypeField,
                                   MinimumActivityStartDateField,
                                   MaximumActivityStartDateField,
                                   MinimumLatitudeField,
                                   MaximumLatitudeField,
                                   MinimumLongitudeField,
                                   MaximumLongitudeField,
                                   CharacteristicTypeField,
                                   CharacteristicName,
                                   ResultTypeField);
            return count;

        }

        public EPAResults.StoretResultFlatDataTable getResults()
        {
           XmlDocument xdoc = new XmlDocument();

    ;


            xdoc.Load(new StringReader(svc.getResults(Organization,
                                                      MonitoringLocation,
                                                      MonitoringLocationTypeField,
                                                      MinimumActivityStartDateField,
                                                      MaximumActivityStartDateField,
                                                      MinimumLatitudeField,
                                                      MaximumLatitudeField,
                                                      MinimumLongitudeField,
                                                      MaximumLongitudeField,
                                                      CharacteristicTypeField,
                                                      CharacteristicName,
                                                      ResultTypeField)));
          
          //  XmlNodeList results = (XmlNodeList)  xdoc.GetElementsByTagName("WQX");
            XmlNodeList results = (XmlNodeList)xdoc.GetElementsByTagName("STORETResults");
            
            if (results != null && results.Count > 0)
            {
                XmlNode wqx = results[0];


                EPAResults.StoretResultFlatDataTable table = wqx2datatable(wqx, true);
                return table;

            }
            else
            {
                return null;
            }
        }

        private EPAResults.StoretResultFlatDataTable wqx2datatable(XmlNode wqx, bool MatchCharacteristicName)
        {
            EPAResults.StoretResultFlatDataTable table = new EPAResults.StoretResultFlatDataTable();
            XmlNodeList orgs = wqx.SelectNodes("Organization");
            foreach (XmlNode org in orgs)
            {
                string agencyCode = null;
                string orgName = null;
                try
                {
                    agencyCode = org.SelectSingleNode("OrganizationDescription/OrganizationIdentifier").InnerText;
                    orgName = org.SelectSingleNode("OrganizationDescription/OrganizationFormalName").InnerText;
                }
                catch
                {
                    log.Error(messageLead + "No agency or org name" + org.SelectSingleNode("OrganizationDescription/").ToString());
                    break;
                }
                XmlNodeList activities = org.SelectNodes("Activity");
                foreach (XmlNode activity in activities)
                {
                    string siteCode = null;
                    string sampleMedium = null;
                    string localDate = null;
                    string localTime = null;
                    try
                    {
                        siteCode = activity.SelectSingleNode("MonitoringLocation/MonitoringLocationIdentifier").InnerText;

                    }
                    catch
                    {
                        log.Error(messageLead + "No site Code in Monitoring");
                        break;
                    }
                    try
                    {
                        localDate = activity.SelectSingleNode("ActivityDescription/ActivityStartDate").InnerText;
                        try
                        {
                            localTime = activity.SelectSingleNode("ActivityDescription/ActivityStartTime").InnerText;
                       
                            if ( Regex.IsMatch(localTime,"^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$" ))
                            {
                                localDate = String.Format("{0} {1}", localDate, localTime);
                            }
                        }
                        catch
                        {
                            log.Info(messageLead + "No actvity time");
                        }

                        
                    }
                    catch
                    {
                        log.Error(messageLead + "No actvity date");
                        break;
                    }

                    try
                    {
                        sampleMedium = activity.SelectSingleNode("ActivityDescription/ActivityMediaName").InnerText;
                    }
                    catch
                    {
                        log.Error(messageLead + "No  sample medium in ActivityDescription");

                    }


                    XmlNodeList results = activity.SelectNodes("Result");
                    foreach (XmlNode result in results)
                    {
                        string variableName = null;


                        string comments = null;
                        string methodCode = null;
                        string methodVocabulary = null;
                        string methodDescription = null;
                        string methodName = null; // combine code and vocab for EPA
                        string labName = null;
                        string detectionQuantitationLimit = null;

                        /* add precision, bias, confidence interval later
                         */
                        try
                        {
                            // if no characteristic name, we can't use it
                            variableName = result.SelectSingleNode("ResultDescription/CharacteristicName").InnerText;


                            if (MatchCharacteristicName)
                            {
                                // assume specific name  
                                if (!variableName.Equals(CharacteristicName, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    // not equal to the request, skip it
                                    break;
                                }
                            }
                            XmlNode x;
                            x = result.SelectSingleNode("ResultDescription/ResultCommentText");

                            if (x != null)
                            {
                                comments = x.InnerText.Trim();
                            }

                            x = result.SelectSingleNode("ResultAnalyticalMethod/MethodIdentifier");
                            if (x != null)
                            {
                                methodCode = x.InnerText.Trim();
                            }
                            x = result.SelectSingleNode("ResultAnalyticalMethod/MethodIdentifierContext");
                            if (x != null)
                            {
                                methodVocabulary = x.InnerText.Trim();
                            }
                            // EPA mathod name as determined by dwv, MethodVocab:MethodCode
                            methodName = methodVocabulary + ":" + methodCode;

                            x = result.SelectSingleNode("ResultLabInformation/ResultLaboratoryCommentCode");
                            if (x != null)
                            {
                                methodDescription = x.InnerText.Trim();
                            }

                            x = result.SelectSingleNode("ResultLabInformation/ResultLaboratoryCommentCode");
                            if (x != null)
                            {
                                labName = x.InnerText.Trim();
                            }
                            x = result.SelectSingleNode("ResultLabInformation/ResultDetectionQuantitationLimit");
                            if (x != null)
                            {
                                detectionQuantitationLimit = x.InnerText.Trim();
                            }

                            try
                            {
                                XmlNodeList resultMeasures = result.SelectNodes("ResultDescription/ResultMeasure");
                                if (resultMeasures != null && resultMeasures.Count > 0)
                                {
                                    foreach (XmlNode measure in resultMeasures)
                                    {
                                        string value = null;
                                        string unitCode = null;
                                        string qualifierCode = null;
                                        try
                                        {
                                            //value = measure.FirstChild.InnerText;
                                            //unitCode = measure.FirstChild.NextSibling.InnerText.Trim();
                                            value = measure.SelectSingleNode("ResultMeasureValue").InnerText.Trim();
                                            unitCode = measure.SelectSingleNode("MeasureUnitCode").InnerText.Trim();
                                            qualifierCode = measure.SelectSingleNode("MeasureQualifierCode").InnerText.Trim();
                                            if (String.IsNullOrEmpty(value))
                                            {
                                                value = "-9999";
                                            }
                                        }
                                        catch
                                        {
                                            log.Info(messageLead + "could not convert ResultMeasure " + measure.ToString());

                                        }
                                        decimal numericValue;


                                        if (!Decimal.TryParse(value, out numericValue))
                                        {
                                            value = "-9999";
                                        }

                                        table.AddStoretResultFlatRow(agencyCode,
                                                                     siteCode, variableName,
                                                                     sampleMedium,
                                                                     localDate,
                                                                     value,
                                                                     unitCode,
                                                                     comments,
                                                                     qualifierCode,
                                                                     null, //ResultValueTypeName
                                                                     null, //DataType
                                                                     null, //Precision
                                                                     null, //CI
                                                                     methodCode, //MethodCode
                                                                     methodVocabulary, // MethodVocabulary
                                                                     methodDescription, // MethodDescription
                                                                     labName,
                                        detectionQuantitationLimit,
     methodName
                                        );
                                    }
                                }
                            }
                            catch
                            {
                                log.Error(messageLead + " Could not convert ResultMeasure");
                            }



                        }
                        catch
                        {
                            log.Error(messageLead + "could not convert result " + result.ToString());
                        }

                    }

                }
            }
            return table;
        }
        /*
 OrganizationId 	string 	
MonitoringLocationId 	string 	
MonitoringLocationType 	string 	
MinimumActivityStartDate 	string 	
MaximumActivityStartDate 	string 	
MinimumLatitude 	string 	
MaximumLatitude 	string 	
MinimumLongitude 	string 	
MaximumLongitude 	string 	
CharacteristicType 	string 	
CharacteristicName 	string 	
ResultType 	string 	
	*/
        /* trying to get the logic correct
         * 
         * Request is for station-parameter
         * but logic should be generic
         * GetCounts()
         * - return count of 
         * -- org
         * -- activities
         * -- stations
         * -- CharacteristicName
         * -- Units
         * GetOrgs()
         * GetActivities(org)
         * GetMonitoringLocations()
         * GetMonitoringLocations(org)
         * GetMonitoringLocations(org,activity)
         * GetCharacteristicNames()
         * GetCharacteristicNames(Station)
         * GetDataTable()
         * GetDataTable(org,station)
        * -- org, stations, CharacteristicName, Units, values, ResultStatusIdentifier,ResultValueTypeName,ResultCommentText
         * */
    }
}
