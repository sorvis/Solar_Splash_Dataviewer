﻿using Solarsplash_Dataviewer.Controllers.Analysis_Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Solarsplash_Dataviewer.Models.DataAnalysis;
using System.Collections.Generic;
using Solarsplash_Dataviewer.Controllers.Analysis_Factory.AnalysisCalculation;
using Solarsplash_Dataviewer.Models;
using Solarsplash_Dataviewer.Models.RunElements;

namespace Solarsplash_Dataviewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for build_analyzersTest and is intended
    ///to contain all build_analyzersTest Unit Tests
    ///</summary>
    [TestClass()]
    public class build_analyzersTest
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
        public void factoryTest_adding_averager_to_IAnalyzer()
        {
            IAnalyzer analyzer = new IAnalyzer_dummy_class(Averager.Type_Name, "something random");
            List<float> data_float = new List<float> { 0.3F, 34.2F, 23.4F };
            IAnalyzer actual;
            actual = build_analyzers_Accessor.factory(analyzer, data_float);
            Assert.IsTrue(actual is Averager);
            Assert.AreEqual(Averager.Type_Name, actual.Name);
        }

        [TestMethod()]
        public void buildTest_build_objects_into_RunData_object()
        {
            RunData run = new RunData();
            run.DataLabels.Add(new DataLabel("test"));
            run.DataLabels[0].Analyzers.Add(new Analyzer(new IAnalyzer_dummy_class(Averager.Type_Name, "somthing random")));
            run.Runs.Add(new RunElement(new List<float> { 0.3F}, 0));
            run.Runs.Add(new RunElement(new List<float> { 2.3F}, 1));
            run.Runs.Add(new RunElement(new List<float> { 3.3F}, 2));

            RunData actual = build_analyzers.build(run);
            Assert.IsTrue(actual.DataLabels[0].Analyzers[0].get_IAnalyzer() is Averager);
        }
    }
    public class IAnalyzer_dummy_class:IAnalyzer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IAnalyzer_dummy_class(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
    }
}
