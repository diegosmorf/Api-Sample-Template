using Api.Cqrs.Core.Bus;
using Api.Cqrs.Core.CommandHandlers;
using Api.Sample.Template.Domain.Commands;
using Api.Sample.Template.Domain.Model;
using Api.Cqrs.Template.Core.Contract.Repository;
using System.Threading.Tasks;

namespace Api.Sample.Template.Domain.CommandHandlers
{
    public class UpdateFundCommandHandler : CommandHandler<Fund>,
        ICommandHandler<UpdateFundCommand, Fund>
    {
        private readonly IRepository<Fund> fundRepository;        

        public UpdateFundCommandHandler(IRepository<Fund> fundRepository, IMessageBus bus):base(bus)
        {
            this.fundRepository = fundRepository;            
        }

        public void Dispose()
        {
            fundRepository.Dispose();
        }        

        public Task<Fund> Handle(UpdateFundCommand command)
        {
            var fund = fundRepository.FindById(command.Id);
            fund.Update(command);
            fundRepository.Update(fund);

            return Task.FromResult(PublishEvent(fund));
        }
    }
}