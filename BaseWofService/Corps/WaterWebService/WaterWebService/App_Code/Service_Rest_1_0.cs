
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using log4net;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Services.Protocols;
using WaterOneFlow.Service;

using WaterOneFlow.Service.Constants.v1;
using WaterOneFlowImpl;


namespace WaterOneFlow.Service
{

    namespace v1_0
    {

        using GetDataInformationDB = RestServiceClient.Generic.v10.DataInformationService;
        
        using WaterOneFlow.Schema.v1;
        using DataTimeSeriesWofSrv = RestServiceClient.Generic.v10.RestDataTimeSeriesWofService;
        using WaterOneFlowImpl.v1_0;

        // overriding Service_1_0  GetValues method
         using TimeSeriesResponseTypeGeneric = WaterOneFlow.Service.Response.v1.TimeSeriesResponseType;
        using TimeSeriesResponseTypeObject = WaterOneFlow.Schema.v1.TimeSeriesResponseType;

        [WebService(Name = WsDescriptions.WsDefaultName,
    Namespace = Constants.WS_NAMSPACE,
    Description = WsDescriptions.WsDefaultDescription)]
       // [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        
        public class Service_Rest_1_0 : Service_1_0
        {



            public Service_Rest_1_0()
            {

                ODws = new GetDataInformationDB();
                ODws.VariableVocabulary = "NCDCISH";
                ODws.SiteVocabulary = "NCDCISH";
                QueryLoggger = new Logging(ODws.SiteVocabulary);

                // configure
                ConnectionStringSettings oddb = ConfigurationManager.ConnectionStrings["ODDB"];
                Dictionary<String,object> parameters = new Dictionary<string, object>();
                parameters.Add("DataInfoConnection", oddb.ConnectionString);
                parameters.Add("VariablesTableName", "ish_variables");
                parameters.Add("SitesTableName", "ish_sites");
                parameters.Add("SeriesTableName", "ish_SeriesCatalog");
                ODws.Parameters = parameters;


                // configured in using statement above
                dvSvc = new DataTimeSeriesWofSrv();

                //    #endregion
            }

            [return: XmlElement(
             Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "timeSeriesResponse",
           IsNullable = false
           , Type = typeof(TimeSeriesResponseTypeGeneric)
             )]
            [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
            public object GetValuesObject(string location, string variable, string startDate, string endDate, String authToken)
            {
                if (!useODForValues) throw new SoapException("GetValues implemented external to this service. Call GetSiteInfo, and SeriesCatalog includes the service Wsdl for GetValues. Attribute:serviceWsdl on Element:seriesCatalog XPath://seriesCatalog/[@serviceWsdl]", new XmlQualifiedName("ServiceException"));

                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogValuesStart(Logging.Methods.GetValues, // method
                            location, //location
                            variable, //variable
                            startDate, // startdate
                            startDate, //enddate
                            Context.Request.UserHostName);

                try
                {
                    WaterOneFlowImpl.locationParam lParam = new locationParam(location);
                    VariableParam vparam = new VariableParam(variable);
              
                    /* Look to see if siates exist.
                     * NCDC sends back 200k for thier rest service.
                     * aka no errors, except as a string
                     * */
                    SiteInfoType site;
                    try
                    {
                      site  = ODws.GetSiteInfoObject(lParam);
                     
                    if (site == null )
                    {
                        throw new WaterOneFlowException("Unknown Site Code: '" + location + "'");
                    }
                    } catch (WaterOneFlowException wex)
                    {
                        throw new WaterOneFlowException("Unknown Site Code: '" + location + "'");
                    } catch(WaterOneFlowServerException wex)
                    {
                        log.Fatal("Database Error");
                        throw wex;
                    } catch ( Exception ex)
                    {
                        log.Error("Unhandled Exception ", ex);
                        throw new WaterOneFlowServerException("Unhandled Error.");
                    }

                    VariableInfoType[] vars;
                    try
                    {
                        vars = ODws.GetVariableInfoObject(vparam);
                    
                    if (vars.Length ==0)
                    {
                        throw new WaterOneFlowException("Unknown Variable Code: '" + variable + "'");
                    }
                }
                catch (WaterOneFlowException wex)
                {
                    throw new WaterOneFlowException("Unknown Variable Code: '" + variable + "'");
                }
                catch (WaterOneFlowServerException wex)
                {
                    log.Fatal("Database Error");
                    throw wex;
                }
                catch (Exception ex)
                {
                    log.Error("Unhandled Exception ", ex);
                    throw new WaterOneFlowServerException("Unhandled Error.");
                }

                    // moved date check after site and variable check
                W3CDateTime? startDt = null;
                W3CDateTime? endDt = null;
                if (!String.IsNullOrEmpty(startDate)) startDt = new W3CDateTime(DateTime.Parse(startDate));
                if (!String.IsNullOrEmpty(endDate))
                {
                    endDt = new W3CDateTime(DateTime.Parse(endDate));
                    int endDateMin = int.Parse(ConfigurationManager.AppSettings.Get("NCDCISD_EndDateMinYear"));
                    if (endDt.Value.DateTime.Year < endDateMin)
                    {
                        throw new WaterOneFlowException("NCDC ISD and ISH No Data is available before: " + endDateMin);
                    }
                }
  
                    /***********************
                     * GET  RESPONSE 
                     * *********************
                     */
                    TimeSeriesResponseTypeObject res = (TimeSeriesResponseTypeObject)dvSvc.GetTimeSeries(lParam, vparam, startDt, endDt);


                    ///***********************
                    //  * Add missing information from sites and variables db 
                    //  * *********************
                    //  */
                    //if (vars.Length >0)
                    //{
                    //    res.timeSeries.variable = vars[0];
                    //}
                    //if (site != null )
                    //{
                    //    res.timeSeries.sourceInfo = site;
                    //}

                    
                    return new WaterOneFlow.Service.v1_0.xsd.TimeSeriesResponse(res);
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                                location, //locaiton
                                variable, //variable
                                startDate, // startdate
                                startDate, //enddate
                                timer.ElapsedMilliseconds, // processing time
                                -9999, // count 
                                Context.Request.UserHostName
                                );
                    throw SoapExceptionGenerator.WOFExceptionToSoapException(we);

                }

            }
        }
    }
}