using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Groceries.Boudreau.Cloud.Database;

namespace Groceries.Boudreau.Cloud.WebApp.Migrations
{
    [DbContext(typeof(ShoppingListContext))]
    partial class ShoppingListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Groceries.Boudreau.Cloud.Domain.ShoppingItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsChecked");

                    b.Property<string>("Name");

                    b.Property<int>("Quantity");

                    b.Property<int?>("ShoppingListId");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("ShoppingItems");
                });

            modelBuilder.Entity("Groceries.Boudreau.Cloud.Domain.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("Groceries.Boudreau.Cloud.Domain.ShoppingItem", b =>
                {
                    b.HasOne("Groceries.Boudreau.Cloud.Domain.ShoppingList")
                        .WithMany("Items")
                        .HasForeignKey("ShoppingListId");
                });
        }
    }
}
