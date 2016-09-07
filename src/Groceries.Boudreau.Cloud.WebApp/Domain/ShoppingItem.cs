namespace Groceries.Boudreau.Cloud.Domain
{
    /// <summary>
    /// Any item to shop
    /// </summary>
    public class ShoppingItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public bool IsChecked { get; set; }
    }
}
