using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;

namespace Lab9
{
    public class Tests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TearDownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Assert.That(verificationErrors.ToString(), Is.EqualTo(""));
        }

        [Test]
        public void TestEnteringValidEmailAddress()
        {
            driver.Navigate().GoToUrl("https://www.apple.com/");

            IWebElement visionButton = driver.FindElement(By.XPath("//a[contains(text(), 'Vision')]"));
            visionButton.Click();

            Thread.Sleep(2000);

            IWebElement notifyMeButton = driver.FindElement(By.XPath("//button[contains(text(), 'Notify me')]"));
            notifyMeButton.Click();

            Thread.Sleep(2000);

            IWebElement emailInput = driver.FindElement(By.XPath("//input[@class='form-textbox-input']"));
            emailInput.SendKeys("kirillgvozd0@gmail.com");

            notifyMeButton = driver.FindElement(By.XPath("//button[@class='button button-super']"));
            notifyMeButton.Click();

            Thread.Sleep(2000);
        }
    }
}