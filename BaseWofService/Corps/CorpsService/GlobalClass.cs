using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using System.Configuration;
using System.Net;
using System.Xml;
using log4net;


/// <summary>
/// Summary description for GlobalClass
/// </summary>

namespace WaterOneFlow.Service
{

    public class GlobalClass : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger("CUAHSI.WEBSERVICES");

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            String codeDate = File.GetCreationTimeUtc(Assembly.GetExecutingAssembly().Location).ToString();

            
            String path = Context.Request.ApplicationPath;
            String network = ConfigurationManager.AppSettings["network"];
            String vocabulary = ConfigurationManager.AppSettings["vocabulary"];
            String process = "Start_" + network;

            String server = Dns.GetHostName();
            //IPHostEntry hostEntry = System.Net.Dns.GetHostEntry(server);
            //String ipAddress = "";
            //foreach (IPAddress ip in hostEntry.AddressList)
            //{
            //    ipAddress += ip.ToString() + ";";
            //}

            string ipAddress = null;
            try
            {
                ipAddress = GetClientIP(ConfigurationManager.AppSettings["clientIPUrl"]);
            }
            catch
            {
                ipAddress = "searchFailed";
            }

            String contact = ConfigurationManager.AppSettings["contactEmail"];

            log4net.GlobalContext.Properties["ipAddress"] = ipAddress;
            log4net.GlobalContext.Properties["contact"] = contact;
            log4net.GlobalContext.Properties["networkVocabulary"] = network;
            log4net.GlobalContext.Properties["variableVocabulary"] = vocabulary;
            log4net.GlobalContext.Properties["path"] = path;
            log4net.GlobalContext.Properties["server"] = server;
            log4net.GlobalContext.Properties["codeDate"] = codeDate;
            log.Info(process);
            // log.InfoFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|ver:{7}",
            //     process, server, path, network, vocabulary, ipAddress, contact, codeDate);
        }

        private string GetClientIP(String stringUrl)
        {
            Uri aUri = new Uri(stringUrl);
            StreamReader webRespReader = null;
            string ipAddress = null;
            string host = null;
            try
            {
                XmlReader reader = XmlReader.Create(stringUrl);
                reader.Read();
                reader.ReadStartElement("ip_address");

                reader.ReadStartElement("ip");
                ipAddress = reader.ReadString();
                reader.ReadEndElement();

                reader.ReadToNextSibling("host");
                //reader.ReadStartElement("host");
                host = reader.ReadString();

                reader.ReadEndElement();

                reader.Close();

            }
            catch (System.Net.WebException e)
            {
                if (e.Status == System.Net.WebExceptionStatus.ProtocolError)
                {
                    if (((HttpWebResponse)e.Response).StatusCode
                        == System.Net.HttpStatusCode.NotFound)
                    {
                        log.Error("Could not retrieve IP address at start. Not found");
                    }
                }
                else
                {
                    log.Error("Could not retrieve IP address at start " + ((HttpWebResponse)e.Response).StatusCode.ToString());
                }
            }
            return ipAddress;
        }


        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
           
            String path = "";
            String network = ConfigurationManager.AppSettings["network"];
            String vocabulary = ConfigurationManager.AppSettings["vocabulary"];
            String process = "Stop_" + network; 
            String server = Dns.GetHostName();
            IPHostEntry hostEntry = System.Net.Dns.GetHostEntry(server);
            String ipAddress = "";
            foreach (IPAddress ip in hostEntry.AddressList)
            {
                ipAddress += ip.ToString() + ";";
            }
            String contact = ConfigurationManager.AppSettings["contactEmail"];
            log.Info(process);
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            String serviceName = ConfigurationManager.AppSettings["GetValuesName"];
            String serviceUrl;
                string Port = Context.Request.ServerVariables["SERVER_PORT"];

                if (Port == null || Port == "80" || Port == "443")
                {
                    Port = "";                    
                }
                else
                {
                     Port = ":" + Port;
                }



                string Protocol = Context.Request.ServerVariables["SERVER_PORT_SECURE"];

                if (Protocol == null || Protocol == "0")

                    Protocol = "http://";

                else

                    Protocol = "https://";





                // *** Figure out the base Url which points at the application's root

                serviceUrl = Protocol + Context.Request.ServerVariables["SERVER_NAME"] +
                                            Port +
                                            Context.Request.ApplicationPath
                                            + "/" + ConfigurationManager.AppSettings["asmxPage"];

            Session.Add("serviceUrl", serviceUrl);
            Session.Add("serviceName", serviceName);

            log.Debug("SessionStarted");
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            log.Debug("SessionEnded");

        }
    }
       class FirstRequestInitialization
    {
        private static readonly ILog log = LogManager.GetLogger("CUAHSI.WEBSERVICES");
        
        private static bool s_InitializedAlready = false;
        private static Object s_lock = new Object();
        // Initialize only on the first request
        public static void Initialize(HttpContext context)
        {
            if (s_InitializedAlready)
            {
                return;
            }
            lock (s_lock)
            {
                if (s_InitializedAlready)
                {
                    return;
                }
                // Code that runs on application startup 
                String codeDate = File.GetCreationTimeUtc(Assembly.GetExecutingAssembly().Location).ToString();

                String process = "GenericODWS_Start";
                //String path = Context.Request.ApplicationPath;
                String network = ConfigurationManager.AppSettings["network"];
                String vocabulary = ConfigurationManager.AppSettings["vocabulary"];

                String server = Dns.GetHostName();


                string ipAddress = "not used";
                //try
                //{
                //    ipAddress = GetClientIP(ConfigurationManager.AppSettings["clientIPUrl"]);
                //}
                //catch
                //{
                //    ipAddress = "searchFailed";
                //}

                String contact = ConfigurationManager.AppSettings["contactEmail"];

                log4net.GlobalContext.Properties["ipAddress"] = ipAddress;
                log4net.GlobalContext.Properties["contact"] = contact;
                log4net.GlobalContext.Properties["networkVocabulary"] = network;
                log4net.GlobalContext.Properties["variableVocabulary"] = vocabulary;
                // log4net.GlobalContext.Properties["path"] = path;
                log4net.GlobalContext.Properties["server"] = server;
                log4net.GlobalContext.Properties["codeDate"] = codeDate;
                log.Info(process);
                s_InitializedAlready = true;
            }
        }
    }
}

