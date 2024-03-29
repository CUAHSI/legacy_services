﻿// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using NCDC.RestService.v1;
using NUnit.Framework;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace ASOSRestTest
{
    /// <summary>
    ///This is a test class for NCDC.RestService.Sites and is intended
    ///to contain all NCDC.RestService.Sites Unit Tests
    ///</summary>
    [TestFixture]
    public class SitesTest
    {





        /// <summary>
        ///A test for SiteObject (XmlReader) using XML example
        ///</summary>
        [Test()]
        public void SiteObjectXMLFormatTest()
        {
            Stream file = File.OpenRead("siteFile_200807.xml");

            XmlReader xmlReader = XmlReader.Create(file);

            System.Collections.Generic.List<NCDC.RestService.v1.SiteInfoNCDC> expected = null;
            System.Collections.Generic.List<NCDC.RestService.v1.SiteInfoNCDC> actual;


            actual = NCDC.RestService.v1.Sites.SiteObject(xmlReader,"0");

            Assert.AreEqual(expected, actual, "NCDC.RestService.Sites.SiteObject did not return the expected value.");
        }

        /// <summary>
        ///A test for SiteObject (XmlReader)
        /// using WaterML
        ///</summary>
        [Test()]
        public void SiteObjectWaterMLFormatISDTest()
        {
            Stream file = File.OpenRead("NDCD_isd_sites.xml");

            XmlReader xmlReader = XmlReader.Create(file);

            System.Collections.Generic.List<NCDC.RestService.v1.SiteInfoNCDC> expected = null;
            System.Collections.Generic.List<NCDC.RestService.v1.SiteInfoNCDC> actual;


            actual = NCDC.RestService.v1.Sites.SiteObject(xmlReader, "0");

            Assert.AreEqual(expected, actual, "NCDC.RestService.Sites.SiteObject did not return the expected value.");
        }

        /// <summary>
        ///A test for SiteObject (XmlReader)
        /// using WaterML
        ///</summary>
        [Test()]
        public void SiteObjectWaterMLFormatTest()
        {
            Stream file = File.OpenRead("sites_WaterMLTest.xml");

            XmlReader xmlReader = XmlReader.Create(file);

            System.Collections.Generic.List<NCDC.RestService.v1.SiteInfoNCDC> expected = null;
            System.Collections.Generic.List<NCDC.RestService.v1.SiteInfoNCDC> actual;


            actual = NCDC.RestService.v1.Sites.SiteObject(xmlReader, "0");

            Assert.AreEqual(2, actual.Count, "NCDC.RestService.Sites.SiteObject did not return the expected value.");
            Assert.AreEqual("0",actual[0].DatasetID, "NCDC.RestService.Sites.SiteObject did not return the expected value.");
            Assert.IsNotNull(actual[0].StationID, "NCDC.RestService.Sites.SiteObject did not return the expected value.");
            Assert.IsNotNull(actual[0].SiteName, "NCDC.RestService.Sites.SiteObject did not return the expected value.");
            Assert.IsNotNull(actual[0].Latitude, "NCDC.RestService.Sites.SiteObject did not return the expected value.");
    
        }

        /// <summary>
        ///A test for SiteObject (XmlReader)
        /// using WaterML
        ///</summary>
        [Test()]
        public void SiteObjectWaterMLBigFormatTest()
        {
            Stream file = File.OpenRead("ncdc_isd_waterml_200807.xml");

            XmlReader xmlReader = XmlReader.Create(file);

            System.Collections.Generic.List<NCDC.RestService.v1.SiteInfoNCDC> expected = null;
            System.Collections.Generic.List<NCDC.RestService.v1.SiteInfoNCDC> actual;


            actual = NCDC.RestService.v1.Sites.SiteObject(xmlReader, "0");

            Assert.AreEqual(expected, actual, "NCDC.RestService.Sites.SiteObject did not return the expected value.");
        }

    }


    /// <summary>
    ///This is a test class for NCDC.RestService.SiteInfoNCDC and is intended
    ///to contain all NCDC.RestService.SiteInfoNCDC Unit Tests
    ///</summary>
    [TestFixture]
    public class SiteInfoNCDCTest
    {


   
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for BeginDate
        ///</summary>
        [Test]
        public void BeginDateTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            DateTime val = new DateTime(); // TODO: Assign to an appropriate value for the property

            target.BeginDate = val;


            Assert.AreEqual(val, target.BeginDate, "NCDC.RestService.SiteInfoNCDC.BeginDate was not set correctly.");
            Assert.Ignore("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DatasetID
        ///</summary>
        [Test]
        public void DatasetIDTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            string val = null; // TODO: Assign to an appropriate value for the property

            target.DatasetID = val;


            Assert.AreEqual(val, target.DatasetID, "NCDC.RestService.SiteInfoNCDC.DatasetID was not set correctly.");
            Assert.Ignore("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DateTimeFromYearMonth (string)
        ///</summary>

        [Test]
        public void DateTimeFromYearMonthTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            ASOSRestTest.NCDC_RestService_SiteInfoNCDCAccessor accessor = new ASOSRestTest.NCDC_RestService_SiteInfoNCDCAccessor(target);

            string YYYYmm = null; // TODO: Initialize to an appropriate value

            DateTime expected = new DateTime();
            DateTime actual;

            actual = accessor.DateTimeFromYearMonth(YYYYmm);

            Assert.AreEqual(expected, actual, "NCDC.RestService.SiteInfoNCDC.DateTimeFromYearMonth did not return the expected v" +
                    "alue.");
            Assert.Ignore("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Elevation
        ///</summary>
        [Test]
        public void ElevationTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            float val = 0; // TODO: Assign to an appropriate value for the property

            target.Elevation = val;


            Assert.AreEqual(val, target.Elevation, "NCDC.RestService.SiteInfoNCDC.Elevation was not set correctly.");
            Assert.Ignore("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EndDate
        ///</summary>
        [Test]
        public void EndDateTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            DateTime val = new DateTime(); // TODO: Assign to an appropriate value for the property

            target.EndDate = val;


            Assert.AreEqual(val, target.EndDate, "NCDC.RestService.SiteInfoNCDC.EndDate was not set correctly.");
            Assert.Ignore("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Latitude
        ///</summary>
        [Test]
        public void LatitudeTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            double val = 90.0; // TODO: Assign to an appropriate value for the property

            target.Latitude = val;


            Assert.AreEqual(val, target.Latitude, "NCDC.RestService.SiteInfoNCDC.Latitude was not set correctly.");
            Assert.Ignore("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Longitude
        ///</summary>
        [Test]
        public void LongitudeTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            double val = -50.0; // TODO: Assign to an appropriate value for the property

            target.Longitude = val;


            Assert.AreEqual(val, target.Longitude, "NCDC.RestService.SiteInfoNCDC.Longitude was not set correctly.");
            Assert.Ignore("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RegionAbbreviation
        ///</summary>
        [Test]
        public void RegionAbbreviationTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            string val = null; // TODO: Assign to an appropriate value for the property

            target.RegionAbbreviation = val;


            Assert.AreEqual(val, target.RegionAbbreviation, "NCDC.RestService.SiteInfoNCDC.RegionAbbreviation was not set correctly.");
            Assert.Ignore("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetBeginDate (string)
        ///</summary>
        [Test]
        public void SetBeginDateTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            string DateYYYYmm = null; // TODO: Initialize to an appropriate value

            target.SetBeginDate(DateYYYYmm);

            Assert.Ignore("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetElevation (string)
        ///</summary>
        [Test]
        public void SetElevationTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            string elevation = null; // TODO: Initialize to an appropriate value

            target.SetElevation(elevation);

            Assert.Ignore("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetEndDate (string)
        ///</summary>
        [Test]
        public void SetEndDateTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            string DateYYYYmm = null; // TODO: Initialize to an appropriate value

            target.SetEndDate(DateYYYYmm);

            Assert.Ignore("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetLatitude (string)
        ///</summary>
        [Test]
        public void SetLatitudeTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            string LatString = null; // TODO: Initialize to an appropriate value

            target.SetLatitude(LatString);

            Assert.Ignore("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetLongitude (string)
        ///</summary>
        [Test]
        public void SetLongitudeTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            string LonString = null; // TODO: Initialize to an appropriate value

            target.SetLongitude(LonString);

            Assert.Ignore("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SiteName
        ///</summary>
        [Test]
        public void SiteNameTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            string val = null; // TODO: Assign to an appropriate value for the property

            target.SiteName = val;


            Assert.AreEqual(val, target.SiteName, "NCDC.RestService.SiteInfoNCDC.SiteName was not set correctly.");
            Assert.Ignore("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StationID
        ///</summary>
        [Test]
        public void StationIDTest()
        {
            SiteInfoNCDC target = new SiteInfoNCDC();

            string val = null; // TODO: Assign to an appropriate value for the property

            target.StationID = val;


            Assert.AreEqual(val, target.StationID, "NCDC.RestService.SiteInfoNCDC.StationID was not set correctly.");
            Assert.Ignore("Verify the correctness of this test method.");
        }

    }
}
