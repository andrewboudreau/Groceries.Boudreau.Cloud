using System;
using System.Linq;
using System.Threading.Tasks;

using Groceries.Boudreau.Cloud.Domain;

using IntegrationTests;

using Xunit;

namespace Groceries.Boudreau.Cloud.Integration.EntityFramework
{
    public class ShoppingItemTests : IClassFixture<TestShoppingListContextFixture>
    {
        private TestShoppingListContextFixture config;

        public ShoppingItemTests(TestShoppingListContextFixture config)
        {
            this.config = config;
        }

        [Fact]
        public async Task CreateShoppingItemTest()
        {
            // Arrange
            ShoppingItem item;
            using (var context = config.CreateShoppingListContext())
            {
                item = new ShoppingItem() { Name = Guid.NewGuid().ToString() };
                context.ShoppingItems.Add(item);
                await context.SaveChangesAsync();
            }

            // Assert
            using (var context = config.CreateShoppingListContext())
            {
                var newItem = context.ShoppingItems.First(x => x.Id == item.Id);

                Assert.NotNull(newItem);
                Assert.Equal(item.Name, newItem.Name);
            }
        }

        [Fact]
        public void ReadShoppingItemsTest()
        {
            // Arrange
            using (var context = config.CreateShoppingListContext())
            {
                // Act
                var items = context.ShoppingItems.ToList();

                // Assert
                Assert.NotNull(items);
            }
        }
    }
}
