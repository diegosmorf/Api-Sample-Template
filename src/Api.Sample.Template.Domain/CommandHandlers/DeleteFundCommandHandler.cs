using Api.Cqrs.Core.Bus;
using Api.Cqrs.Core.CommandHandlers;
using Api.Sample.Template.Domain.Commands;
using Api.Sample.Template.Domain.Model;
using Api.Cqrs.Template.Core.Contract.Repository;
using System.Threading.Tasks;

namespace Api.Sample.Template.Domain.CommandHandlers
{
    public class DeleteFundCommandHandler : CommandHandler<Fund>,
        ICommandHandler<DeleteFundCommand, Fund>
    {
        private readonly IRepository<Fund> fundRepository;

        public DeleteFundCommandHandler(IRepository<Fund> fundRepository, IMessageBus bus) : base(bus)
        {
            this.fundRepository = fundRepository;
        }

        public void Dispose()
        {
            fundRepository.Dispose();
        }

        public Task<Fund> Handle(DeleteFundCommand command)
        {
            var fund = fundRepository.FindById(command.Id);
            fund.Delete(command);
            fundRepository.Delete(command.Id);

            return Task.FromResult(PublishEvent(fund));
        }
    }
}