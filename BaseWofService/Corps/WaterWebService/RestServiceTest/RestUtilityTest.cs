using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using NUnit.Framework;
using RestServiceClient;

namespace RestServiceTest
{
    [TestFixture]
    public class RestUtilityTest
    {
        [Test]
        [ExpectedException(typeof(WebException))]
        public void GetHTTPFileTest()
        {
            string strURL = "http://localhost";
            int SecondsToRespond = 10;

            StreamReader s = Utility.GetHTTPFile(strURL,
                                   SecondsToRespond);
            
            Assert.IsNotNull(s);
        }
        [Test]
        public void GetHTTPFileTest2()
        {
            string strURL = "http://www2.mvr.usace.army.mil/watercontrol/webserviceWaterML.cfm?Meth=getSiteInfo&SID=01080";
            int SecondsToRespond = 10;

            StreamReader s = Utility.GetHTTPFile(strURL,
                                   SecondsToRespond);

            Assert.IsNotNull(s);
        }
    }
}
