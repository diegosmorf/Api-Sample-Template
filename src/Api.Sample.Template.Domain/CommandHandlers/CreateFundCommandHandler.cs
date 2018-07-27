using Api.Cqrs.Core.Bus;
using Api.Cqrs.Core.CommandHandlers;
using Api.Cqrs.Core.Notifications;
using Api.Sample.Template.Domain.Commands;
using Api.Sample.Template.Domain.Events;
using Api.Sample.Template.Domain.Model;
using Api.Cqrs.Template.Core.Contract.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Sample.Template.Domain.CommandHandlers
{
    public class CreateFundCommandHandler : CommandHandler<Fund>,  IRequestHandler<CreateFundCommand, Fund>
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

        public Task<Fund> Handle(CreateFundCommand command, CancellationToken cancellationToken)
        {
            var fund = new Fund();
            fund.Create(command);
            fundRepository.Insert(fund);

            return Task.FromResult(PublishEvent(fund));            
        }
    }
}