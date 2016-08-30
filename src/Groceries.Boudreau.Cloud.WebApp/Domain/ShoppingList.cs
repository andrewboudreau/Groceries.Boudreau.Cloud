namespace Groceries.Boudreau.Cloud.Domain
{
    using System.Collections.Generic;
    
    /// <summary>
    /// A list of items
    /// </summary>
    public class ShoppingList
    {
        public ShoppingList()
        {
            ShoppingItems = new List<ShoppingItem>();
        }

        public string Name { get; set; }

        public List<ShoppingItem> ShoppingItems { get; set; }
    }
}