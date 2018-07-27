using Api.Sample.Template.Infrastructure.Database.Repositories;
using Api.Cqrs.Template.Core.Contract.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Sample.Template.Infrastructure.InjectionModules
{
    public class InfraInjectionModule
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Service Bus
            
            // Application
            
            // Domain - Events
            
            // Domain - Commands
            
            // Infra - Data            
            services.AddSingleton(typeof(IRepository<>), typeof(SQLRepository<>));
            services.AddSingleton<IUnitOfWork, SQLUnitOfWork>();

        }
    }
}