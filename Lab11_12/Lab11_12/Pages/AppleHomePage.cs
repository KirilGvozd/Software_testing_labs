using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Threading;
using Lab11_12.Pages;


namespace Lab10
{
    public class AppleHomePage
    {
        public readonly IWebDriver driver;

        public AppleHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public AppleHomePage OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://www.apple.com/");
            return this;
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

        public AppleHomePage OpenBagMenu()
        {
            IWebElement cartButton = driver.FindElement(By.XPath("/html/body/div[1]/nav/div/ul/li[4]/div[1]/a"));
            cartButton.Click();
            Thread.Sleep(2000);
            return this;
        }

        public CartPage OpenCartPage()
        {
            IWebElement reviewBagButton = driver.FindElement(By.XPath("/html/body/div[1]/nav/div/ul/li[4]/div[2]/div/div/div/div[1]/div[2]/a"));
            reviewBagButton.Click();
            return new CartPage(driver);
        }
    }
}
