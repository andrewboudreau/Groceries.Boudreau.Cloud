namespace UnitTests
{
    using Groceries.Boudreau.Cloud.Domain;

    using Xunit;

    public class ShoppingListTest
    {
        [Fact]
        public void CanAddItem() 
        {
            // Arrange
            ShoppingList list = new ShoppingList();

            // Act
            list.Items.Add(new ShoppingItem());

            // Assert
            Assert.Equal(1, list.Items.Count);
        }

        [Fact]
        public void CalculateSha256_IsUnique()
        {
            // Arrange
            var list = new ShoppingList();
            list.Name = "ShoppingList_1";

            list.Items.Add(new ShoppingItem() { Name = "ShoppingItem_1" });
            
            // Act
            var hash = list.SHA256;
            list.Items.Add(new ShoppingItem() { Name = "ShoppingItem_2" });

            // Assert
            Assert.NotEqual(hash, list.SHA256);
        }
    }
}
