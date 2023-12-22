using Lab11_12.Pages;
using OpenQA.Selenium;

namespace Lab10
{
    public class AirPodsPage : AppleHomePage
    {
        public AirPodsPage (IWebDriver driver) : base(driver) { }

        public AirPodsProPage ClickAirPodsProButton ()
        {
            IWebElement airPodsProButton = driver.FindElement(By.XPath("//*[@id=\"chapternav\"]/div/ul/li[3]/a"));
            airPodsProButton.Click();
            return new AirPodsProPage (driver);
        }

        public bool IsProductInCart ()
        {
            driver.Navigate().GoToUrl("https://www.apple.com/shop/bag");
            try
            {
                IWebElement productInCart = driver.FindElement(By.XPath("//*[@id=\"bag-content\"]/ol/li[1]/div/div[2]/div[1]/div[1]/h2/a"));
                return productInCart != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}