namespace IntegrationTests
{
    using Groceries.Boudreau.Cloud.Domain;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    using Xunit;

    public class ShoppingListControllerIntegrationTests : IClassFixture<TestServerFixture>
    {
        private readonly HttpClient _client;

        public ShoppingListControllerIntegrationTests(TestServerFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Get()
        {
            // Act
            var response = await _client.GetAsync("/api/shoppinglist");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Get_SupportsJson()
        {
            // Act
            _client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _client.GetAsync("/api/shoppinglist");
           
            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.NotNull(Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShoppingList>>(content));
        }

        [Fact]
        public async Task Post()
        {
            // Act
            _client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var shoppingList = new ShoppingList();
            shoppingList.Name = TestName();
            shoppingList.Items.Add(new ShoppingItem() { Name = TestName("ShoppingItem"), Quantity = 1 });

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(shoppingList);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/shoppinglist", requestContent);
            
            // Assert
            response.EnsureSuccessStatusCode();
            
            var query = await _client.GetAsync("/api/shoppinglist");
            var queryContent = await query.Content.ReadAsStringAsync();

            Assert.NotNull(Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShoppingList>>(queryContent));
        }

        private string TestName(string prefix = "Test", int length = 8)
        {
            return $"{prefix}-{Guid.NewGuid().ToString().Replace("-", "").Substring(0, length)}";
        }
    }
}
