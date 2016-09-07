namespace Groceries.Boudreau.Cloud.Domain
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using System.Security.Cryptography;


    /// <summary>
    /// A list of items
    /// </summary>
    public class ShoppingList
    {
        private readonly SHA256 sha256Provider = SHA256.Create();

        public ShoppingList()
        {
            Items = new Collection<ShoppingItem>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public ICollection<ShoppingItem> Items { get; set; }

        /// <summary>
        /// Unique for the list
        /// </summary>
        public string CryptographicHash
        {
            get
            {
                int bits = 1 * 256;
                int bytes = bits / 8;
                
                byte[] data = new byte[bits / 8];
                
                return sha256Provider.ComputeHash(data).ToString();
            }
        }
    }
}