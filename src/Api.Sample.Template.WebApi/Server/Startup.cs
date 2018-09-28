﻿using Api.Sample.Template.Mock.Infrastructure.InjectionModules;
using Api.Sample.Template.WebApi.Configurations;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Autofac;
using Api.Sample.Template.Mock.ApplicationService.InjectionModules;
using Api.Sample.Template.Database.Migrations;

namespace Api.Sample.Template.WebApi.Server
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
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
            builder.RegisterModule(new IoCModuleApplicationService());
            builder.RegisterModule(new IoCModuleMockInfra());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //TODO: Register Database Context

            services.AddMvc();
            //services.AddAutofac();
            services.AddAutoMapperSetup();
            
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info { Title = "Api.Sample.Template Swagger Documentation", Version = "1.0.0" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              ILoggerFactory loggerFactory,
                              IHttpContextAccessor accessor)
        {
            //
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            //Enable Cors
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod());

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger(c => { c.RouteTemplate = "swagger/{documentName}/swagger.json"; });

            // Enable middleware to serve swagger-ui assets(HTML, JS, CSS etc.)
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Api.Sample.Template Documentation");
            });

            //Execute Database Migration
            //UpdateDatabase("");
        }

        private static void UpdateDatabase(string connectionString)
        {
            var serviceProvider = new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(M00000_EmptyDatabase).Assembly)
                    .For.Migrations())
                            .AddLogging(lb => lb.AddFluentMigratorConsole())
                            .BuildServiceProvider(false);

            using (var scope = serviceProvider.CreateScope())
            {
                // Instantiate the runner
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

                // Execute the migrations
                runner.MigrateUp();
            }
        }
    }
}
