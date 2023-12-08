using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Threading;


namespace Lab10
{
    public class VisionPage : AppleHomePage
    {
        public VisionPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickNotifyMeButton()
        {
            IWebElement notifyMeButton = driver.FindElement(By.XPath("//button[contains(text(), 'Notify me')]"));
            notifyMeButton.Click();
        }

        public void EnterEmailAddress(string email)
        {
            IWebElement emailInput = driver.FindElement(By.XPath("//input[@class='form-textbox-input']"));
            emailInput.SendKeys(email);
        }

        public void ClickSubmitButton()
        {
            IWebElement notifyMeButton = driver.FindElement(By.XPath("//button[@class='button button-super']"));
            notifyMeButton.Click();
        }
    }
}
