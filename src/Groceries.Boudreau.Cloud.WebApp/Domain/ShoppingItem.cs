using System.Security.Cryptography;
using System.Text;

namespace Groceries.Boudreau.Cloud.Domain
{
    /// <summary>
    /// Any item to shop
    /// </summary>
    public class ShoppingItem
    {
        private readonly SHA256 sha256Provider = System.Security.Cryptography.SHA256.Create();

        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public bool IsChecked { get; set; }

        public string SHA256
        {
            get
            {
                var data = $"{Name}{Quantity}{IsChecked}";
                var hash = sha256Provider.ComputeHash(Encoding.ASCII.GetBytes(data));

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
