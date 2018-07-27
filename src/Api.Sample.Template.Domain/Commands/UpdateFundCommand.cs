using Api.Cqrs.Core.Commands;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Sample.Template.Domain.Commands
{
    public class UpdateFundCommand : Command
    {       
        public UpdateFundCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        [Key]
        [Required(ErrorMessage = "The Id field is Required")]
        public Guid Id { get; protected set; }

        [Required(ErrorMessage = "The Name field is Required")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Name")]
        public string Name { get; protected set; }

        [Required(ErrorMessage = "The Description field is Required")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Description")]
        public string Description { get; protected set; }
    }
}
