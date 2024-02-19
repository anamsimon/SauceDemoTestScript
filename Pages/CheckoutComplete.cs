using SauceDemoTest.Component;
using SeleniumExtras.PageObjects;

namespace SauceDemoTest.Pages
{
    internal class CheckoutCompletePage : BasePage
    {

        [FindsBy(How = How.ClassName, Using = "title")]
        private IWebElement title;

        public string PageTitle { get { return title.Text; } }

        [FindsBy(How = How.Id, Using = "back-to-products")]
        private IWebElement backToProductsButton;

        public CheckoutCompletePage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public ProductsPage ClickBackToHome()
        {
            backToProductsButton.Click();
            return new ProductsPage(driver);
        }

    }
}
