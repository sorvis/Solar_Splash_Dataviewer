using Solarsplash_Dataviewer.Controllers.Send_To_Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.IO;
using System.Collections.Generic;
using Solarsplash_Dataviewer.Models;

namespace Solarsplash_Dataviewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CSVToDataTest and is intended
    ///to contain all CSVToDataTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CSVToDataTest
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



        [TestMethod()]
        [DeploymentItem("Solarsplash Dataviewer.dll")]
        public void readDataLabelsTest()
        {
            Stream file = new FileStream("../../test.csv", FileMode.Open, FileAccess.Read);
            string[] expected = { "svol", "test", "something" };
            List<string> actual;
            actual = CSVToData_Accessor.readDataLabels(file);
            CollectionAssert.AreEquivalent(expected, actual);
        }


        [TestMethod()]
        [DeploymentItem("Solarsplash Dataviewer.dll")]
        public void readFileToDBTest()
        {
            Stream file = new FileStream("../../test.csv", FileMode.Open, FileAccess.Read);
            List<RunElement> actual = CSVToData_Accessor.readFileToDB(file);
            Assert.AreEqual(Convert.ToSingle("23.42"), actual[0].Data[0].Value);
        }
    }
}
