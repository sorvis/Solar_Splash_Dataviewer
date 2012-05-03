using Solarsplash_Dataviewer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Data.Entity;
using Solarsplash_Dataviewer.Models.RunElements;
using System.Collections.Generic;
using Solarsplash_Dataviewer.Models.DataAnalysis;

namespace Solarsplash_Dataviewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for SolarsplashEntitiesTest and is intended
    ///to contain all SolarsplashEntitiesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SolarsplashEntitiesTest
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
        public void Test_deletion_of_DataLabels_when_RunData_is_deleted()
        {
            SolarsplashEntities db = new SolarsplashEntities();
            EF_RunDataRepository target = new EF_RunDataRepository(db, true);

            string name = "this should be deleted";
            save_RunData_to_db(make_dummy_RunData_object(name), db);
            int id = target.Get_RunData_object(name).DataLabels[0].id_DataLabel;

            Assert.IsNotNull(db.RunData.Find(id));
            target.Delete_RunData_object(name);    //delete the RunData object
            Assert.IsNull(db.RunData.Find(id));
        }
        [TestMethod()]
        [DeploymentItem("Solarsplash Dataviewer.dll")]
        public void Test_deletion_of_Analyzer_when_RunData_is_deleted()
        {
            SolarsplashEntities db = new SolarsplashEntities();
            EF_RunDataRepository target = new EF_RunDataRepository(db, true);

            string name = "this should be deleted";
            save_RunData_to_db(make_dummy_RunData_object(name), db);
            int id = target.Get_RunData_object(name).DataLabels[0].Analyzers[0].id_analyzer;

            Assert.IsNotNull(db.Analyzer.Find(id));
            target.Delete_RunData_object(name);    //delete the RunData object
            Assert.IsNull(db.Analyzer.Find(id));
        }
        [TestMethod()]
        [DeploymentItem("Solarsplash Dataviewer.dll")]
        public void Test_deletion_of_RunElement_when_RunData_is_deleted()
        {
            SolarsplashEntities db = new SolarsplashEntities();
            EF_RunDataRepository target = new EF_RunDataRepository(db, true);

            string name = "this should be deleted";
            save_RunData_to_db(make_dummy_RunData_object(name), db);
            int id = target.Get_RunData_object(name).Runs[0].id_RunElement;

            Assert.IsNotNull(db.RunElement.Find(id));
            target.Delete_RunData_object(name);    //delete the RunData object
            Assert.IsNull(db.RunElement.Find(id));
        }
        [TestMethod()]
        [DeploymentItem("Solarsplash Dataviewer.dll")]
        public void Test_deletion_of_Data_when_RunData_is_deleted()
        {
            SolarsplashEntities db = new SolarsplashEntities();
            EF_RunDataRepository target = new EF_RunDataRepository(db, true );

            string name = "this should be deleted";
            save_RunData_to_db(make_dummy_RunData_object(name), db);
            int id = target.Get_RunData_object(name).Runs[0].Data[0].id_Data;

            Assert.IsNotNull(db.Data.Find(id));
            target.Delete_RunData_object(name);    //delete the RunData object
            Assert.IsNull(db.Data.Find(id));
        }

        private void save_RunData_to_db(RunData data, SolarsplashEntities db)
        {
            db.RunData.Add(data);
            db.SaveChanges();
        }
        private RunData make_dummy_RunData_object(string name)
        {
            RunData runData = new RunData(name);
            DataLabel dataLabel = new DataLabel(name);
            Analyzer analyzer = new Analyzer(new IAnalyzer_dummy_class(name, "decs"));
            RunElement runElement = new RunElement(new List<float>() { 34.2f, 23.2f }, 3);  // auto adds data object

            runData.Runs.Add(runElement);
            dataLabel.Analyzers.Add(analyzer);
            runData.DataLabels.Add(dataLabel);

            return runData;
        }
    }
}
