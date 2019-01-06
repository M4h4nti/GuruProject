using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Utilities.ExcelHelper;

namespace GuruProject
{
    [TestClass]
    [TestCategory("SortByName")]
    public class DayOne : BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            ExcelDataInCollection(@"F:\Testing\AutomationPractice\Guru99Project\GuruProject\TestData\Guru99TestData.xlsx", "DayOne");
        }

        [TestMethod]
        [Description("Verify item in mobile list page is sorted by name")]
        [TestProperty("Author","VJKumar")]        
        public void SortByName()
        {
            var homePage = new Homepage(Driver);
            homePage.GoTo();
            Assert.IsTrue(Driver.PageSource.Contains(ReadData(1,"Asserts")));
            var mobilePage = homePage.OpenMobilePage(Driver);
            Assert.AreEqual(ReadData(2, "Asserts"), Driver.Title.ToUpper());
            mobilePage.SortBy(ReadData(1, "SortBy"));
            Console.WriteLine(ReadData(3,"Asserts"));
            //Assert.IsTrue(Driver.Url.Contains(ReadData(3, "Asserts")));
            Assert.IsTrue(Driver.Url.Contains("order=name"));
        }
    }
}
