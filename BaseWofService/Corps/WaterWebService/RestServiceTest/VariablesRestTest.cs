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
    public class VariablesResTest
    {
        private RestServiceClient.v1.VariableInfoRest restServiceClient;
        private string[] parameters;
        [SetUp]
        public void init()
        {
            restServiceClient = new RestServiceClient.v1.VariableInfoRest();
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
        

        
        
    }
}
