using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuruProject
{
    [TestClass]
    [TestCategory("SortByName")]
    public class DayOne : BaseTest
    {
        [TestMethod]
        [Description("Verify item in mobile list page is sorted by name")]
        [TestProperty("Author","VJKumar")]
        
        public void SortByName()
        {
            var homePage = new Homepage(Driver);
            homePage.GoTo();
            Assert.IsTrue(Driver.PageSource.Contains("This is demo site for "));
            var mobilePage = homePage.OpenMobilePage(Driver);
            Assert.AreEqual("MOBILE", Driver.Title.ToUpper());
            mobilePage.SortBy("Name");
            Assert.IsTrue(Driver.Url.Contains("order=name"));
        }
    }
}
