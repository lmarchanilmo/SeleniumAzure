using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestsAzure
{
    [TestClass]
    public class BaseTest
    {
        public IWebDriver driver;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
        }
            

        [TestCleanup]
        public void teardown()
        {
            try
            {
                if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
                {
                    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                    string path = Directory.GetCurrentDirectory() + "SearchTestScreenshot.png";
                    ss.SaveAsFile(path);
                    this.TestContext.AddResultFile(path);


                }
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
            

        }
    }
}
