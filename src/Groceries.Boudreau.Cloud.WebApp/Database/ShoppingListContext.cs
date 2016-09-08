using Groceries.Boudreau.Cloud.Domain;

using Microsoft.EntityFrameworkCore;

namespace Groceries.Boudreau.Cloud.Database
{
    public class ShoppingListContext : DbContext
    {
        public ShoppingListContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public DbSet<ShoppingItem> ShoppingItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ShoppingList>()
                .Ignore(x => x.CryptographicHash);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                System.Diagnostics.Debug.WriteLine($"DbContext being configured on demand");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
