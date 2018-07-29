using Api.Sample.Template.WebApi.Server;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Autofac.Extensions.DependencyInjection;

namespace Api.Sample.Template.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(s => s.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()                
                .Build()
                .Run();
        }    
    }
}
