using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestsAzure
{
    [TestClass]
    public class SeleniumDemo : BaseTest
    {
        [TestMethod]
        public void SearchForCheese()
        {
            /*var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            using(var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions))
            {*/
                driver.Navigate().GoToUrl("http://www.google.com");
                IWebElement query = driver.FindElement(By.Name("q"));
                query.SendKeys("cheese");
                query.Submit();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));

                Assert.AreEqual(driver.Title, "cheese - Google Search111");

            //}
        }

        [DataTestMethod]
        [DataRow("cake", "cake - Google Search")]
        [DataRow("carrot", "carrot - Google Search111")]
        public void SearchForCake(string criteria, string result)
        {
            /*var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            using(var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions))
            {*/
            driver.Navigate().GoToUrl("http://www.google.com");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys(criteria);
            query.Submit();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith(criteria, StringComparison.OrdinalIgnoreCase));

            Assert.AreEqual(driver.Title, result);

            //}
        }
    }
}
