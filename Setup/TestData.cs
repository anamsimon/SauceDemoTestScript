namespace SauceDemoTest.Setup
{
    internal class TestData
    {
        public class Login
        {
            public static IEnumerable<(string user, string password, string expected)> LoginFailedTestCases()
            {
                yield return ("locked_out_user", "secret_sauce", "Epic sadface: Sorry, this user has been locked out");
                yield return ("john", "secretpass", "Epic sadface: Username and password do not match any user in this service");
            }

            public const string User = "standard_user";
            public const string Password = "secret_sauce";
            public const string PageTitle = "Swag Labs";
        }

        public class Products
        {
            public const string PageTitle = "Products";
        }

        public class Cart
        {
            public const string PageTitle = "Your Cart";
        }

        public class CheckoutOne
        {
            public const string PageTitle = "Checkout: Your Information";
            public static IEnumerable<(string fname, string lname, string pcode, string expected)> CheckoutFormErrorTestCases()
            {
                yield return ("", "Doe", "T5T5T", "Error: First Name is required");
            }
            public static IEnumerable<(string fname, string lname, string pcode, string expected)> CheckoutFormSuccessTestCases()
            {
                yield return ("John", "Doe", "T5T5T", CheckoutTwo.PageTitle);
            }
        }

        public class CheckoutTwo
        {
            public const string PageTitle = "Checkout: Overview";
        }

        public class CheckoutComplete
        {
            public const string PageTitle = "Checkout: Complete!";
        }

    }
}
