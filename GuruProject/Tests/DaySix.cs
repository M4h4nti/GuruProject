using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuruProject.Tests
{
    [TestClass]
    [TestCategory("Purchase Product")]
    [TestCategory("Update Shipping Information")]
    [TestCategory("Login")]
    public class DaySix : BaseTest
    {
        private readonly string country = "United States";
        private readonly string state = "New York";
        private readonly string zip = "542896";


        [TestMethod]
        [Description("Verify user is able to purchase product using registered email id")]
        [TestProperty("Author","VJKumar")]
        public void PurchaseProduct()
        {
            var homePage = new Homepage(Driver);
            homePage.GoTo();
            var loginPage = homePage.GoToAccountPage();
            var accountPage = loginPage.Login("Mahikumar4@live.com","password");
            Assert.IsTrue(Driver.Title.Equals("My Account"));
            var myWishListPage = accountPage.OpenMyWishList();
            var shoppingCartPage = myWishListPage.AddToCart();
            shoppingCartPage.EstimateShippingAndTax(country,state,zip);
            Assert.IsTrue(shoppingCartPage.ShippingCostGenerated);
            shoppingCartPage.UpdateTotal();
            Assert.IsTrue(shoppingCartPage.ShippingCostAdded);
            var checkoutPage = shoppingCartPage.ProceedToCheckout();
            checkoutPage.UpdateBillingInformation("Mahi", "Kumar", "abc", "New York", country,state,zip,"12345678");
            checkoutPage.ShippingMethodContinue();
            checkoutPage.SelectPaymentInformationAndContinue();            
            var orderConfirmPage = checkoutPage.PlaceOrder();
            //System.Console.WriteLine(orderConfirmPage.OrderNumber);
            //Assert.IsTrue(Driver.PageSource.Contains("Thank you for your purchase!"));
            //Assert.IsTrue(Driver.Url.Contains("success"));
            Assert.IsTrue(orderConfirmPage.OrderNumberIsDisplayed);
            System.Console.WriteLine(orderConfirmPage.OrderNumber);
            System.Console.WriteLine($"{Driver.Url}");
        }
    }
}
