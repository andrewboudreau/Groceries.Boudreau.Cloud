namespace UnitTests
{
    using Groceries.Boudreau.Cloud.Controllers;

    using Microsoft.AspNetCore.Mvc;

    using Xunit;

    public class HomeControllerTest
    {
        [Fact]
        public void IndexSetsViewDataMessage()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("Groceries.Boudreau.Cloud", result.ViewData["Message"]);
        }
    }
}
