using Lab10;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
    public class AirPodsProPage : AirPodsPage
    {
        public AirPodsProPage(IWebDriver driver) : base(driver) { }

        public void ClickBuyButton()
        {
            IWebElement buyButton = driver.FindElement(By.XPath("//*[@id=\"ac-localnav\"]/div/div[2]/div[2]/div[2]/div[2]/a"));
            buyButton.Click();
        }

        public CartPage ClickAddToBagButton()
        {
            IWebElement addToBagButton = driver.FindElement(By.XPath("//button[contains(text(), 'Add to Bag')] "));
            addToBagButton.Click();
            return new CartPage(driver);
        }
    }
}