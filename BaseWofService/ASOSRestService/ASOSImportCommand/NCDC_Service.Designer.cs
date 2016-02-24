namespace NCDC.RestService.Import
{
    partial class NCDC_Service
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NCDCserviceController1 = new System.ServiceProcess.ServiceController();
            // 
            // NCDCserviceController1
            // 
            this.NCDCserviceController1.ServiceName = "CUAHSI_NCDC_harvest";
            // 
            // NCDC_Service
            // 
            this.ServiceName = "NCDC_Service";

        }

        #endregion

        private System.ServiceProcess.ServiceController NCDCserviceController1;
    }
}
