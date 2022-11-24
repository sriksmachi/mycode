using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SeleniumSample_NUNIT
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            driver = GetRemoteChromeDriver();
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
        }

        public IWebDriver GetRemoteChromeDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(
                "start-maximized",
                "enable-automation",
                "--no-sandbox", //this is the relevant other arguments came from solving other issues
                "--ignore-certificate-errors");
            var capability = chromeOptions.ToCapabilities();

            SetRemoteWebDriver(capability);
            SetImplicitlyWait();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return driver;
        }

        private void SetImplicitlyWait()
        {
            driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
        }


        private void SetRemoteWebDriver(ICapabilities capabilities)
        {
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities, TimeSpan.FromMinutes(3));
        }

        [Test][Parallelizable]
        public void Test1()
        {
            Assert.Pass();
        }


        /// <summary>
        /// The driver
        /// </summary>
        IWebDriver driver;


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [Test][Parallelizable]
        public void TestMethod1()
        {
            SearchTest("icici");
        }

        /// <summary>
        /// Tests the method2.
        /// </summary>
        [Test][Parallelizable]
        public void TestMethod2()
        {
            SearchTest("hdfc");
        }

        /// <summary>
        /// Tests the method3.
        /// </summary>
        [Test][Parallelizable]
        public void TestMethod3()
        {
            SearchTest("motorola");
        }

        /// <summary>
        /// Tests the method4.
        /// </summary>
        [Test][Parallelizable]
        public void TestMethod4()
        {
            SearchTest("dell");
        }

        /// <summary>
        /// Tests the method5.
        /// </summary>
        [Test][Parallelizable]
        public void TestMethod5()
        {
            SearchTest("youtube");
        }

        /// <summary>
        /// Tests the method6.
        /// </summary>
        [Test][Parallelizable]
        public void TestMethod6()
        {
            SearchTest("facebook");
        }

        /// <summary>
        /// Tests the method7.
        /// </summary>
        [Test][Parallelizable]
        public void TestMethod7()
        {
            SearchTest("linkedin");
        }

        /// <summary>
        /// Tests the method8.
        /// </summary>
        [Test][Parallelizable]
        public void TestMethod8()
        {
            SearchTest("google");
        }

        /// <summary>
        /// Tests the method9.
        /// </summary>
        [Test][Parallelizable]
        public void TestMethod9()
        {
            SearchTest("microsoft");
        }

        /// <summary>
        /// Tests the method10.
        /// </summary>
        [Test][Parallelizable]
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
            //*[@id="rso"]/div[1]/div/div/div/div/div/div/div/div[1]/a
            //string text = driver.FindElement(By.XPath("//*[@id='rso']/div[1]/div/div/div/div/div/div/div/div[1]/a/h3")).Text;
            //Assert.IsTrue(text.ToUpper().Contains(queryString.ToUpper()));
            //driver.FindElement(By.XPath("//*[@id='rso']/div/div/div/div/div/div/div/div/a")).Click();
            //Assert.IsTrue(driver.Title.ToUpper().Contains(queryString.ToUpper()));
            //Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            //string screenshot = ss.AsBase64EncodedString;
            //byte[] screenshotAsByteArray = ss.AsByteArray;
            //ss.SaveAsFile("ss_" +  queryString + ".png", ScreenshotImageFormat.Png);
            driver.Quit();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}

