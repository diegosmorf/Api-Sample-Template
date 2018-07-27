using Api.Cqrs.Core.Bus;
using Api.Cqrs.Core.CommandHandlers;
using Api.Sample.Template.Domain.Commands;
using Api.Sample.Template.Domain.Model;
using Api.Cqrs.Template.Core.Contract.Repository;
using System.Threading.Tasks;

namespace Api.Sample.Template.Domain.CommandHandlers
{
    public class CreateFundCommandHandler : CommandHandler<Fund>,
        ICommandHandler<CreateFundCommand, Fund>
    {
        private readonly IRepository<Fund> fundRepository;        

        public CreateFundCommandHandler(IRepository<Fund> fundRepository, IMessageBus bus):base(bus)
        {
            this.fundRepository = fundRepository;            
        }

        public void Dispose()
        {
            fundRepository.Dispose();
        }        

        public Task<Fund> Handle(CreateFundCommand command)
        {
            var fund = new Fund();
            fund.Create(command);
            fundRepository.Insert(fund);

            return Task.FromResult(PublishEvent(fund));
        }
    }
}