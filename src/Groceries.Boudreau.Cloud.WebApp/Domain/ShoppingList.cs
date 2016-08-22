namespace Groceries.Boudreau.Cloud.Domain
{
    using System.Collections.Generic;

    public class ShoppingList
    {
        public ShoppingList()
        {
            ShoppingItems = new List<ShoppingItem>();
        }

        public List<ShoppingItem> ShoppingItems { get; set; }
    }
}