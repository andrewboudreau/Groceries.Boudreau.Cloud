using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.TestHost;

using Xunit;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace IntegrationTests
{
    public class HomeControllerIntegrationTests //: IClassFixture<TestServerFixture>
    {
        private readonly HttpClient _client;

        //public HomeControllerIntegrationTests(TestServerFixture fixture)
        //{
        //    var foo = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        //    _client = fixture.Client;
        //}

        [Fact]
        public async Task IndexReturns()
        {
            var rootPath = Path.GetFullPath(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "..", "..", "..", "..", "..", "src", "Groceries.Boudreau.Cloud.WebApp"));

            var TestServer = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(rootPath)
                .UseStartup<Groceries.Boudreau.Cloud.Startup>());

            var _client = TestServer.CreateClient();
        

            // Act
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();

            TestServer.Dispose();
            _client.Dispose();
        }
    }
}
