using SauceDemoTest.Pages;

namespace SauceDemoTest.Component
{
    internal class ShoppingCart
    {
        private IWebDriver driver;
        private By cartBadgeFindBy = By.CssSelector("span[class='shopping_cart_badge']");
        
        [FindsBy(How = How.CssSelector, Using = "a.shopping_cart_link")]
        private IWebElement cartLink;


        public ShoppingCart(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public int GetCartCount()
        {
            var innerText = cartLink.Text;
            if (!string.IsNullOrEmpty(innerText))
            {
                var cartBadge = cartLink.FindElement(cartBadgeFindBy);
                if (cartBadge.Displayed)
                {
                    int.TryParse(cartBadge.Text, out int count);
                    return count;
                }
            }
            return 0;
        }

        public CartPage ClickCartLink()
        {
            cartLink.Click();
            return new CartPage(driver);
        }
    }
}
