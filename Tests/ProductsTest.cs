using SauceDemoTest.Pages;
using SauceDemoTest.Setup;

namespace SauceDemoTest.Tests
{
    internal class ProductsTest : BaseTest
    {
        private ProductsPage productsPage;
        private IList<string> productsNames;
        private ItemPage itemPage;
        private ShoppingCart shoppingCart;


        [OneTimeSetUp]
        public void Setup()
        {
            var loginPage = new LoginPage(driver);
            productsPage = loginPage.Login(TestData.Login.User, TestData.Login.Password);
            shoppingCart = new ShoppingCart(driver);
        }

        [Test, Order(1)]
        public void ProductsPage_ItemsLoaded()
        {
            productsNames = productsPage.GetProductNames();
            Assert.That(productsNames, Has.Count.GreaterThan(0));
        }

        [Test, Order(2)]
        public void ProductPage_AddToCart()
        {
            var count = shoppingCart.GetCartCount();
            productsPage.AddToCart(productsNames[0]);
            var new_count = shoppingCart.GetCartCount();
            Assert.That(new_count - count, Is.EqualTo(1));
        }

        [Test, Order(3)]
        public void ProductPage_RemoveFromCart()
        {
            var count = shoppingCart.GetCartCount();
            productsPage.RemoveFromCart();
            var new_count = shoppingCart.GetCartCount();
            Assert.That(new_count , Is.EqualTo(count - 1));
        }      

        [Test, Order(4)]
        public void GoToItemPage()
        {
            itemPage = productsPage.ClickItemPage(productsNames[0]);
            Assert.That(itemPage, Is.Not.Null);
            Assert.That(itemPage.ItemTitle, Is.EqualTo(productsNames[0]));
        }

        [Test, Order(5)]
        public void ItemPage_AddToCart()
        {
            var count = shoppingCart.GetCartCount();
            itemPage.AddToCart();
            var new_count = shoppingCart.GetCartCount();
            Assert.That(new_count - count, Is.EqualTo(1));
        }

        [Test, Order(6)]
        public void ItemPage_RemoveFromCart()
        {
            var count = shoppingCart.GetCartCount();
            itemPage.RemoveFromCart();
            var new_count = shoppingCart.GetCartCount();
            Assert.That(new_count, Is.EqualTo(count - 1));
        }
       
    }
}
