using Solarsplash_Dataviewer.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Solarsplash_Dataviewer.Models;
using System.Linq;
using Solarsplash_Dataviewer.Models.RunElements;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

namespace Solarsplash_Dataviewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for POST_DataControllerTest and is intended
    ///to contain all POST_DataControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class POST_DataControllerTest
    {
        private SolarsplashEntities db = new SolarsplashEntities();

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
        ///A test for addRunElementToDB
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Solarsplash Dataviewer.dll")]
        public void addRunElementToDBTest()
        {
            string name = "sampleName";

            RunData sampleRun=new RunData();
            sampleRun.Name=name;
            sampleRun.Runs = new System.Collections.Generic.List<RunElement>();
            sampleRun.Runs.Add(RunElement_Factory.get(0, "1,3,4".Split(',').ToList()));
            sampleRun.DataLabels = new System.Collections.Generic.List<DataLabel>();
            sampleRun.DataLabels.AddRange(DataLabel.MakeRange("first,second,third".Split(',').ToList()));
            db.RunData.Add(sampleRun);
            db.SaveChanges();
            
            POST_DataController_Accessor target = new POST_DataController_Accessor();
            RunElement run = RunElement_Factory.get(2, "23,2,43".Split(',').ToList());
            target.addRunElementToDB(run, name);

            RunData rundata = getFullRunDataObject(name);

            Assert.AreEqual(2, rundata.Runs[1].Number=2);

            //remove object from database for next test
            int runID=rundata.id;
            ObjectContext oc = ((IObjectContextAdapter)db).ObjectContext;
            oc.DeleteObject(rundata);
            db.SaveChanges();
            Assert.IsNull(db.RunData.Find(runID));
            Assert.IsNull(getFullRunDataObject(name));
        }

        /// <summary>
        ///A test for createRunDataInDB_if_needed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Solarsplash Dataviewer.dll")]
        public void createRunDataInDB_if_neededTest()
        {
            POST_DataController_Accessor target = new POST_DataController_Accessor();

            // test need to insert into database
            string runName = "sampleName";
            deleteRunDataObject(runName);   //clear out database incase there is an entry left over from something
            bool expected = true;
            bool actual;
            actual = target.createRunDataInDB_if_needed(runName);
            Assert.AreEqual(expected, actual);
            
            // test RunData table alread in database
            actual = target.createRunDataInDB_if_needed(runName);
            expected = false;
            Assert.AreEqual(expected, actual);

            //remove object from database for next test
            int runID = deleteRunDataObject(runName);
            Assert.IsNull(db.RunData.Find(runID));
        }

        private int deleteRunDataObject(string Name)
        {
            RunData rundata = getFullRunDataObject(Name);
            int runID = rundata.id;
            ObjectContext oc = ((IObjectContextAdapter)db).ObjectContext;
            oc.DeleteObject(rundata);
            db.SaveChanges();
            Assert.IsNull(db.RunData.Find(runID));
            return runID;
        }

        private RunData getFullRunDataObject(string Name)
        {
            return (from RunData in db.RunData.Include("Runs").Include("DataLabels")
                where RunData.Name == Name
                select RunData).First();
        }
    }
}
