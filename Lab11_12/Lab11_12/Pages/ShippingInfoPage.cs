using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
    public class ShippingInfoPage : OrderOptionsPage
    {
        public ShippingInfoPage(IWebDriver driver) : base(driver) { }

        public void EnterFirstName(string firstName)
        {
            IWebElement firstNameInput = driver.FindElement(By.XPath("//*[@id=\"checkout.shipping.addressSelector.newAddress.address.firstName\"]"));
            firstNameInput.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            IWebElement lastNameInput = driver.FindElement(By.XPath("//*[@id=\"checkout.shipping.addressSelector.newAddress.address.lastName\"]"));
            lastNameInput.SendKeys(lastName);
        }

        public void EnterAddress(string address)
        {
            IWebElement addressInput = driver.FindElement(By.XPath("//*[@id=\"checkout.shipping.addressSelector.newAddress.address.street\"]"));
            addressInput.SendKeys(address);
        } 

        public void EnterEmail(string email) 
        {
            IWebElement emailInput = driver.FindElement(By.XPath("//*[@id=\"checkout.shipping.addressContactEmail.address.emailAddress\"]"));
            emailInput.SendKeys(email);
        }

        public void EnterPhoneNumber(string phoneNumber)
        {
            IWebElement phoneNumberInput = driver.FindElement(By.XPath("//*[@id=\"checkout.shipping.addressContactPhone.address.fullDaytimePhone\"]"));
            phoneNumberInput.SendKeys(phoneNumber);
        }

        public void ClickContinueToPaymentButton()
        {
            IWebElement continueToPaymentButton = driver.FindElement(By.XPath("//*[@id=\"rs-checkout-continue-button-bottom\"]"));
            continueToPaymentButton.Click();
            Thread.Sleep(2000);
        }

        public PaymentPage ClickUseRecommndedAddressButton()
        {
            IWebElement useRecommndedAddressButton = driver.FindElement(By.XPath("//*[@id=\"checkout.shipping.addressVerification.recommendedAddresses.continueWithRecommended\"]"));
            useRecommndedAddressButton.Click();
            Thread.Sleep(2000);
            return new PaymentPage(driver);
        }
    }
}
