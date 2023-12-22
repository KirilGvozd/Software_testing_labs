using Lab10;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
    public class CartPage : AppleHomePage
    {
        public CartPage(IWebDriver webDriver) : base(webDriver) { }

        public bool ChangeQuantityAndVerifyPrice()
        {
            string originalPrice;
            var quantityDropdown = driver.FindElement(By.XPath("//*[@class=\"rs-quantity-dropdown form-dropdown-select\"]"));
            var priceDiv = driver.FindElement(By.XPath("//div[@data-autom='Monthly_price']"));

            originalPrice = priceDiv.Text;

            var quantitySelect = new SelectElement(quantityDropdown);
            quantitySelect.SelectByValue("2");

            Thread.Sleep(2000);

            var updatedPrice = priceDiv.Text;

            if (originalPrice != updatedPrice)
            {
                return true;
            }
            else { return false; }
        }

        public void ClickRemoveProductButton()
        {
            IWebElement removeButton = driver.FindElement(By.XPath("//*[@class=\"rs-iteminfo-remove as-buttonlink\"]"));
            removeButton.Click();
            Thread.Sleep(2000);
        }

        public void ClickUndoButton()
        {
            IWebElement undoButton = driver.FindElement(By.XPath("//*[@id=\"shoppingCart.cartMessages.undo\"]"));
            undoButton.Click();
            Thread.Sleep(5000);
        }

        public void ClickZipCodeButton()
        {
            IWebElement zipCodeButton = driver.FindElement(By.XPath("//*[@id=\"rs-summary-enterzipcode\"]"));
            zipCodeButton.Click();
            Thread.Sleep(2000);
        }

        private void ClickApplyButton()
        {
            IWebElement applyButton = driver.FindElement(By.XPath("//*[@id=\"shoppingCart.summary.taxCalculator.address.calculate\"]"));
            applyButton.Click();
            Thread.Sleep(2000);
        }

        public CheckoutPage ClickCheckOutButton()
        {
            IWebElement checkoutButton = driver.FindElement(By.XPath("//*[@id=\"shoppingCart.actions.checkout\"]"));
            checkoutButton.Click();

            Thread.Sleep(2000);

            return new CheckoutPage(driver);
        }

        public bool EnterZipCode(string zipCode)
        {
            string originalPrice;
            var priceDiv = driver.FindElement(By.XPath("//*[@id=\"bag-content\"]/div[3]/div/div[5]/div[2]"));
            originalPrice = priceDiv.Text;

            IWebElement zipCodeInput = driver.FindElement(By.XPath("//*[@id=\"shoppingCart.summary.taxCalculator.address.postalCode\"]"));

            zipCodeInput.SendKeys(zipCode);

            ClickApplyButton();

            Thread.Sleep(2000);

            var updatedPrice = priceDiv.Text;

            if (originalPrice != updatedPrice)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }
    }
}

