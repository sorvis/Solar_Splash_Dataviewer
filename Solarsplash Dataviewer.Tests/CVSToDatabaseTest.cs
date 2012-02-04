using Solarsplash_Dataviewer.Controllers.Send_To_Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Solarsplash_Dataviewer.Models;
using System.IO;
using System.Collections.Generic;

namespace Solarsplash_Dataviewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CVSToDatabaseTest and is intended
    ///to contain all CVSToDatabaseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CVSToDatabaseTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for readFileToDB
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("c:\\users\\steven\\documents\\visual studio 2010\\Projects\\Solarsplash Dataviewer\\Solarsplash Dataviewer", "/")]
        //[UrlToTest("http://localhost:56216/")]
        [DeploymentItem("Solarsplash Dataviewer.dll")]
        public void readFileToDBTest()
        {
            RunData run = new RunData();
            Stream file = new FileStream("C:\\Users\\Steven\\Documents\\Visual Studio 2010\\Projects\\Solarsplash Dataviewer\\Solarsplash Dataviewer.Tests\\test.csv", FileMode.Open, FileAccess.Read);
            run.Runs = CSVToData_Accessor.readFileToDB(file);
            Assert.IsNotNull(run);
            Assert.AreEqual("svol", run.Runs[0].DataLabels[0]);
            Assert.AreEqual(Convert.ToSingle("23.42"), run.Runs[0].Data[0]);
        }
    }
}
