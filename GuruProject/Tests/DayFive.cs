using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuruProject.Tests
{
    [TestClass]
    [TestCategory("Account Creation")]
    public class DayFive : BaseTest
    {
        [TestMethod]
        [Description("Create a new account and can share wishlist to other people using email")]
        [TestProperty("Author","VJKumar")]
        [Ignore]        
        public void CreateAccount()
        {
            var homePage = new Homepage(Driver);
            homePage.GoTo();
            var loginPage = homePage.GoToAccountPage();
            var registrationPage = loginPage.CreateNewAccount();
            var accountPage = registrationPage.CreateAccount("Mahi","Kumar","MahiKumar21@live.com","password","password");
            Assert.IsTrue(Driver.Title.Equals("My Account"));
        }

        [TestMethod]
        [Description("Create a new account and can share wishlist to other people using email")]
        [TestProperty("Author", "VJKumar")]
        //[Ignore]
        public void CreateAccountAndShareWishlist()
        {
            var homePage = new Homepage(Driver);
            homePage.GoTo();
            var loginPage = homePage.GoToAccountPage();
            var registrationPage = loginPage.CreateNewAccount();
            var accountPage = registrationPage.CreateAccount("Mahi", "Kumar", "MahiKumar4@live.com", "password", "password");
            Assert.IsTrue(Driver.Title.Equals("My Account"));
            var tvPage = accountPage.OpenTVPage();
            var myWishListPage = tvPage.AddProductToWishList();
            var wishListSharingPage = myWishListPage.ShareWishList();
            wishListSharingPage.ShareWithMessage("Mahikumar2@live.com","Hi");
            Assert.AreEqual("Your Wishlist has been shared.", wishListSharingPage.SuccessMessage);
        }        
    }
}
