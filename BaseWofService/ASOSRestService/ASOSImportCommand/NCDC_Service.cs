using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using log4net;

namespace NCDC.RestService.Import
{
    partial class NCDC_Service : ServiceBase
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(NCDC_Service));
        public NCDC_Service()
        {
             logger.Debug("Initialing");
                 InitializeComponent();
           
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            logger.Debug("Start NCDC Data Harvest Service");
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
