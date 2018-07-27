using Api.Sample.Template.ApplicationService.AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Sample.Template.WebApi.Configurations
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMapping());
                cfg.AddProfile(new ViewModelToDomainMapping());
            });
        }
    }
}