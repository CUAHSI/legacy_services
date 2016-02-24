using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using NUnit.Fixtures;
using NUnit.Framework;
using RestServiceClient;
using WaterOneFlow.Schema.v1;

namespace RestServiceTest
{
    [TestFixture]
    public class ResTest
    {
        private BaseRestClient restServiceClient;
        private string[] parameters;
        [SetUp]
        public void init()
        {
            restServiceClient = new BaseRestClient();
           // restServiceClient.BaseUrl = "http://www2.mvr.usace.army.mil/watercontrol/webserviceWaterML.cfm?";
            restServiceClient.BaseUrl = "http://www2.mvr.usace.army.mil/watercontrol/webservices/REST/webserviceWaterML.cfm?";
 
        }
        [Test]
        public void testUrl ()
        {
            restServiceClient.PathFormat = "Meth={0}&variable={1}";
            string varCode = "HG"; // prep for many test
            parameters = new string[2];
            parameters[0] = "getVariableInfo";
            parameters[1] = varCode;
            string url = restServiceClient.createUrl(parameters);

            Assert.That(url.Contains(varCode));
        }
        [Test]
        public void testVariables()
        {
            restServiceClient.PathFormat = "Meth={0}&variable={1}";

            string varCode = "HG"; // prep for many test

            Type vType = typeof(VariablesResponseType);
            restServiceClient.ResponseType = vType;
            parameters = new string[2];
            parameters[0] = "getVariableInfo";
            parameters[1] = varCode;

            object res = restServiceClient.GetResponseAsObject(parameters);

            Assert.IsInstanceOfType(vType, res);
            VariablesResponseType variablesResponse = (VariablesResponseType)res;

            Assert.That(variablesResponse.variables.Length == 1, "Should only return 1 variable");
            Assert.That(variablesResponse.variables[0].variableCode[0].Value.Equals(varCode));
        }
        [Test]
        public void testVariablesAll()
        {
            restServiceClient.PathFormat = "Meth={0}&variable={1}";

            string varCode = ""; // prep for many test

            Type vType = typeof(VariablesResponseType);
            restServiceClient.ResponseType = vType;
            parameters = new string[2];
            parameters[0] = "getVariableInfo";
            parameters[1] = varCode;

            object res = restServiceClient.GetResponseAsObject(parameters);

            Assert.IsInstanceOfType(vType, res);
            VariablesResponseType variablesResponse = (VariablesResponseType)res;

            Assert.That(variablesResponse.variables.Length > 0, "Should return more than 1 variable");
            
        }
        [Test]
        public void testVariablesAll2()
        {
            restServiceClient.PathFormat = "Meth={0}";

            string varCode = ""; // prep for many test

            Type vType = typeof(VariablesResponseType);
            restServiceClient.ResponseType = vType;
            parameters = new string[2];
            parameters[0] = "getVariableInfo";
            parameters[1] = varCode;

            object res = restServiceClient.GetResponseAsObject(parameters);

            Assert.IsInstanceOfType(vType, res);
            VariablesResponseType variablesResponse = (VariablesResponseType)res;

            Assert.That(variablesResponse.variables.Length > 0, "Should return more than 1 variable");

        }
        public void testObject()
        {
            restServiceClient.PathFormat = "Meth={0}&variable={1}";
            
            parameters = new string[2];
            parameters[0] = "getVariableInfo";
            parameters[1] = "HG";

            object res = restServiceClient.GetWaterML(parameters);

            Assert.IsNotNull(res, "No information returned");
            
        }

        [Test]
        public void testValues()
        {
            
            
            restServiceClient.PathFormat = "Meth={0}&site={1}&variable={2}&beginDate={3}&endDate={4}";

            string varCode = "HG"; // prep for many test
            string siteCode = "01080";
            string beginDate = "2009-01-01";
            string endDate = "2009-09-01"; 

            Type vType = typeof(TimeSeriesResponseType);
            restServiceClient.ResponseType = vType;
            parameters = new string[5];
            parameters[0] = "getValues";
            parameters[1] = siteCode;
            parameters[2] = varCode;
            parameters[3] = beginDate;
            parameters[4] = endDate;

            object res = restServiceClient.GetResponseAsObject(parameters);

            Assert.IsInstanceOfType(vType, res);
            TimeSeriesResponseType response = (TimeSeriesResponseType)res;

            Assert.That(response.timeSeries.variable.variableCode[0].Value == varCode, "should match variabel code");
            //Assert.That(response.timeSeries.sourceInfo.variableCode[0].Value.Equals(varCode));

            Assert.That(response.timeSeries.values.value.Length > 1, "no values returned");
        }

        [Test]
        public void testValues2()
        {
            restServiceClient.PathFormat = "Meth={0}&location={1}&variable={2}";

            string varCode = "HG"; // prep for many test
            string siteCode = "01080";
            string beginDate = "2009-01-01";
            string endDate = "2009-09-01";

            Type vType = typeof(TimeSeriesResponseType);
            restServiceClient.ResponseType = vType;
            parameters = new string[5];
            parameters[0] = "getValues";
            parameters[1] = siteCode;
            parameters[2] = varCode;
            parameters[3] = beginDate;
            parameters[4] = endDate;

            object res = restServiceClient.GetResponseAsObject(parameters);

            Assert.IsInstanceOfType(vType, res);
            TimeSeriesResponseType response = (TimeSeriesResponseType)res;

            Assert.That(response.timeSeries.variable.variableCode[0].Value == varCode, "should match variabel code");
            //Assert.That(response.timeSeries.sourceInfo.variableCode[0].Value.Equals(varCode));

            Assert.That(response.timeSeries.values.value.Length > 1, "no values returned");
        }

