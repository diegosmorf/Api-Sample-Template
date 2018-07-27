using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace Api.Sample.Template.Integration.Tests.Controllers
{
    public class SimpleControllerTest : IDisposable
    {
        protected readonly TestServer server;
        protected readonly HttpClient client;

        public SimpleControllerTest()
        {
            // Arrange
            server = new TestServer(new WebHostBuilder().UseStartup<StartupAppForTests>());
            client = server.CreateClient();
        }


        public void Dispose()
        {
            client.Dispose();
            server.Dispose();
        }
    }
}