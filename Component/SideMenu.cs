using OpenQA.Selenium.Support.UI;
using SauceDemoTest.Pages;
using SeleniumExtras.WaitHelpers;

namespace SauceDemoTest.Component
{
    internal class SideMenu
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]
        private IWebElement sideMenu;

        private By logOutFindBy = By.Id("logout_sidebar_link");


        public SideMenu(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public LoginPage Logout()
        {
            sideMenu.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2)); 
            wait.Until(ExpectedConditions.ElementIsVisible(logOutFindBy)).Click();
            return new LoginPage(driver);
        }
    }
}
