using Lab10;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
    public class CheckoutPage : CartPage
    {
        public CheckoutPage(IWebDriver driver) :  base(driver) { }

        public OrderOptionsPage ClickContinueAsGuestButton()
        {
            IWebElement continueAsGuestButton = driver.FindElement(By.XPath("//*[@id=\"signIn.guestLogin.guestLogin\"]"));
            continueAsGuestButton.Click();

            Thread.Sleep(2000);

            return new OrderOptionsPage(driver);
        }
    }
}
