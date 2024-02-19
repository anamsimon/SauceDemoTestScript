namespace SauceDemoTest.Pages
{
    internal class LoginPage : BasePage
    {

        [FindsBy(How = How.CssSelector, Using = "div.login_logo")]
        private IWebElement title;

        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement usernameInput;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement loginButton;

        [FindsBy(How = How.CssSelector, Using = "div.error-message-container")]
        private IWebElement erroMessageContainer;

        private By errorMessageFindBy = By.TagName("h3");

        public string PageTitle { get { return title.Text; } }

        public LoginPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public ProductsPage Login(string username, string password)
        {
            usernameInput.Clear();
            usernameInput.SendKeys(username);
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            loginButton.Click();
            return new ProductsPage(driver);
        }

        public string GetErrorMessage()
        {

            if (string.IsNullOrEmpty(erroMessageContainer.Text))
                return string.Empty;

            var message = erroMessageContainer.FindElement(errorMessageFindBy);
            return message.Text;
        }
    }
}
