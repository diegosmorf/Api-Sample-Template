using Api.Cqrs.Template.Core.Contract.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Api.Sample.Template.Database.Repositories;

namespace Api.Sample.Template.Infrastructure.InjectionModules
{
    public class IoCModuleInfrastructure
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            // Service Bus                        
            
            // Infra - Data            
            services.AddSingleton(typeof(IRepository<>), typeof(SQLRepository<>));
            services.AddSingleton<IUnitOfWork, SQLUnitOfWork>();

        }
    }
}