        [Test]
        public void testSites()
        {
            restServiceClient.PathFormat = "Meth={0}&site={1}";

            string siteCode = "01080"; // prep for many test

            Type vType = typeof(SiteInfoResponseType);
            restServiceClient.ResponseType = vType;
            parameters = new string[2];
            parameters[0] = "GetSites";
            parameters[1] = siteCode;

            object res = restServiceClient.GetResponseAsObject(parameters);

            Assert.IsInstanceOfType(vType, res);
            SiteInfoResponseType response = (SiteInfoResponseType)res;

            Assert.That(response.site.Length  == 1, "Should only return 1 site");
            Assert.That(response.site[0].siteInfo.siteCode[0].Value == siteCode, "site code does not match");
        }
        [Test]
        public void testSites2Sites()
        {
            restServiceClient.PathFormat = "Meth={0}&site={1}&site={2}";

            string siteCode = "01080"; // prep for many test

            Type vType = typeof(SiteInfoResponseType);
            restServiceClient.ResponseType = vType;
            parameters = new string[3];
            parameters[0] = "GetSites";
            parameters[1] = siteCode;
            parameters[2] = "01320";

            object res = restServiceClient.GetResponseAsObject(parameters);

            Assert.IsInstanceOfType(vType, res);
            SiteInfoResponseType response = (SiteInfoResponseType)res;

            Assert.That(response.site.Length == 2, "Should return 2 sites");
            Assert.That(response.site[0].siteInfo.siteCode[0].Value == siteCode, "site code does not match");
            Assert.That(response.site[1].siteInfo.siteCode[0].Value == "01320", "site code does not match");
        }
        [Test]
        public void testSitesAll()
        {
            restServiceClient.PathFormat = "Meth={0}&sites={1}";

            string varCode = "ALL"; // prep for many test

            Type vType = typeof(SiteInfoResponseType);
            restServiceClient.ResponseType = vType;
            parameters = new string[2];
            parameters[0] = "GetSites";
            parameters[1] = varCode;

            object res = restServiceClient.GetResponseAsObject(parameters);

            Assert.IsInstanceOfType(vType, res);
            SiteInfoResponseType response = (SiteInfoResponseType)res;

            Assert.That(response.site.Length > 0, "No sites returned");
            
        }

        [Test]
        public void testSiteInfo()
        {
            restServiceClient.PathFormat = "Meth={0}&site={1}";

            string siteCode = "01080"; // prep for many test

            Type vType = typeof(SiteInfoResponseType);
            restServiceClient.ResponseType = vType;
            parameters = new string[2];
            parameters[0] = "GetSiteInfo";
            parameters[1] = siteCode;

            object res = restServiceClient.GetResponseAsObject(parameters);

            Assert.IsInstanceOfType(vType, res);
            SiteInfoResponseType response = (SiteInfoResponseType)res;

            Assert.That(response.site.Length == 1, "Should only return 1 site");
            Assert.That(response.site[0].siteInfo.siteCode[0].Value == siteCode, "site code does not match");
            Assert.That(response.site[0].seriesCatalog != null, "missing series catalog");
            Assert.That(response.site[0].seriesCatalog.Length >0 , " no entries in  series catalog");
            Assert.That(response.site[0].seriesCatalog[0].series.Length > 0, " no entries in  series catalog");
            Assert.That(response.site[0].seriesCatalog[0].series[0].variable != null, " mising variable in frist entry");
            //Assert.That(response.site[0].seriesCatalog[0].series[0].variableTimeInterval != null, " no time period is specified");
            //Assert.That(response.site[0].seriesCatalog[0].series[0].valueCount != null, " no value count is specified");

        }

        [Test]
        [Ignore("Missing file")]
        public void testValidation()
        {
  
            restServiceClient.PathFormat = "Meth={0}&location={1}&variable={2}";

            string varCode = "HG"; // prep for many test
            string siteCode = "01080";
            string beginDate = "2009-01-01";
            string endDate = "2009-09-01";

            Type vType = typeof(TimeSeriesResponseType);
            restServiceClient.ResponseType = vType;
            parameters = new string[5];
            parameters[0] = "getValues";
            parameters[1] = siteCode;
            parameters[2] = varCode;
            parameters[3] = beginDate;
            parameters[4] = endDate;

            FileStream file =
                File.OpenRead(
                    @"E:\Documents and Settings\valentin\My Documents\cuahsi\waterml\HydrologicDataExamples\Corps\timeSeries_01080_hg.xml");
            XmlReader reader = XmlReader.Create(file);
                      XmlReaderSettings settings = new XmlReaderSettings();
            settings.CheckCharacters = false;
            settings.IgnoreWhitespace = true;

            object res = restServiceClient.testValidation(reader);
            file.Close();

            Assert.IsInstanceOfType(vType, res);
            TimeSeriesResponseType response = (TimeSeriesResponseType)res;

            Assert.That(response.timeSeries.variable.variableCode[0].Value == varCode, "should match variabel code");
            //Assert.That(response.timeSeries.sourceInfo.variableCode[0].Value.Equals(varCode));

            Assert.That(response.timeSeries.values.value.Length > 1, "no values returned");
        }
        
    }
}
