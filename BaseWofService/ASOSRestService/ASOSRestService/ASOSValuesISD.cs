using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using WaterOneFlow.Service.Constants.v1;
using WaterOneFlow.Service.v1_0.Passthrough;
using WaterOneFlowImpl;
using log4net;


namespace NCDC.RestService
{
    namespace v1
    {
        
        using WaterOneFlowImpl.v1_0;
        using WaterOneFlow.Service.v1_0;
        // use TimeSeriesResponse rather than TimeSeriesResponseType. 
        //  This insures the proper type is used (And can be changed in one line)
        using TimeSeriesResponse = WaterOneFlow.Schema.v1.TimeSeriesResponseType;

        public class ASOSValuesISD : DataTimeSeriesWofService
        {
  
            
 
            private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

  
            private XmlSerializer serializer;

            private NCDC.RestService.v1.TimeSeries  svc;

            string token;

            public string Token
            {
                get { return token; }
                set
                {
                    if (value.Equals("[YOUR TOKEN]"))
                {
                    throw new WaterOneFlowServerException("MICONFIGURATION.  SET NCDC_Token in app.settings");
                }
                    token = value;
                }
            }


            public ASOSValuesISD()
                : base()
            {

                svc = new NCDC.RestService.v1.TimeSeries();

                token = Properties.Settings.Default.token;

                //serializer = new XmlSerializer(typeof(TimeSeriesResponse)); // set in above using statement

            }


            /* REFORMAT to WaterML 1.0  */
            [return: XmlElement(
     Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "timeSeriesResponse",
   IsNullable = false
  , Type = typeof(TimeSeriesResponse)   // set in above using statement
     )]
            public override object GetTimeSeries(
       locationParam Location,
        VariableParam Variable,
        W3CDateTime? BeginDateTime, W3CDateTime? EndDateTime)
            {
                string siteNum;
                string parameterCode;
                string statisticCode;
                string agencyCode;
                string startDateTime = null;
                string endDateTime = null;

                if (Location != null)
                {
                    siteNum = Location.SiteCode;
                }
                else
                {

                    throw new WaterOneFlowException("Missing SiteCode ");
                }

                if (Variable != null)
                {
                    parameterCode = Variable.Code;

                }
                else
                {
                    throw new WaterOneFlowException("Missing Parameter ");

                }

                if (BeginDateTime.HasValue) startDateTime = BeginDateTime.Value.DateTime.ToString("yyyyMMdd"); // NCDC DateTime
                if (EndDateTime.HasValue) endDateTime = EndDateTime.Value.DateTime.ToString("yyyyMMdd");// NCDC DateTime


                try
                {


                  TimeSeriesResponse response;  // set in above using statement
                    /* This could be done by keying off the passed in name.
                     * but then the Sites and Variables would also need to be coded
                     * */
                  response = svc.GetNCDCParitalResponse(siteNum,
                                    parameterCode, 
                                    startDateTime, endDateTime,
                                    token, "isd");

                    return response;
                }
                catch ( WaterOneFlowException ex)
                   
                {
                    log.Debug("User Parameter Error", ex);
                    throw ex;
                } catch (WaterOneFlowSourceException ex )
                {
                    log.Debug("Source Error", ex); 
                    throw ex;
                }  catch (WaterOneFlowServerException ex )
                {
                    log.Debug("NCDC known issue", ex); 
                    throw ex;
                } catch (Exception ex) {
                     log.Info("Unknown error connecting to NCDC " ,ex);
                    throw new WaterOneFlowSourceException("No data or error accesing NCDC");
  
                }


              


            }


     


       

   


        }
    }
}
