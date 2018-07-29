using Api.Cqrs.Core.Bus;
using Api.Cqrs.Template.Core.Contract.Repository;
using Api.Sample.Template.Dummy.Infrastructure.Bus;
using Api.Sample.Template.Dummy.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Autofac;

namespace Api.Sample.Template.Dummy.Infrastructure.InjectionModules
{
    public class DummyInfraIoCModule : Module
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