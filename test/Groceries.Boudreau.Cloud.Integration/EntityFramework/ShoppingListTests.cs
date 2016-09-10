using System;
using System.Threading.Tasks;

using IntegrationTests;

using Xunit;
using Groceries.Boudreau.Cloud.Domain;
using System.Linq;

namespace Groceries.Boudreau.Cloud.Integration.EntityFramework
{
    public class ShoppingListTests : IClassFixture<TestShoppingListContextFixture>
    {
        private TestShoppingListContextFixture config;

        public ShoppingListTests(TestShoppingListContextFixture config)
        {
            this.config = config;
        }

        [Fact]
        public async Task CreateShoppingListTest()
        {
            // Arrange
            using (var context = config.CreateShoppingListContext())
            {
                // Act
                context.ShoppingItems.Add(new Domain.ShoppingItem() { Name = Guid.NewGuid().ToString() });
                await context.SaveChangesAsync();
            }
                        
            // Assert
            Assert.True(true);
        }

        [Fact]
        public void ReadShoppingListTest()
        {
            // Arrange
            using (var context = config.CreateShoppingListContext())
            {
                // Act
                var items = context.Set<ShoppingList>().ToList();
                Assert.NotNull(items);
            }

            // Assert
            Assert.True(true);
        }
    }
}
