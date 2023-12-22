using Lab10;
using Lab11_12.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Tests
{
    [TestFixture]
    public class Apple_tests : Steps.Steps
    {
        [Test]
        public void TestChangeProductQuantity()
        {
            AppleHomePage appleHomePage = new AppleHomePage(driver);
            appleHomePage.OpenHomePage();

            AirPodsPage airPodsPage = appleHomePage.GoToAirPodsPage();

            AirPodsProPage airPodsProPage = airPodsPage.ClickAirPodsProButton();

            airPodsProPage.ClickBuyButton();
            CartPage cartPage = airPodsProPage.ClickAddToBagButton();

            bool check = cartPage.ChangeQuantityAndVerifyPrice();
            Assert.IsTrue(check);
        }

        [Test]
        public void TestDeleteProductFromCart()
        {

            AppleHomePage appleHomePage = new AppleHomePage(driver);
            appleHomePage.OpenHomePage();

            AirPodsPage airPodsPage = appleHomePage.GoToAirPodsPage();

            AirPodsProPage airPodsProPage = airPodsPage.ClickAirPodsProButton();

            airPodsProPage.ClickBuyButton();
            CartPage cartPage = airPodsProPage.ClickAddToBagButton();

            cartPage.ClickRemoveProductButton();
            cartPage.ClickUndoButton();
        }

        [Test]
        public void TestEstimatedTax()
        {

            AppleHomePage appleHomePage = new AppleHomePage(driver);
            appleHomePage.OpenHomePage();

            AirPodsPage airPodsPage = appleHomePage.GoToAirPodsPage();

            AirPodsProPage airPodsProPage = airPodsPage.ClickAirPodsProButton();

            airPodsProPage.ClickBuyButton();
            CartPage cartPage = airPodsProPage.ClickAddToBagButton();

            cartPage.ClickZipCodeButton();

            bool isTaxChanged = cartPage.EnterZipCode("90001");
            Assert.IsTrue(isTaxChanged);
        }

        [Test]
        public void TestNotExistingStorePickUp()
        {
            AppleHomePage appleHomePage = new AppleHomePage(driver);
            appleHomePage.OpenHomePage();

            AirPodsPage airPodsPage = appleHomePage.GoToAirPodsPage();

            AirPodsProPage airPodsProPage = airPodsPage.ClickAirPodsProButton();

            airPodsProPage.ClickBuyButton();
            CartPage cartPage = airPodsProPage.ClickAddToBagButton();

            CheckoutPage checkoutPage = cartPage.ClickCheckOutButton();
            
            OrderOptionsPage orderOptionsPage = checkoutPage.ClickContinueAsGuestButton();

            orderOptionsPage.PickUpOptionButtonClick();
            orderOptionsPage.EnterNotExistingCity("Minsk");
            bool isCityExists = orderOptionsPage.IsCityExists();

            Assert.IsTrue(isCityExists);
        }

        [Test]
        public void TestNotExistingCityForDeliver()
        {
            AppleHomePage appleHomePage = new AppleHomePage(driver);
            appleHomePage.OpenHomePage();

            AirPodsPage airPodsPage = appleHomePage.GoToAirPodsPage();

            AirPodsProPage airPodsProPage = airPodsPage.ClickAirPodsProButton();

            airPodsProPage.ClickBuyButton();
            CartPage cartPage = airPodsProPage.ClickAddToBagButton();

            CheckoutPage checkoutPage = cartPage.ClickCheckOutButton();

            OrderOptionsPage orderOptionsPage = checkoutPage.ClickContinueAsGuestButton();

            orderOptionsPage.EnterZipCodeInOrderPage("123455667");
            bool isZipCodeExists = orderOptionsPage.IsZipCodeExists();
            Assert.IsTrue(isZipCodeExists);
        }

        [Test]
        public void TestNotValidCardNumberInput()
        {
            AppleHomePage appleHomePage = new AppleHomePage(driver);
            appleHomePage.OpenHomePage();

            AirPodsPage airPodsPage = appleHomePage.GoToAirPodsPage();

            AirPodsProPage airPodsProPage = airPodsPage.ClickAirPodsProButton();

            airPodsProPage.ClickBuyButton();
            CartPage cartPage = airPodsProPage.ClickAddToBagButton();

            CheckoutPage checkoutPage = cartPage.ClickCheckOutButton();

            OrderOptionsPage orderOptionsPage = checkoutPage.ClickContinueAsGuestButton();

            orderOptionsPage.EnterZipCodeInOrderPage("99501-5778");
            orderOptionsPage.ClickApplyButton();
            
            ShippingInfoPage shippingInfoPage = orderOptionsPage.ClickContinueShippingButton();

            shippingInfoPage.EnterFirstName("Kirill");
            shippingInfoPage.EnterLastName("Gvozdovskiy");
            shippingInfoPage.EnterAddress("1281 E 19th Ave");
            shippingInfoPage.EnterEmail("kirillgvozd0@gmail.com");
            shippingInfoPage.EnterPhoneNumber("(375) 333-7553");

            shippingInfoPage.ClickContinueToPaymentButton();

            PaymentPage paymentPage = shippingInfoPage.ClickUseRecommndedAddressButton();
            paymentPage.ChoosePaymentWithCard();
            bool isCreditCardValid = paymentPage.IsCreditCardValid("123");
            Assert.IsFalse(isCreditCardValid);
        }

        [Test]
        public void TestAddProductToCart()
        {
            AppleHomePage appleHomePage = new AppleHomePage(driver);
            appleHomePage.OpenHomePage();

            AirPodsPage airPodsPage = appleHomePage.GoToAirPodsPage();

            AirPodsProPage airPodsProPage = airPodsPage.ClickAirPodsProButton();

            airPodsProPage.ClickBuyButton();

            CartPage cartPage = airPodsProPage.ClickAddToBagButton();
            bool isProductInCart = airPodsPage.IsProductInCart();
            Assert.IsTrue(isProductInCart);
        }

        [Test]
        public void TestEnterInvalidEmailAddress()
        {
            AppleHomePage appleHomePage = new AppleHomePage(driver);
            appleHomePage.OpenHomePage();

            VisionPage visionPage = appleHomePage.GoToVisionPage();
            visionPage.ClickNotifyMeButton();
            visionPage.EnterEmailAddress("kiririr");
            bool IsEmailValid = visionPage.IsEmailValid();
            Assert.IsFalse(IsEmailValid);
        }

        [Test]
        public void TestEnterInvalidExpirationDate()
        {
            AppleHomePage appleHomePage = new AppleHomePage(driver);
            appleHomePage.OpenHomePage();

            AirPodsPage airPodsPage = appleHomePage.GoToAirPodsPage();

            AirPodsProPage airPodsProPage = airPodsPage.ClickAirPodsProButton();

            airPodsProPage.ClickBuyButton();
            CartPage cartPage = airPodsProPage.ClickAddToBagButton();

            CheckoutPage checkoutPage = cartPage.ClickCheckOutButton();

            OrderOptionsPage orderOptionsPage = checkoutPage.ClickContinueAsGuestButton();

            orderOptionsPage.EnterZipCodeInOrderPage("99501-5778");
            orderOptionsPage.ClickApplyButton();

            ShippingInfoPage shippingInfoPage = orderOptionsPage.ClickContinueShippingButton();

            shippingInfoPage.EnterFirstName("Kirill");
            shippingInfoPage.EnterLastName("Gvozdovskiy");
            shippingInfoPage.EnterAddress("1281 E 19th Ave");
            shippingInfoPage.EnterEmail("kirillgvozd0@gmail.com");
            shippingInfoPage.EnterPhoneNumber("(375) 333-7553");

            shippingInfoPage.ClickContinueToPaymentButton();

            PaymentPage paymentPage = shippingInfoPage.ClickUseRecommndedAddressButton();
            paymentPage.ChoosePaymentWithCard();
            bool isDateValid = paymentPage.IsExpirationDateValid("11/23");
            Assert.IsFalse(isDateValid);
        }
    }
}
