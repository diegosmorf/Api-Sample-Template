using Api.Sample.Template.Dummy.Infrastructure.InjectionModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Api.Sample.Template.Dummy.ApplicationService.InjectionModules;
using Api.Sample.Template.Integration.Tests.Configurations;

namespace Api.Sample.Template.Integration.Tests
{
    public class StartupAppForTests
    {
        public IConfigurationRoot Configuration { get; }

        public StartupAppForTests(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // IoC Container Module Registration
            builder.RegisterModule(new AppServiceIoCModule());
            builder.RegisterModule(new DummyInfraIoCModule());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //TODO: Register Database Context

            services.AddMvc();
            services.AddAutoMapperSetup();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              ILoggerFactory loggerFactory,
                              IHttpContextAccessor accessor)
        {            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}