using BikeShop.UI.Pages;
using Bunit;
using NUnit.Framework;

namespace BikeShop.UI.Tests
{
    [TestFixture]
    internal class CounterTests
    {
        [Test]
        public void CounterShouldIncrementWhenSelected()
        {
            // Arrange
            using var context = new Bunit.TestContext();
            var counterComponentWrapper = context.RenderComponent<Counter>();
            var element = counterComponentWrapper.Find("p");


            var componentInstance = counterComponentWrapper.Instance;

            var t = componentInstance.currentCountForTest;

            componentInstance.IncrementCountForTest();

            t = componentInstance.currentCountForTest;

            // Act
            counterComponentWrapper.Find("button").Click();
            var elementText = element.TextContent;

            // Assert
            elementText.MarkupMatches("Current count: 1");
        }
    }
}
