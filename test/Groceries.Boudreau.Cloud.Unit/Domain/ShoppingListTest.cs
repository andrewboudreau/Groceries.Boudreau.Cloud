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


    }
}
