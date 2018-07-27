using System;
using System.Collections.Generic;
using Api.Sample.Template.ApplicationService.ViewModels;
using Api.Sample.Template.Domain.Commands;

namespace Api.Sample.Template.ApplicationService.Interfaces
{
    public interface IFundAppService
    {
        FundViewModel Create(CreateFundCommand model);
        FundViewModel Update(UpdateFundCommand model);        
        bool Delete(Guid id);
        IEnumerable<FundViewModel> GetAll();
        FundViewModel GetById(Guid id);       
        
    }
}
