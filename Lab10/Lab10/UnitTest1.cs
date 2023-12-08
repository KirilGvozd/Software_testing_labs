using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Lab10
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
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
        }

        [Test]
        public void TestEnteringValidEmailAddress()
        {
            AppleHomePage homePage = new AppleHomePage(driver);
            homePage.OpenHomePage();

            VisionPage visionPage = homePage.GoToVisionPage();
            visionPage.ClickNotifyMeButton();
            Thread.Sleep(2000);

            visionPage.EnterEmailAddress("kirillgvozd0@gmail.com");
            visionPage.ClickSubmitButton();
            Thread.Sleep(2000);
        }

        [Test]
        public void TestAddingProductToCart()
        {
            AppleHomePage homePage = new AppleHomePage(driver);
            homePage.OpenHomePage();

            AirPodsPage airPodsPage = homePage.GoToAirPodsPage();
            Thread.Sleep(2000);
            airPodsPage.ClickAirPodsProButton();
            Thread.Sleep(2000);
            airPodsPage.ClickBuyButton();
            airPodsPage.ClickAddToBagButton();

            Assert.IsTrue(airPodsPage.IsProductInCart());
            Thread.Sleep(2000);
        }
    }
}   