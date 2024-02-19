using SauceDemoTest.Pages;
using SauceDemoTest.Setup;

namespace SauceDemoTest.Tests
{
    internal class CheckoutProcessTest : BaseTest
    {
        private ShoppingCart shoppingCart;
        private CartPage cartPage;
        private CheckoutStepOnePage checkoutStepOnePage;
        private CheckoutStepTwoPage checkoutStepTwoPage;
        private CheckoutCompletePage checkoutCompletePage;



        [OneTimeSetUp]
        public void Setup()
        {
            var loginPage = new LoginPage(driver);
            _ = loginPage.Login(TestData.Login.User, TestData.Login.Password);
            shoppingCart = new ShoppingCart(driver);
        }

        [Test, Order(1)]
        [TestCase(TestData.Cart.PageTitle)]
        public void LoadCartPage(string expectedPageTitle)
        {
            cartPage = shoppingCart.ClickCartLink();
            Assert.That(cartPage.PageTitle, Is.EqualTo(expectedPageTitle));
        }

        [Test, Order(2)]
        [TestCase(TestData.CheckoutOne.PageTitle)]
        public void LoadCheckoutPageOne(string expectedPageTitle)
        {
            checkoutStepOnePage = cartPage.ClickCheckoutButton();
            Assert.That(checkoutStepOnePage.PageTitle, Is.EqualTo(expectedPageTitle));
        }

        [Test, Order(3)]
        [TestCaseSource(typeof(TestData.CheckoutOne), nameof(TestData.CheckoutOne.CheckoutFormErrorTestCases))]
        public void CheckoutPageOne_Form_ValidationCheck((string fname, string lname, string pcode, string expected) td)
        {
            checkoutStepOnePage.FillupInformation(td.fname, td.lname, td.pcode);
            checkoutStepOnePage.ClickContinueButton();
            var message = checkoutStepOnePage.GetErrorMessage();
            Assert.That(message, Does.Contain(td.expected));
        }

        [Test, Order(4)]
        [TestCaseSource(typeof(TestData.CheckoutOne), nameof(TestData.CheckoutOne.CheckoutFormSuccessTestCases))]
        public void CheckoutPageOne_FormFillupAndContinue((string fname, string lname, string pcode, string expected) td)
        {
            checkoutStepOnePage.FillupInformation(td.fname, td.lname, td.pcode);
            checkoutStepOnePage.ClickContinueButton();
            checkoutStepTwoPage = new CheckoutStepTwoPage(driver);
            Assert.That(checkoutStepTwoPage.PageTitle, Is.EqualTo(td.expected));
        }

        [Test, Order(5)]
        [TestCase(TestData.CheckoutComplete.PageTitle)]
        public void CheckoutPageTwo_FinishProcess(string exptectedTitle)
        {
            checkoutStepTwoPage.ClickFinish();
            checkoutCompletePage = new CheckoutCompletePage(driver);
            Assert.That(checkoutCompletePage.PageTitle, Is.EqualTo(exptectedTitle));
        }
    }
}
