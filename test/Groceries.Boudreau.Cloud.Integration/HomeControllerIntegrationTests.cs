namespace IntegrationTests
{
    using System.Net.Http;
    
    using Xunit;

    public class HomeControllerIntegrationTests : IClassFixture<TestServerFixture>
    {
        private readonly HttpClient _client;

        public HomeControllerIntegrationTests(TestServerFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async void IndexReturns()
        {
            // Act
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
