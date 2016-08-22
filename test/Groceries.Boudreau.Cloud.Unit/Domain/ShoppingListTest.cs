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
            list.ShoppingItems.Add(new ShoppingItem());

            // Assert
            Assert.Equal(1, list.ShoppingItems.Count);
        }
    }
}
