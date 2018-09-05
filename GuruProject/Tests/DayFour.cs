using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuruProject.Tests
{
    [TestClass]
    [TestCategory("Handle Popup")]
    public class DayFour : BaseTest
    {
        [TestMethod]
        [Description("Verify that you are able to compare two product")]
        [TestProperty("Author","VJKumar")]
        public void HandleWindowPopup()
        {
            var homePage = new Homepage(Driver);
            homePage.GoTo();
            var mobilePage = homePage.OpenMobilePage(Driver);
            //("a[href*= 'product/1'][class='link-compare']")
            //("a[href*= 'product/2'][class='link-compare']")
            //*[@title='Compare']
            mobilePage.CompareProducts();

            
        }
    }
}
