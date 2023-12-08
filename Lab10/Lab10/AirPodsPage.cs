using OpenQA.Selenium;

namespace Lab10
{
    public class AirPodsPage : AppleHomePage
    {
        public AirPodsPage (IWebDriver driver) : base(driver) { }

        public void ClickAirPodsProButton ()
        {
            IWebElement airPodsProButton = driver.FindElement(By.XPath("//*[@id=\"chapternav\"]/div/ul/li[3]/a"));
            airPodsProButton.Click();
        }

        public void ClickBuyButton ()
        {
            IWebElement buyButton = driver.FindElement(By.XPath("//*[@id=\"ac-localnav\"]/div/div[2]/div[2]/div[2]/div[2]/a"));
            buyButton.Click();
        }

        public void ClickAddToBagButton ()
        {
            IWebElement addToBagButton = driver.FindElement(By.XPath("//button[contains(text(), 'Add to Bag')] "));
            addToBagButton.Click();
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