using AngleSharp.Dom;
using BlazorApp.Pages;
using Bunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlazorAppTests.Pages
{
    [TestClass]
    public class VersionFinderTests
    {
        [TestMethod]
        public void WhenPageLoads_ThenErrorNotVisible()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<VersionFinder>();

            var markup = cut.Markup;

            Assert.IsFalse(markup.Contains("The entered version was invalid. Please enter versions in the format {major}.{minor}.{patch} using only whole numbers and periods."));
        }

        [TestMethod]
        public void WhenSearchingEmptyVersion_ThenErrorVisible()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<VersionFinder>();

            var searchButton = cut.Find("button");

            searchButton.Click();

            var markup = cut.Markup;

            Assert.IsTrue(markup.Contains("No version entered."));
        }
    }
}
