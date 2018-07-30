using Api.Cqrs.Core.Events;
using Api.Sample.Template.ApplicationService.Interfaces;
using Api.Sample.Template.ApplicationService.Services;
using Api.Sample.Template.Domain.CommandHandlers;
using Api.Sample.Template.Domain.Commands;
using Api.Sample.Template.Domain.EventHandlers;
using Api.Sample.Template.Domain.Events;
using Api.Sample.Template.Domain.Model;
using Autofac;
using Api.Cqrs.Core.CommandHandlers;

namespace Api.Sample.Template.Dummy.ApplicationService.InjectionModules
{
    public class IoCModuleApplicationService : Module
    {
        protected override void Load(ContainerBuilder builder)
        {      
            // Application            
            builder.RegisterType<FundAppService>().As<IFundAppService>();

            // Domain - EventsHandlers                        
            builder.RegisterType<FundCreatedEventHandler>().As<IEventHandler<FundCreatedEvent>>();            

            // Domain - CommandsHandlers
            builder.RegisterType<CreateFundCommandHandler>().As<ICommandHandler<CreateFundCommand, Fund>>();
            builder.RegisterType<UpdateFundCommandHandler>().As<ICommandHandler<UpdateFundCommand, Fund>>();
            builder.RegisterType<DeleteFundCommandHandler>().As<ICommandHandler<DeleteFundCommand, Fund>>();            

            // Domain - Commands
            builder.RegisterType<CreateFundCommand>().AsImplementedInterfaces();
            builder.RegisterType<UpdateFundCommand>().AsImplementedInterfaces();
            builder.RegisterType<DeleteFundCommand>().AsImplementedInterfaces();

            // Domain - Events
            builder.RegisterType<FundCreatedEvent>().AsImplementedInterfaces();
                    
        }
    }
}