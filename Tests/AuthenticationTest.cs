using NUnit.Framework.Internal;
using SauceDemoTest.Pages;
using SauceDemoTest.Setup;

namespace SauceDemoTest.Tests
{
    internal class AuthenticationTest : BaseTest
    {
        [Test, Order(1)]
        [TestCaseSource(typeof(TestData.Login), nameof(TestData.Login.LoginFailedTestCases))]
        public void Login_Fail((string username, string password, string expected) td)
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login(td.username, td.password);
            var errorMessage = loginPage.GetErrorMessage();
            Assert.That(errorMessage, Does.Contain(td.expected));
        }

        [Test, Order(2)]
        [TestCase(TestData.Login.User, TestData.Login.Password,TestData.Products.PageTitle)]
        public void Login_Success(string username, string password, string exptectedTitle)
        {
            var loginPage = new LoginPage(driver);
            var newPage = loginPage.Login(username, password);
            Assert.That(newPage, Is.Not.Null);
            Assert.That(newPage.PageTitle, Is.EqualTo(exptectedTitle));
        }

        [Test, Order(3)]
        [TestCase(TestData.Login.PageTitle)]
        public void Logout_Success(string exptectedTitle)
        {
            var sideMenu = new SideMenu(driver);
            var newPage = sideMenu.Logout();
            Assert.That(newPage, Is.Not.Null);
            Assert.That(newPage.PageTitle, Is.EqualTo(exptectedTitle));
        }
    }
}
