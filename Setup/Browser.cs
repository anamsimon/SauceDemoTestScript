
namespace SauceDemoTest.Setup
{
    internal class Browser
    {
        private static IWebDriver? driver;

        public static IWebDriver GetWebDriver()
        {
            var chromOptions = new ChromeOptions();
            chromOptions.AddArgument("ignore-certificate-errors");
            chromOptions.AddArgument("start-maximized");
            chromOptions.AddArgument("--disable-single-click-autofill");
           
            driver = new ChromeDriver(chromOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }
    }
}
