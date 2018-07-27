using AutoMapper;
using Api.Sample.Template.ApplicationService.ViewModels;
using Api.Sample.Template.Domain.Model;

namespace Api.Sample.Template.ApplicationService.AutoMapper
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Fund, FundViewModel>();
        }
    }
}
