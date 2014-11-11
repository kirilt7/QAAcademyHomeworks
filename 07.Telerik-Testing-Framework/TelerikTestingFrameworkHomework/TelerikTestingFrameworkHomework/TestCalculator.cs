using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.TestAttributes;
using ArtOfTest.WebAii.TestTemplates;
using ArtOfTest.WebAii.Win32.Dialogs;

using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TelerikTestingFrameworkHomework
{
    /// <summary>
    /// Summary description for TelerikVSUnitTest1
    /// </summary>
    [TestClass]
    public class TestKendo : BaseTest
    {

        #region [Setup / TearDown]

        private TestContext testContextInstance = null;
        /// <summary>
        ///Gets or sets the VS test context which provides
        ///information about and functionality for the
        ///current test run.
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


        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
        }


        // Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            #region WebAii Initialization

            // Initializes WebAii manager to be used by the test case.
            // If a WebAii configuration section exists, settings will be
            // loaded from it. Otherwise, will create a default settings
            // object with system defaults.
            //
            // Note: We are passing in a delegate to the VisualStudio
            // testContext.WriteLine() method in addition to the Visual Studio
            // TestLogs directory as our log location. This way any logging
            // done from WebAii (i.e. Manager.Log.WriteLine()) is
            // automatically logged to the VisualStudio test log and
            // the WebAii log file is placed in the same location as VS logs.
            //
            // If you do not care about unifying the log, then you can simply
            // initialize the test by calling Initialize() with no parameters;
            // that will cause the log location to be picked up from the config
            // file if it exists or will use the default system settings (C:\WebAiiLog\)
            // You can also use Initialize(LogLocation) to set a specific log
            // location for this test.

            // Pass in 'true' to recycle the browser between test methods
            Initialize(false, this.TestContext.TestLogsDir, new TestContextWriteLine(this.TestContext.WriteLine));

            // If you need to override any other settings coming from the
            // config section you can comment the 'Initialize' line above and instead
            // use the following:

            /*

            // This will get a new Settings object. If a configuration
            // section exists, then settings from that section will be
            // loaded

            Settings settings = GetSettings();

            // Override the settings you want. For example:
            settings.Web.DefaultBrowser = BrowserType.FireFox;

            // Now call Initialize again with your updated settings object
            Initialize(settings, new TestContextWriteLine(this.TestContext.WriteLine));

            */

            // Set the current test method. This is needed for WebAii to discover
            // its custom TestAttributes set on methods and classes.
            // This method should always exist in [TestInitialize()] method.
            SetTestMethod(this, (string)TestContext.Properties["TestName"]);

            #endregion

            //
            // Place any additional initialization here
            //

        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {

            //
            // Place any additional cleanup here
            //

            #region WebAii CleanUp

            // Shuts down WebAii manager and closes all browsers currently running
            // after each test. This call is ignored if recycleBrowser is set
            this.CleanUp();

            #endregion
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            // This will shut down all browsers if
            // recycleBrowser is turned on. Else
            // will do nothing.
            ShutDown();
        }

        #endregion

        [TestMethod]
        public void TestButtonsExisting()
        {
            Manager.Settings.ExecutionDelay = 200;
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");

            var buttonOne = Find.ByXPath<HtmlInputButton>("//*[@id='calc']/tbody/tr[5]/td[1]/input");
            var buttonTwo = Find.ByXPath<HtmlInputButton>("//*[@id='calc']/tbody/tr[5]/td[2]/input");
            var buttonThree = Find.ByXPath<HtmlInputButton>("//*[@id='calc']/tbody/tr[5]/td[3]/input");

            Assert.AreEqual("1", buttonOne.Value);
            Assert.AreEqual(true, buttonOne.IsEnabled);

            Assert.AreEqual("2", buttonTwo.Value);
            Assert.AreEqual(true, buttonTwo.IsEnabled);

            Assert.AreEqual("3", buttonThree.Value);
            Assert.AreEqual(true, buttonThree.IsEnabled);
        }

        [TestMethod]
        public void TestButtonsCount()
        {
            Manager.Settings.ExecutionDelay = 200;
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");

            var allButtons = Find.AllByAttributes("type=button");
            var a = allButtons.Count;
            Assert.AreEqual(20, allButtons.Count);
        }

        [TestMethod]
        public void TestSumming()
        {
            Manager.Settings.ExecutionDelay = 200;
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");

            var buttonOne = Find.ByXPath<HtmlInputButton>("//*[@id='calc']/tbody/tr[5]/td[1]/input");
            var buttonPlus = Find.ByXPath<HtmlInputButton>("//*[@id='calc']/tbody/tr[2]/td[4]/input");
            var buttonEqual = Find.ByXPath<HtmlInputButton>("//*[@id='calc']/tbody/tr[6]/td[4]/input");

            buttonOne.Click();
            buttonPlus.Click();
            buttonOne.Click();
            buttonEqual.Click();

            var result = Find.ById<HtmlInputText>("calc_result");

            Assert.AreEqual("2", result.Text); 
        }
    }
}
