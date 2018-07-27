using Api.Domain.Contracts.Core.Entities;
using Api.Sample.Template.Domain.Commands;
using Api.Sample.Template.Domain.Events;
using System;
using System.Collections.Generic;

namespace Api.Sample.Template.Domain.Model
{
    public class Fund : DomainEntity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public IEnumerable<Account> Accounts { get; protected set; }
        public void Create(CreateFundCommand command)
        {
            Id = Guid.NewGuid();
            Name = command.Name;
            Description = command.Description;
            CreatedDate = DateTime.Now;
            ModifiedBy = "";

            appliedEvents.Add(new FundCreatedEvent(Id, Name, Description, CreatedDate, ModifiedDate, ModifiedBy));
        }

        public void Update(Guid id, string name, string description, string userName)
        {
            Id = id;
            Name = name;
            Description = description;
            ModifiedDate = DateTime.Now;
            ModifiedBy = userName;
        }
    }
}