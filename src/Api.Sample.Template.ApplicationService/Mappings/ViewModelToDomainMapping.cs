using AutoMapper;
using Api.Sample.Template.ApplicationService.ViewModels;
using Api.Sample.Template.Domain.Commands;

namespace Api.Sample.Template.ApplicationService.AutoMapper
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<FundViewModel, CreateFundCommand>()
                .ConstructUsing(model => new CreateFundCommand(model.Name, model.Description));
            
        }
    }
}
