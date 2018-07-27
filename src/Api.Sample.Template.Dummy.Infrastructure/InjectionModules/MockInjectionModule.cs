using Api.Cqrs.Core.Bus;
using Api.Cqrs.Core.Notifications;
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
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Sample.Template.Dummy.Infrastructure.InjectionModules
{
    public class MockInjectionModule
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Service Bus
            services.AddScoped<IMessageBus, InMemoryMessageBus>();

            // Application
            services.AddScoped<IFundAppService, FundAppService>();

            // Domain - EventsHandlers
            //services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<FundCreatedEvent>, FundCreatedEventHandler>();

            // Domain - CommandsHandlers
            services.AddScoped<IRequestHandler<CreateFundCommand,Fund>, CreateFundCommandHandler>();

            // Domain - Commands
            services.AddScoped<IRequest<Fund>, CreateFundCommand>();

            // Infra - Data            
            services.AddSingleton<IRepository<Fund>, InMemoryRepository<Fund>>();
            services.AddSingleton<IUnitOfWork, InMemoryUnitOfWork>();

        }
    }
}