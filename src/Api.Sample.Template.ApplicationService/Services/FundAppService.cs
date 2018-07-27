using System;
using System.Collections.Generic;
using AutoMapper;
using Api.Sample.Template.ApplicationService.ViewModels;
using Api.Sample.Template.ApplicationService.Interfaces;
using Api.Sample.Template.Domain.Model;
using Api.Cqrs.Core.Bus;
using Api.Sample.Template.Domain.Commands;
using Api.Cqrs.Template.Core.Contract.Repository;

namespace Api.Sample.Template.ApplicationService.Services
{
    public class FundAppService : IFundAppService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Fund> fundRepository;
        private readonly IMessageBus bus;

        public FundAppService(IMapper mapper,
                                  IRepository<Fund> fundRepository,
                                  IMessageBus bus)
        {
            this.mapper = mapper;
            this.fundRepository = fundRepository;
            this.bus = bus;
        }

        public IEnumerable<FundViewModel> GetAll()
        {
            return mapper.Map<IEnumerable<FundViewModel>>(fundRepository.All());
        }

        public FundViewModel GetById(Guid id)
        {
            return mapper.Map<FundViewModel>(fundRepository.FindById(id));
        }

        public FundViewModel Create(CreateFundCommand command)
        {
            return mapper
                    .Map<FundViewModel>(
                        bus.DispatchCommand<CreateFundCommand,Fund>(command).Result);
        }

        public FundViewModel Update(UpdateFundCommand command)
        {
            return mapper
                .Map<FundViewModel>(
                    bus.DispatchCommand<UpdateFundCommand, Fund>(command).Result);
        }

        public bool Delete(Guid id)
        {
            fundRepository.Delete(id);
            return true;
        }
    }
}
