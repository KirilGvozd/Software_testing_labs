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

            // Находим кнопку "Vision" в хедере и кликаем по ней
            IWebElement visionButton = driver.FindElement(By.XPath("//a[contains(text(), 'Vision')]"));
            visionButton.Click();

            // Ждем некоторое время для загрузки страницы Apple Vision
            Thread.Sleep(2000);

            // Находим кнопку Notify me и кликаем по ней
            IWebElement notifyMeButton = driver.FindElement(By.XPath("//button[contains(text(), 'Notify me')]"));
            notifyMeButton.Click();

            // Ждем некоторое время для загрузки следующей страницы
            Thread.Sleep(2000);

            // Находим поле ввода email и вводим в него ваш email
            IWebElement emailInput = driver.FindElement(By.XPath("//input[@class='form-textbox-input']"));
            emailInput.SendKeys("kirillgvozd0@gmail.com");

            // Находим кнопку Notify me и кликаем по ней
            notifyMeButton = driver.FindElement(By.XPath("//button[@class='button button-super']"));
            notifyMeButton.Click();

            // Ждем некоторое время для завершения действий
            Thread.Sleep(2000);
        }
    }
}