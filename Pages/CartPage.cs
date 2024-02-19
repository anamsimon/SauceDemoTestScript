namespace SauceDemoTest.Pages
{
    internal class CartPage : BasePage
    {

        [FindsBy(How = How.ClassName, Using = "title")]
        private IWebElement title;

        public string PageTitle { get { return title.Text; } }

        [FindsBy(How = How.CssSelector, Using = "div[class='cart_item']")]
        private IList<IWebElement> cartItems;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-backpack")]
        private IList<IWebElement> removeButtons;

        [FindsBy(How = How.Id, Using = "checkout")]
        private IWebElement checkoutButton;

        private By itemNameFindBy = By.CssSelector("a div[class*='inventory_item_name']");


        public CartPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void RemoveFromCart()
        {
            if (removeButtons.Count > 0)
                removeButtons[0].Click();
        }

        public string[] GetCartItems()
        {
            return cartItems.Select(c => c.FindElement(itemNameFindBy).Text).ToArray();
        }

        public CheckoutStepOnePage ClickCheckoutButton()
        {
            checkoutButton.Click();
            return new CheckoutStepOnePage(driver);
        }
    }
}
