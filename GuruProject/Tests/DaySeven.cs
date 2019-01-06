using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuruProject.Tests
{
    [TestClass]
    [TestCategory("Download pdf")]
    public class DaySeven : BaseTest
    {
        [TestMethod]
        [Description("Verify that you will be able to save previously placed order as a pdf file")]
        [TestProperty("Author","VJKumar")]
        public void DownloadPDF()
        {
            var homePage = new Homepage(Driver);
            homePage.GoTo();
            var loginPage = homePage.GoToAccountPage();
            var accountPage = loginPage.Login("Mahikumar4@live.com", "password");
            Assert.IsTrue(Driver.Title.Equals("My Account"));
            var myOrdersPage = accountPage.OpenMyOrders();
            var ordersPage = myOrdersPage.ViewOrder();
            Assert.IsTrue(ordersPage.Status.Equals("PENDING"));
            ordersPage.PrintOrder();
            //Assert.IsTrue();

        }
    }
}
