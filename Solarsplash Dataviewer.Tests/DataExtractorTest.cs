using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;
using Solarsplash_Dataviewer.Models;
using System.IO;
using Solarsplash_Dataviewer.Controllers.Send_To_Database;
using Solarsplash_Dataviewer.Models.RunElements;
using Solarsplash_Dataviewer.Controllers.Analysis_Factory.AnalysisCalculation;

namespace Solarsplash_Dataviewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for DataExtractorTest and is intended
    ///to contain all DataExtractorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataExtractorTest
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

        private RunData generateRunData()
        {
            Stream file = new FileStream("../../test.csv", FileMode.Open, FileAccess.Read);
            RunData runData = new RunData();
            runData.Runs = CSVToData_Accessor.readFileToDB(file);

            file = new FileStream("../../test.csv", FileMode.Open, FileAccess.Read);
            runData.DataLabels = DataLabel.MakeRange(CSVToData_Accessor.readDataLabels(file));
            return runData;
        }

        /// <summary>
        /// Test extract function which gets the range of data points of a particualar data item from a RunData Object
        /// </summary>
        [TestMethod()]
        [DeploymentItem("Solarsplash Dataviewer.dll")]
        public void extractDataTest()
        {
            DataExtractor_Accessor target = new DataExtractor_Accessor(generateRunData(), "svol");
            int dataPosition = 0;
            float[] expected = { 23.42F, 33.35F, 234F };
            List<float> actual;
            actual = target.extractData(dataPosition);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        /// <summary>
        /// Test finding the index for a given data label
        /// </summary>
        [TestMethod()]
        [DeploymentItem("Solarsplash Dataviewer.dll")]
        public void getDataPositionTest()
        {
            DataExtractor_Accessor target = new DataExtractor_Accessor(generateRunData(), "svol");
            int expected = 0;
            int actual;
            actual = target.getDataPosition();
            Assert.AreEqual(expected, actual);

            target = new DataExtractor_Accessor(generateRunData(), "something");
            expected = 2;
            actual = target.getDataPosition();
            Assert.AreEqual(expected, actual);
        }
    }
}
