using Api.Cqrs.Core.Bus;
using Api.Cqrs.Core.Notifications;
using Api.Sample.Template.ApplicationService.Interfaces;
using Api.Sample.Template.ApplicationService.Services;
using Api.Sample.Template.Domain.EventHandlers;
using Api.Sample.Template.Domain.Events;
using Api.Sample.Template.Infrastructure.Database.Repositories;
using Api.Cqrs.Template.Core.Contract.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Api.Sample.Template.Infrastructure.Bus;
using Api.Sample.Template.Domain.Commands;
using Api.Sample.Template.Domain.CommandHandlers;

namespace Api.Sample.Template.Infrastructure.InjectionModules
{
    public class InfraInjectionModule
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Service Bus
            services.AddScoped<IMessageBus, AzureMessageBus>();

            // Application
            services.AddScoped<IFundAppService, FundAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<FundCreatedEvent>, FundCreatedEventHandler>();

            // Domain - Commands
            //services.AddScoped<IRequestHandler<CreateFundCommand>, CreateFundCommandHandler>();

            // Infra - Data            
            services.AddSingleton(typeof(IRepository<>), typeof(SQLRepository<>));
            services.AddSingleton<IUnitOfWork, SQLUnitOfWork>();

        }
    }
}