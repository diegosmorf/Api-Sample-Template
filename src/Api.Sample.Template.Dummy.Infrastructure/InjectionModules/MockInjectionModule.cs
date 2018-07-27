using Api.Cqrs.Core.Bus;
using Api.Cqrs.Core.Events;
using Api.Cqrs.Template.Core.Contract.Repository;
using Api.Sample.Template.ApplicationService.Interfaces;
using Api.Sample.Template.ApplicationService.Services;
using Api.Sample.Template.Domain.CommandHandlers;
using Api.Sample.Template.Domain.Commands;
using Api.Sample.Template.Domain.EventHandlers;
using Api.Sample.Template.Domain.Events;
using Api.Sample.Template.Domain.Model;
using Api.Sample.Template.Dummy.Infrastructure.Bus;
using Api.Sample.Template.Dummy.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Api.Cqrs.Core.CommandHandlers;

namespace Api.Sample.Template.Dummy.Infrastructure.InjectionModules
{
    public class MockInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            // ASP.NET HttpContext dependency
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            // Service Bus            
            builder.RegisterType<InMemoryMessageBus>().As<IMessageBus>();

            // Application            
            builder.RegisterType<FundAppService>().As<IFundAppService>();

            // Domain - EventsHandlers                        
            builder.RegisterType<FundCreatedEventHandler>().As<IEventHandler<FundCreatedEvent>>();

            // Domain - CommandsHandlers
            builder.RegisterType<CreateFundCommandHandler>().As<ICommandHandler<CreateFundCommand, Fund>>();

            // Domain - Commands
            builder.RegisterType<CreateFundCommand>().AsImplementedInterfaces();

            // Domain - Events
            builder.RegisterType<FundCreatedEvent>().AsImplementedInterfaces();

            // Infra - Data   
            builder.RegisterType<InMemoryUnitOfWork>().As<IUnitOfWork>();

            builder
                .RegisterGeneric(typeof(InMemoryRepository<>))
                .AsImplementedInterfaces()
                .SingleInstance();            
        }
    }
}