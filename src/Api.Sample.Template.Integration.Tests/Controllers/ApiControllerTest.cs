using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.IO;
using Autofac.Extensions.DependencyInjection;
using System.Net.Http;

namespace Api.Sample.Template.Integration.Tests.Controllers
{
    public class ApiControllerTest : IDisposable
    {
        protected readonly TestServer server;
        protected readonly HttpClient client;

        public ApiControllerTest()
        {
            // Arrange
            server = new TestServer(
                new WebHostBuilder()
                .ConfigureServices(s => s.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<StartupAppForTests>());
            client = server.CreateClient();
        }


        public void Dispose()
        {
            client.Dispose();
            server.Dispose();
        }
    }
}