namespace IntegrationTests
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;

    /// <summary>
    /// Prepares the application configuration.
    /// </summary>
    public class TestConfigurationFixture : IDisposable
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

        public TestConfigurationFixture()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();

            Configuration = builder.Build();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseSqlServer(ConnectionString);
            DbContextOptions = dbContextOptionsBuilder.Options;
        }

        public void Dispose()
        {
            // do nothing
        }
    }
}
