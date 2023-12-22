using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Steps
{
    [TestFixture]
    public class Steps
    {
        protected IWebDriver driver;

        [SetUp]
        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }
    }
}