using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WebDriverHomework
{
    [TestClass]
    public class EditCompanyInProfile : BaseWebDriverTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            this.Browser = new ChromeDriver(@"c:\users\kirilt\documents\visual studio 2013\Projects\WebDriverHomework\packages\WebDriverChromeDriver.2.8\tools\");
            this.BaseUrl = @"http://www.telerik.com/";
            this.Wait = new WebDriverWait(this.Browser, TimeSpan.FromSeconds(10));
            this.TimeOut = 10;

            this.Browser.Navigate().GoToUrl(this.BaseUrl);
            this.CurrentElement = this.GetElement((By.Id("hlYourAccount")));
            this.CurrentElement.Click();
            this.CurrentElement = this.GetElement((By.Id("username")));
            this.CurrentElement.Clear();
            this.CurrentElement.SendKeys("a4501686@trbvm.com");
            this.CurrentElement = this.GetElement((By.Id("password")));
            this.CurrentElement.Clear();
            this.CurrentElement.SendKeys("12345");
            this.CurrentElement = this.GetElement((By.Id("RememberMe")));
            this.CurrentElement.Click();
            this.CurrentElement = this.GetElement((By.Id("LoginButton")));
            this.CurrentElement.Click();
            this.WaitForElementPresent(By.CssSelector("span.telerik-hi-user-name.js-telerik-user-first-name"));
            this.CurrentElement = this.GetElement((By.LinkText("Profile")));
            this.CurrentElement.Click();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                this.Browser.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        [TestMethod]
        public void EditProfileWithoutCompanyName()
        {
            this.CurrentElement = this.GetElement((By.Id("ctl00_ctl00_GeneralBox_YourAccountNavigationArea_ctl00_hlEditProfile")));
            this.CurrentElement.Click();
            this.CurrentElement = this.GetElement((By.Name("ctl00$ctl00$GeneralBox$Content$usercontrols_public_unitedaccount_client_editprofile_ascx1$scetbCompanyName$tbSanitized")));          
            this.CurrentElement.Clear();
            this.CurrentElement = this.GetElement(By.Id("ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_scetbCompanyName_rfvSanitizedControl"));
            Assert.AreEqual(this.CurrentElement.Text, "Company name cannot be empty");
        }

        [TestMethod]
        public void EditProfileCompanyName()
        {
            this.CurrentElement = this.GetElement((By.Id("ctl00_ctl00_GeneralBox_YourAccountNavigationArea_ctl00_hlEditProfile")));
            this.CurrentElement.Click();
            this.CurrentElement = this.GetElement((By.Name("ctl00$ctl00$GeneralBox$Content$usercontrols_public_unitedaccount_client_editprofile_ascx1$scetbCompanyName$tbSanitized")));
            this.CurrentElement.Clear();
            string companyName = this.GetRandomString(3, 15);
            this.CurrentElement.SendKeys(companyName);
            this.CurrentElement = this.GetElement((By.Id("ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_lbUpdate")));
            this.CurrentElement.Click();
            this.WaitForElementPresent(By.Id("ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_panelSuccess"));
            Assert.AreEqual(this.GetElement(By.Id("ctl00_ctl00_GeneralBox_Content_usercontrols_public_unitedaccount_client_editprofile_ascx1_panelSuccess")).Text, "Profile successfully updated.");
        }
    }
}
