﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EPAWOFService.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SELECT * FROM {0} WHERE SiteCode = @siteCode ")]
        public string SiteCodeQueryFormat {
            get {
                return ((string)(this["SiteCodeQueryFormat"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SELECT * FROM {0} WHERE VariableCode = @variableCode ")]
        public string VariableCodeQueryFormat {
            get {
                return ((string)(this["VariableCodeQueryFormat"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SELECT * FROM {0} WHERE VariableID = @variableID")]
        public string VariableIDQueryFormat {
            get {
                return ((string)(this["VariableIDQueryFormat"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SELECT  top 50000 * FROM {0}")]
        public string getAllQueryFormat {
            get {
                return ((string)(this["getAllQueryFormat"]));
            }
        }
        
        /// <summary>
        /// the USGS changed the name of the column at one point. This makes it so we do not have to recompile
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("the USGS changed the name of the column at one point. This makes it so we do not " +
            "have to recompile")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("parm_cd")]
        public string parameterColumn {
            get {
                return ((string)(this["parameterColumn"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://ofmpub.epa.gov:80/STORETwebservices/StoretResultService/")]
        public string EPAWOFService_Epa_StoretResultsService_StoretResultService {
            get {
                return ((string)(this["EPAWOFService_Epa_StoretResultsService_StoretResultService"]));
            }
        }
    }
}
