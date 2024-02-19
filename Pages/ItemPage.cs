namespace SauceDemoTest.Pages
{
    internal class ItemPage : BasePage
    {


        [FindsBy(How = How.ClassName, Using = "inventory_details_name")]
        private IWebElement itemName;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-backpack")]
        private IWebElement removeButton;

        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-backpack")]
        private IWebElement addtoCart;


        public string ItemTitle { get { return itemName.Text; } }

        public ItemPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void AddToCart()
        {
            addtoCart.Click();
        }

        public void RemoveFromCart()
        {
            removeButton.Click();
        }

    }
}
