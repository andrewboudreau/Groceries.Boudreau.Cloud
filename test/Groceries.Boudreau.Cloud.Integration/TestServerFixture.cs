namespace IntegrationTests
{
    using System;
    using System.Net.Http;
    using System.IO;

    using Microsoft.AspNetCore.TestHost;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.PlatformAbstractions;

    /// <summary>
    /// TestFixture for Creating and Destroying <see cref="Groceries.Boudreau.Cloud.Program"/> web server. Also provides an <see cref="HttpClient"/>.
    /// </summary>
    public class TestServerFixture : IDisposable
    {
        public TestServer TestServer { get; }

        /// <summary>
        /// HttpClient ready for integration testing <see cref="Groceries.Boudreau.Cloud.Program"/>.
        /// </summary>
        public HttpClient Client { get; }

        public TestServerFixture()
        {
            var webAppContentRoot = Path.GetFullPath(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "..", "..", "..", "..", "..", "src", "Groceries.Boudreau.Cloud.WebApp"));

            var TestServer = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(webAppContentRoot)
                .UseStartup<Groceries.Boudreau.Cloud.Startup>());
            
            Client = TestServer.CreateClient();
        }

        public void Dispose()
        {
            TestServer.Dispose();
            Client.Dispose();
        }
    }
}
