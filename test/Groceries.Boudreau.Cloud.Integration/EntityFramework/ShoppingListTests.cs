using Groceries.Boudreau.Cloud.Database;
using IntegrationTests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Groceries.Boudreau.Cloud.Integration.EntityFramework
{
    public class ShoppingListTests : IClassFixture<TestConfigurationFixture>
    {
        private TestConfigurationFixture config;

        public ShoppingListTests(TestConfigurationFixture config)
        {
            this.config = config;
        }

        [Fact]
        public async Task CreateShoppingListTest()
        {
            // Arrange
            var context = new ShoppingListContext(config.DbContextOptions);

            // Act
            context.ShoppingItems.Add(new Domain.ShoppingItem() { Name = Guid.NewGuid().ToString() });
            await context.SaveChangesAsync();

            // Assert
            Assert.True(true);
        }
    }
}
