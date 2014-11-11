using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebDriverHomework
{
    public class BaseWebDriverTest
    {
        

        public void TestInit(IWebDriver driver, string baseUrl, int timeOut)
        {
            this.Browser = driver;
            this.BaseUrl = baseUrl;
            this.Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            this.TimeOut = timeOut;
        }

        public IWebDriver Browser { get; set; }

        public StringBuilder VerificationErrors { get; set; }

        public string BaseUrl { get; set; }

        public WebDriverWait Wait { get; set; }

        public IWebElement CurrentElement { get; set; }

        public int TimeOut { get; set; }

        public IWebElement GetElement(By by)
        {
            IWebElement result = null;
            try
            {
                result = this.Wait.Until(x => x.FindElement(by));
            }
            catch (TimeoutException ex)
            {
                throw new Exception();
            }

            return result;
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                this.Browser.FindElement(by);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void WaitForElementPresent(By by)
        {
            this.GetElement(by);
        }

        public void WaitForElementNotPresent(By by)
        {
            try
            {
                this.GetElement(by);
                throw new Exception() ;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void WaitForChecked(By by)
        {
            IWebElement currentElement = this.GetElement(by);
            bool isSelected = currentElement.Selected;

            if (!isSelected)
            {
                throw new Exception();
            }
        }

        public void WaitForNotChecked(By by)
        {
            IWebElement currentElement = this.GetElement(by);
            bool isSelected = currentElement.Selected;

            if (!isSelected)
            {
                throw new Exception();
            }
        }

        public void WaitForTextPresent(string textToFind, bool shouldWait = true)
        {
            for (int second = 0; ; second++)
            {
                if (second >= this.TimeOut)
                {
                    throw new Exception();
                }
                try
                {
                    string bodyInnerHtml = this.Browser.FindElement(By.TagName("body")).Text;
                    bool isContainingText = bodyInnerHtml.Contains(textToFind);
                    Assert.AreEqual(shouldWait, isContainingText);

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Thread.Sleep(1000);
            }
        }

        public void WaitForText(By by, string textToFind)
        {
            IWebElement currentElement = this.GetElement(by);
            string elementText = currentElement.Text;

            if (!textToFind.Equals(elementText))
            {
                throw new Exception();
            }
        }

        public void WaitForTextNotPresent(string textToFind)
        {
            this.WaitForTextPresent(textToFind, false);
        }

        public string GetRandomString(int min, int max)
        {
            string allLeters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            int length = random.Next(min, max + 1);

            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = allLeters[random.Next(0, allLeters.Length)];
            }

            return new string(result);
        }
    }
}
