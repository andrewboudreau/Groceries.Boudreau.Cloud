﻿using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
namespace IntegrationTests
{
    using System.Threading.Tasks;

    using Xunit;

    public class HomeControllerIntegrationTests : IClassFixture<TestServerFixture>
    {
        private readonly HttpClient _client;

        public HomeControllerIntegrationTests(TestServerFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task IndexReturns()
        {
            // Act
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
