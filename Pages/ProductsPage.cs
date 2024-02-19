namespace SauceDemoTest.Pages
{
    internal class ProductsPage : BasePage
    {

        [FindsBy(How = How.ClassName, Using = "title")]
        private IWebElement title;

        [FindsBy(How = How.CssSelector, Using = "div[class='inventory_item']")]
        private IList<IWebElement> products;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-backpack")]
        private IList<IWebElement> removeButtons;

        private By itemNameFindBy = By.CssSelector("a div[class*='inventory_item_name']");
        private By addtoCartFindBy = By.Id("add-to-cart-sauce-labs-backpack");


        public string PageTitle { get { return title.Text; } }


        public ProductsPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void AddToCart(string productName)
        {

            var matchedProduct = products.FirstOrDefault(p => string.Equals(productName, p.FindElement(itemNameFindBy).Text));

            if (matchedProduct != null)
            {
                matchedProduct.FindElement(addtoCartFindBy).Click();
            }
        }

        public string[] GetProductNames()
        {
            return products.Select(p => p.FindElement(itemNameFindBy).Text).ToArray();
        }



        public void RemoveFromCart()
        {
            if (removeButtons.Count > 0)
                removeButtons[0].Click();
        }


        public ItemPage ClickItemPage(string productName)
        {
            var matchedProduct = products.FirstOrDefault(p => string.Equals(productName, p.FindElement(itemNameFindBy).Text));

            if (matchedProduct != null)
            {
                matchedProduct.FindElement(itemNameFindBy).Click();
                return new ItemPage(driver);
            }
            return null;
        }
    }
}
