using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuruProject.Tests
{
    [TestClass]
    [TestCategory("Cart Verification")]
    public class DayThree : BaseTest
    {
        public object ErrorMessage { get; private set; }

        [TestMethod]
        [Description("Verify that you cannot add more product in cart than the product available in store")]
        [TestProperty("Author","VJKumar")]
        public void NoMoreProduct()
        {
            var homePage = new Homepage(Driver);
            homePage.GoTo();
            var mobilePage = homePage.OpenMobilePage(Driver);           
            var shoppingCart = mobilePage.AddXperiaToCart(Driver);
            shoppingCart.UpdateQuantity("1000");
            Assert.IsTrue(shoppingCart.ErrorMessageDisplayed,"Update error");
            shoppingCart.EmptyCart();
            Assert.IsTrue(Driver.PageSource.Contains("Shopping Cart is Empty"));
        }
    }
}
