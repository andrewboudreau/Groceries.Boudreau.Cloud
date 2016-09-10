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
                .Ignore(x => x.SHA256);

            modelBuilder
                .Entity<ShoppingItem>()
                .Ignore(x => x.SHA256);

            base.OnModelCreating(modelBuilder);
        }
    }
}
