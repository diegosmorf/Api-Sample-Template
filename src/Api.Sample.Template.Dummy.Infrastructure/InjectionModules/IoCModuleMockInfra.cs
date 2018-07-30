using Api.Cqrs.Core.Bus;
using Api.Cqrs.Template.Core.Contract.Repository;
using Api.Sample.Template.Mock.Infrastructure.Bus;
using Api.Sample.Template.Mock.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Autofac;

namespace Api.Sample.Template.Mock.Infrastructure.InjectionModules
{
    public class IoCModuleMockInfra : Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            // ASP.NET HttpContext dependency
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            // Service Bus            
            builder.RegisterType<InMemoryMessageBus>().As<IMessageBus>();
            
            // Infra - Data   
            builder.RegisterType<InMemoryUnitOfWork>().As<IUnitOfWork>();

            builder
                .RegisterGeneric(typeof(InMemoryRepository<>))
                .AsImplementedInterfaces()
                .SingleInstance();            
        }
    }
}