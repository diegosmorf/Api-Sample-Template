using Api.Sample.Template.WebApi.Server;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Api.Sample.Template.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)                
                .UseStartup<Startup>()
                .Build()
                .Run();
        }    
    }
}
