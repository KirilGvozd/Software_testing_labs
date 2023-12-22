using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
    public class OrderOptionsPage : CheckoutPage
    {
        public OrderOptionsPage(IWebDriver driver) : base(driver) { }

        public void PickUpOptionButtonClick()
        {
            IWebElement radioButton = driver.FindElement(By.Id("fulfillmentOptionButtonGroup1"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", radioButton);
        }

        public void EnterNotExistingCity(string city)
        {
            Thread.Sleep(3000);
            IWebElement cityInputField = driver.FindElement(By.XPath("//*[@id=\"checkout.fulfillment.pickupTab.pickup.storeLocator.searchInput\"]"));
            cityInputField.SendKeys(city);
        }

        public bool IsCityExists()
        {
            IWebElement applyButton = driver.FindElement(By.XPath("//*[@id=\"checkout.fulfillment.pickupTab.pickup.storeLocator.search\"]"));
            applyButton.Click();

            Thread.Sleep(2000);

            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id=\"checkout.fulfillment.pickupTab.pickup.storeLocator.searchInput_error\"]/span"));

            if (errorMessage == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void EnterZipCodeInOrderPage(string zipCode)
        {
            Thread.Sleep(3000);
            IWebElement zipCodeInputField = driver.FindElement(By.XPath("//*[@id=\"checkout.fulfillment.deliveryTab.delivery.deliveryLocation.address.postalCode\"]"));
            zipCodeInputField.SendKeys(zipCode);
        }

        public void ClickApplyButton()
        {
            IWebElement applyButton = driver.FindElement(By.XPath("//*[@id=\"checkout.fulfillment.deliveryTab.delivery.deliveryLocation.address.calculate\"]"));
            applyButton.Click();
            Thread.Sleep(3000);
        }

        public bool IsZipCodeExists()
        {
            IWebElement applyButton = driver.FindElement(By.XPath("//*[@id=\"checkout.fulfillment.deliveryTab.delivery.deliveryLocation.address.calculate\"]"));
            applyButton.Click();

            Thread.Sleep(2000);

            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id=\"checkout.fulfillment.deliveryTab.delivery.deliveryLocation.address.postalCode_error\"]/span"));

            if (errorMessage == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ShippingInfoPage ClickContinueShippingButton()
        {
            IWebElement continueShippingButton = driver.FindElement(By.XPath("//*[@id=\"rs-checkout-continue-button-bottom\"]"));
            continueShippingButton.Click();
            Thread.Sleep(2000);
            return new ShippingInfoPage(driver);
        }
    }
}
