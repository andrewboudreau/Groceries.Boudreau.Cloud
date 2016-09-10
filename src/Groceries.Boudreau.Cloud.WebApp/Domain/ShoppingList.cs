namespace Groceries.Boudreau.Cloud.Domain
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;


    /// <summary>
    /// A list of items
    /// </summary>
    public class ShoppingList
    {
        private readonly SHA256 sha256Provider = System.Security.Cryptography.SHA256.Create();

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
        public string SHA256
        {
            get
            {
                var sb = new StringBuilder(Name);
                foreach (var item in Items)
                {
                    sb.Append(item.SHA256);
                }

                byte[] data = Encoding.ASCII.GetBytes(sb.ToString());
                var hash = sha256Provider.ComputeHash(data);

                var stringBuilder = new StringBuilder();
                foreach (byte b in hash)
                {
                    stringBuilder.AppendFormat("{0:X2}", b);
                }

                return stringBuilder.ToString();
            }
        }
    }
}