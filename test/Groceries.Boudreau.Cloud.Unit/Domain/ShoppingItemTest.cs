namespace UnitTests
{
    using Groceries.Boudreau.Cloud.Domain;
    using System;
    using Xunit;

    public class ShoppingItemTest
    {
        [Fact]
        public void SHA256_IsUnique() 
        {
            // Arrange
            ShoppingItem item = new ShoppingItem();
            item.Name = Guid.NewGuid().ToString();

            // Act
            var hash = item.SHA256;
            item.Name = Guid.NewGuid().ToString();

            // Assert
            Assert.NotEqual(hash, item.SHA256);
        }
    }
}
