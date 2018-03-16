using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumGridSample
{
    [TestClass]
    public  class UITests
    {
        /// <summary>
        /// The driver
        /// </summary>
        IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="UITests"/> class.
        /// </summary>
        public UITests()
        {
            driver = new ChromeDriver(@"C:\Users\vism\Downloads\chromedriver_win32\");
// ChromeOptions chromeOptions = new ChromeOptions();
// chromeOptions.AddArgument("--start-maximized");
// driver = new RemoteWebDriver(new Uri("http://52.165.22.80:4444/wd/hub"), chromeOptions.ToCapabilities());
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            SearchTest("icici");
        }

        /// <summary>
        /// Tests the method2.
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            SearchTest("hdfc");
        }

        /// <summary>
        /// Tests the method3.
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            SearchTest("motorola");
        }

        /// <summary>
        /// Tests the method4.
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            SearchTest("dell");
        }

        /// <summary>
        /// Tests the method5.
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            SearchTest("youtube");
        }

        /// <summary>
        /// Tests the method6.
        /// </summary>
        [TestMethod]
        public void TestMethod6()
        {
            SearchTest("facebook");
        }

        /// <summary>
        /// Tests the method7.
        /// </summary>
        [TestMethod]
        public void TestMethod7()
        {
            SearchTest("linkedin");
        }

        /// <summary>
        /// Tests the method8.
        /// </summary>
        [TestMethod]
        public void TestMethod8()
        {
            SearchTest("google");
        }

        /// <summary>
        /// Tests the method9.
        /// </summary>
        [TestMethod]
        public void TestMethod9()
        {
            SearchTest("microsoft");
        }

        /// <summary>
        /// Tests the method10.
        /// </summary>
        [TestMethod]
        public void TestMethod10()
        {
            SearchTest("amazon");
        }

        private void SearchTest(string queryString)
        {
            driver.Navigate().GoToUrl("https://www.google.co.in");
            driver.Manage().Window.Maximize();
            var query = driver.FindElement(By.Name("q"));
            query.SendKeys(queryString);
            query.Submit();
            string text = driver.FindElement(By.XPath("//*[@id='rso']/div/div/div/div/div/h3/a")).Text;
            Assert.IsTrue(text.ToUpper().Contains(queryString.ToUpper()));
            driver.FindElement(By.XPath("//*[@id='rso']/div/div/div/div/div/h3/a")).Click();
            Assert.IsTrue(driver.Title.ToUpper().Contains(queryString.ToUpper()));
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile("ss_" +  queryString + ".png", ScreenshotImageFormat.Png);
            driver.Quit();
        }
    }
}
