using Groceries.Boudreau.Cloud.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Groceries.Boudreau.Cloud.Integration.EntityFramework
{
    public class ShoppingListTests
    {
        [Fact]
        public async Task CreateShoppingListTest()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection"));

            Console.Out.WriteLine(Environment.GetEnvironmentVariable("DefaultConnection"));

            var context = new ShoppingListContext(optionsBuilder.Options);

            // Act
            context.ShoppingItems.Add(new Domain.ShoppingItem() { Name = Guid.NewGuid().ToString() });
            await context.SaveChangesAsync();

            // Assert
            Assert.True(true);
        }
    }
}
