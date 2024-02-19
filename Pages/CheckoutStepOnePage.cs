namespace SauceDemoTest.Pages
{
    internal class CheckoutStepOnePage : BasePage
    {

        [FindsBy(How = How.ClassName, Using = "title")]
        private IWebElement title;

        public string PageTitle { get { return title.Text; } }

        [FindsBy(How = How.Id, Using = "first-name")]
        private IWebElement firstNameInput;

        [FindsBy(How = How.Id, Using = "last-name")]
        private IWebElement lastNameInput;

        [FindsBy(How = How.Id, Using = "postal-code")]
        private IWebElement postalCodeInput;

        [FindsBy(How = How.CssSelector, Using = "div.error-message-container")]
        private IWebElement erroMessageContainer;

        private By errorMessageFindBy = By.TagName("h3");

        [FindsBy(How = How.Id, Using = "continue")]
        private IWebElement continueButton;

        public CheckoutStepOnePage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void FillupInformation(string fName, string lName, string postCode)
        {
            firstNameInput.Clear();
            if (!string.IsNullOrEmpty(fName))
                firstNameInput.SendKeys(fName);

            lastNameInput.Clear();
            if (!string.IsNullOrEmpty(lName))
                lastNameInput.SendKeys(lName);
            
            postalCodeInput.Clear();
            if (!string.IsNullOrEmpty(postCode))
                postalCodeInput.SendKeys(postCode);
        }

        public string GetErrorMessage()
        {

            if (string.IsNullOrEmpty(erroMessageContainer.Text))
                return string.Empty;

            var message = erroMessageContainer.FindElement(errorMessageFindBy);
            return message.Text;
        }

        public CheckoutStepTwoPage ClickContinueButton()
        {
            continueButton.Click();
            return new CheckoutStepTwoPage(driver);
        }
    }
}
