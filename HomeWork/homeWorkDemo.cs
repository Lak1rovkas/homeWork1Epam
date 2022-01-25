using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HomeWork
{
    public class Browser_ops
    {
        private IWebDriver webDriver;
        public void Init_Browser()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }
        public string Title
        {
            get { return webDriver.Title; }
        }
        public void Goto(string url)
        {
            webDriver.Url = url;
        }
        public void Close()
        {
            webDriver.Quit();
        }
        public IWebDriver getDriver
        {
            get { return webDriver; }
        }
    }
    class homeWorkDemo
    {
        Browser_ops brow = new Browser_ops();
        string test_url = "https://meteo.paraplan.net/en/forecast/saint-petersburg/";
        private IWebDriver driver;
        

        [SetUp]
        public void startBrowser()
        {
            brow.Init_Browser();
        }

        [Test]
        public void test()
        {
            brow.Goto(test_url);
            System.Threading.Thread.Sleep(4000);

            driver = brow.getDriver;

            IWebElement element1 = driver.FindElement(By.XPath(@"//div[@class='sub_nav-item active'][1]/span[text()='Five-day weather forecast']"));
            IWebElement element2 = driver.FindElement(By.LinkText("Skew-T log-P diagram"));
                        
            System.Threading.Thread.Sleep(2000);
            Assert.NotNull(element1);
            Assert.NotNull(element2);
        }

        [TearDown]
        public void closeBrowser()
        {
            brow.Close();
        }

    }
}



