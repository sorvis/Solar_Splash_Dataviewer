using Solarsplash_Dataviewer.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using Solarsplash_Dataviewer.Tests.Models;
using System.Web;
using System.Security.Principal;
using Solarsplash_Dataviewer.Models;
using System.Web.Routing;

namespace Solarsplash_Dataviewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for POST_DataControllerTest and is intended
    ///to contain all POST_DataControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class POST_DataControllerTest
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
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void Add_data_element_from_get()
        {
            IRunDataRepository db = (IRunDataRepository)new RunDataRepository();
            POST_DataController target = GetPOST_DataController(db);
            string name = "test run";
            int number = 0;
            string data = "2.4,0.3,4,3";

            // new create
            target.Add(name, number, data);

            RunData savedObject = db.Get_RunData_object(name);
            Assert.AreEqual(name, savedObject.Name);
            Assert.AreEqual(2.4F, savedObject.Runs[0].Data[0].Value);

            //test adding to an existing object
            data = "4.0,3.0,2.0,1.0";
            number = 0;
            target.Add(name, number, data);
            savedObject = db.Get_RunData_object(name);
            Assert.AreEqual(name, savedObject.Name);
            Assert.AreEqual(2.4F, savedObject.Runs[0].Data[0].Value);
            Assert.AreEqual(3.0F, savedObject.Runs[1].Data[1].Value);
        }

        /// <summary>
        ///A test for AddRun
        ///</summary>
        [TestMethod()]
        public void AddRun_test_add_new_run_to_database()
        {
            IRunDataRepository db = (IRunDataRepository)new RunDataRepository();
            POST_DataController target = GetPOST_DataController(db);
            string name = "test run";
            string labels = "SVOL,SBOD,MRPM";
            ActionResult actual;
            actual = target.AddRun(name, labels);
            RunData savedObject = db.Get_RunData_object(name);

            // Test initial add of object
            Assert.AreEqual("SVOL", savedObject.DataLabels[0].LabelName);

            // try adding object with the same name
            labels = "SBOD,SVOL";
            target.AddRun(name, labels);
            savedObject = db.Get_RunData_object(name+"_DUP");
            Assert.AreEqual("SBOD", savedObject.DataLabels[0].LabelName);
        }

        /// <summary>
        ///A test for GetMd5Hash
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Solarsplash Dataviewer.dll")]
        public void GetMd5HashTest()
        {
            string input = "password";
            string expected = "5f4dcc3b5aa765d61d8327deb882cf99";
            string actual;
            actual = POST_DataController_Accessor.GetMd5Hash(input);
            Assert.AreEqual(expected, actual);
        }

        private RunData Get_RunData_object(string name)
        {
            RunData temp = new RunData();
            temp.Name=name;
            return temp;
        }

        private static POST_DataController GetPOST_DataController(IRunDataRepository repository)
        {
            POST_DataController controller = new POST_DataController(repository);

            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }

        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(
                     new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }
    }
}
