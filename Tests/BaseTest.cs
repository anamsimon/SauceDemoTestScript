using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SauceDemoTest.Setup;
using SauceDemoTest.Utils;

namespace SauceDemoTest.Tests
{
    internal class BaseTest
    {
        internal IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = Browser.GetWebDriver();
            driver.Navigate().GoToUrl(Configuration.BaseURL);
        }


        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Close();
        }
        
    }
}
