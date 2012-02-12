using Solarsplash_Dataviewer.Controllers.AnalysisCalculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace Solarsplash_Dataviewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for AveragerTest and is intended
    ///to contain all AveragerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AveragerTest
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
        /// returns average of all data points
        /// </summary>
        [TestMethod()]
        public void getTotalAverageTest()
        {
            List<float> data = new List<float>();
            data.Add(23.42F);
            data.Add(33.35F);
            data.Add(234F);

            Averager target = new Averager(data);
            float expected = 96.92333333333333F;
            float actual;
            actual = target.getTotalAverage();
            Assert.AreEqual(expected, actual);
        }
    }
}
