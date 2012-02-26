using Solarsplash_Dataviewer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Solarsplash_Dataviewer.Models.RunElements;
using System.Collections.Generic;

namespace Solarsplash_Dataviewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for EF_RunDataRepositoryTest and is intended
    ///to contain all EF_RunDataRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EF_RunDataRepositoryTest
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
        ///A test for Get_RunData_object
        ///</summary>
        [TestMethod()]
        public void Get_RunData_objectTest()
        {
            SolarsplashEntities db = new SolarsplashEntities();
            EF_RunDataRepository target = new EF_RunDataRepository(db);
            string name = "this object does not exist";
            RunData expected = null;
            RunData actual;

            // test return of null object
            actual = target.Get_RunData_object(name);
            Assert.IsNull(actual);

            // test return of seeded object
            name="Get_RunData_objectTest";
            expected = new RunData();
            expected.Name = name;
            expected.Runs.Add(new RunElement(new List<float> { 2.3F, 21.2F, 3F }, 1));
            db.RunData.Add(expected);
            db.SaveChanges();
            actual = target.Get_RunData_object(name);
            Assert.AreEqual(21.2F, actual.Runs[0].Data[1].Value);
        }

        /// <summary>
        ///A test for Get_RunData_base_object
        ///</summary>
        [TestMethod()]
        public void Get_RunData_base_objectTest()
        {
            SolarsplashEntities db = new SolarsplashEntities();
            EF_RunDataRepository target = new EF_RunDataRepository(db);
            string name = "this object does not exist";
            RunData expected = null;
            RunData actual;

            // test return of null object
            actual = target.Get_RunData_base_object(name);
            Assert.IsNull(actual);

            // test return of seeded object
            name = "Get_RunData_base_objectTest";
            expected = new RunData();
            expected.Name = name;
            expected.Runs.Add(new RunElement(new List<float> { 2.3F, 21.2F, 3F }, 1));
            expected.DataLabels.AddRange(DataLabel.MakeRange(new List<string> { "SVOL", "TEST" }));
            db.RunData.Add(expected);
            db.SaveChanges();
            actual = target.Get_RunData_base_object(name);
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(0, actual.Runs.Count);
            Assert.AreEqual("TEST", actual.DataLabels[1].LabelName);
        }

        /// <summary>
        ///A test for Delete_RunData_object
        ///</summary>
        [TestMethod()]
        public void Delete_RunData_objectTest()
        {
            EF_RunDataRepository target = new EF_RunDataRepository(); // TODO: Initialize to an appropriate value
            RunData item = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Delete_RunData_object(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add_RunElement_to_RunData
        ///</summary>
        [TestMethod()]
        public void Add_RunElement_to_RunDataTest()
        {
            EF_RunDataRepository target = new EF_RunDataRepository(); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            RunElement element = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Add_RunElement_to_RunData(name, element);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add_New_Run
        ///</summary>
        [TestMethod()]
        public void Add_New_RunTest()
        {
            EF_RunDataRepository target = new EF_RunDataRepository(); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            List<DataLabel> labels = null; // TODO: Initialize to an appropriate value
            target.Add_New_Run(name, labels);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
