namespace IntegrationTests
{
    using System;
    using System.Net.Http;

    using Groceries.Boudreau.Cloud;

    using Microsoft.AspNet.TestHost;

    public class TestServerFixture : IDisposable
    {
        public TestServer TestServer { get; }

        public HttpClient Client { get; }

        public TestServerFixture()
        {
            TestServer = new TestServer(TestServer.CreateBuilder().UseStartup<Startup>());
            Client = TestServer.CreateClient();
        }

        public void Dispose()
        {
            TestServer.Dispose();
            Client.Dispose();
        }
    }
}
