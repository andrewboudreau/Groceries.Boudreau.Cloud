﻿namespace IntegrationTests
{
    using Groceries.Boudreau.Cloud.Database;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;

    /// <summary>
    /// Prepares the application configuration.
    /// </summary>
    public class TestShoppingListContextFixture : IDisposable
    {
        public IConfigurationRoot Configuration;

        public string ConnectionString
        {
            get
            {
                return Configuration.GetConnectionString("DefaultConnection");
            }
        }

        public DbContextOptions DbContextOptions { get; set; }

        public TestShoppingListContextFixture()
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();
            
            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseSqlServer(ConnectionString);
            DbContextOptions = dbContextOptionsBuilder.Options;

            using(var context = new ShoppingListContext(DbContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }

        public void Dispose()
        {
            // do nothing
        }

        public ShoppingListContext CreateShoppingListContext()
        {
            return new ShoppingListContext(DbContextOptions);
        }
    }
}
