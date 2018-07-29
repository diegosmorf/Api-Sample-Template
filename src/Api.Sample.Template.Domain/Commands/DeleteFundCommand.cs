using Api.Cqrs.Core.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Sample.Template.Domain.Commands
{
    public class DeleteFundCommand : Command
    {
        public DeleteFundCommand(Guid id, string senderUserName)
        {
            Id = id;
            SenderUserName = senderUserName;
        }

        [Key]
        [Required(ErrorMessage = "The Id field is Required")]
        public Guid Id { get; protected set; }

    }
}
