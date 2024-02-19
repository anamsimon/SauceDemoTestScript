namespace SauceDemoTest.Pages
{
    internal class BasePage
    {
        internal readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;

        }
    }
}
