using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
    public class PaymentPage : ShippingInfoPage
    {
        public PaymentPage(IWebDriver driver) : base(driver) { }

        public void ChoosePaymentWithCard()
        {
            Thread.Sleep(2000);
            IWebElement payWithCardOption = driver.FindElement(By.XPath("//*[@id=\"checkout.billing.billingoptions.credit\"]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", payWithCardOption);
            Thread.Sleep(2000);
        }

        public bool IsCreditCardValid(string cardNumber)
        {
            IWebElement cardNumberInput = driver.FindElement(By.XPath("//*[@id=\"checkout.billing.billingOptions.selectedBillingOptions.creditCard.cardInputs.cardInput-0.cardNumber\"]"));
            cardNumberInput.SendKeys(cardNumber);

            IWebElement expirationDateInput = driver.FindElement(By.XPath("//*[@id=\"checkout.billing.billingOptions.selectedBillingOptions.creditCard.cardInputs.cardInput-0.expiration\"]"));
            expirationDateInput.Click();

            Thread.Sleep(1000);

            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id=\"checkout.billing.billingOptions.selectedBillingOptions.creditCard.cardInputs.cardInput-0.cardNumber_error\"]/span"));

            if (errorMessage != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsExpirationDateValid(string expirationDate) 
        {
            IWebElement expirationDateInput = driver.FindElement(By.XPath("//*[@id=\"checkout.billing.billingOptions.selectedBillingOptions.creditCard.cardInputs.cardInput-0.expiration\"]"));
            expirationDateInput.SendKeys(expirationDate);

            IWebElement cardNumberInput = driver.FindElement(By.XPath("//*[@id=\"checkout.billing.billingOptions.selectedBillingOptions.creditCard.cardInputs.cardInput-0.cardNumber\"]"));
            cardNumberInput.Click();
            Thread.Sleep(1000);

            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id=\"checkout.billing.billingOptions.selectedBillingOptions.creditCard.cardInputs.cardInput-0.expiration_error\"]/span"));
            if (errorMessage != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
