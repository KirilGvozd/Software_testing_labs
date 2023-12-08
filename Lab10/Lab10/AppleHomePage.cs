using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Threading;


namespace Lab10
{
    public class AppleHomePage
    {
        public readonly IWebDriver driver;

        public AppleHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://www.apple.com/");
        }

        public VisionPage GoToVisionPage()
        {
            IWebElement visionButton = driver.FindElement(By.XPath("//a[contains(text(), 'Vision')]"));
            visionButton.Click();
            return new VisionPage(driver);
        }

        public AirPodsPage GoToAirPodsPage()
        {
            IWebElement airPodsButton = driver.FindElement(By.XPath("//*[@id=\"globalnav-list\"]/li[2]/div/div/div[7]/ul/li[1]/a"));
            airPodsButton.Click();
            return new AirPodsPage(driver);
        }
    }
}
