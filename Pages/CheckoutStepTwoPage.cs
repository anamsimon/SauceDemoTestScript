namespace SauceDemoTest.Pages
{
    internal class CheckoutStepTwoPage : BasePage
    {
        private ShoppingCart cartLink;

        [FindsBy(How = How.ClassName, Using = "title")]
        private IWebElement title;

        public string PageTitle { get { return title.Text; } }

        [FindsBy(How = How.Id, Using = "cancel")]
        private IWebElement cancelButton;

        [FindsBy(How = How.Id, Using = "finish")]
        private IWebElement finishButton;

        public CheckoutStepTwoPage(IWebDriver driver)
            : base(driver)
        {
            cartLink = new ShoppingCart(driver);
            PageFactory.InitElements(driver, this);
        }


        public void ClickFinish()
        {
            finishButton.Click();

        }

        public int GetCartCount()
        {
            return cartLink.GetCartCount();
        }
    }
}
