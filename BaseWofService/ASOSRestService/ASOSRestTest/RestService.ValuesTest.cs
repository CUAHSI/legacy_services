
using System;
using System.Text;
using System.Collections.Generic;
using NCDC.RestService.v1;
using WaterOneFlow.Schema.v1;

using NUnit.Framework;

namespace ASOSRestTest
{
    /// <summary>
    ///This is a test class for NCDC.RestService.TimeSeries and is intended
    ///to contain all NCDC.RestService.TimeSeries Unit Tests
    ///</summary>
    [TestFixture]
    public class TimeSeriesTest
    {


        


        /// <summary>
        ///A test for GetNCDCParitalResponseISD (string, string, string, string, string)
        ///</summary>
        [Test]
        public void GetNCDCParitalResponseISDTest()
        {
            TimeSeries target = new TimeSeries();

            string NCDCSiteCode = "72584523225"; // TODO: Initialize to an appropriate value

            string NCDCVariableCode = "CIG"; // TODO: Initialize to an appropriate value

            string BeginDate = "20080101"; // TODO: Initialize to an appropriate value

            string endDate = "20080131"; // TODO: Initialize to an appropriate value

            string token = "bgFcccciDafJnemlGInn"; // TODO: Initialize to an appropriate value

           // TimeSeriesResponseType expected = null;
            TimeSeriesResponseType actual;

            actual = target.GetNCDCParitalResponse(NCDCSiteCode, NCDCVariableCode, BeginDate, endDate, token, "ish");

            int expectedvalueCount = 1631;

            Assert.AreEqual(expectedvalueCount, actual, "ValueCount NCDC.RestService.TimeSeries.GetNCDCParitalResponseISD did not return the expec" +
                    "ted value.");
            Assert.Ignore("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ISDUrlByStationVariable (string, string, string, string)
        ///</summary>
        [Test]
        public void UrlByStationVariableTest()
        {
            string NCDCSiteCode = "72584523225"; // TODO: Initialize to an appropriate value

            string NCDCVariableCode = "CIG"; // TODO: Initialize to an appropriate value

            string BeginDate = "20080101"; // TODO: Initialize to an appropriate value

            string endDate = "20080131"; // TODO: Initialize to an appropriate value

            string expected = "http://www7.ncdc.noaa.gov/rest/services/values/isd/72584523225/CIG/20080101/20080131/";
            string actual;

            actual = NCDC.RestService.v1.TimeSeries.UrlByStationVariable(NCDCSiteCode, NCDCVariableCode, BeginDate, endDate, "isd");

            Assert.AreEqual(expected, actual, "NCDC.RestService.TimeSeries.UrlByStationVariable did not return the expecte" +
                    "d value.");
            //Assert.Ignore("Verify the correctness of this test method.");
        }


    }


}
