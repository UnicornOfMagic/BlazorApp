using BlazorApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlazorAppTests.Services
{
    [TestClass]
    public class VersionHelperTests
    {
        [TestMethod]
        public void WhenSearchForOneDotOhThenReturnsMostSoftware()
        {
            var sut = new VersionHelper();

            var result = sut.GetSoftwareNewerThan(1, 0, 0);

            Assert.AreEqual(7, result.Count);
        }

        [TestMethod]
        public void WhenSearchForExactVersionThenDoesNotReturnThatSoftware()
        {
            var sut = new VersionHelper();

            var result = sut.GetSoftwareNewerThan(2019, 1, 0);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void WhenSearchForVersionZeroThenReturnsAllSoftware()
        {
            var sut = new VersionHelper();

            var result = sut.GetSoftwareNewerThan(0, 0, 0);

            Assert.AreEqual(9, result.Count);
        }
    }
}
