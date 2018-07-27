using Api.Cqrs.Core.Commands;
using Api.Sample.Template.Domain.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Sample.Template.Domain.Commands
{
    public class CreateFundCommand : Command
    {
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

        public CreateFundCommand(string name, string description)
        {            
            Name = name;
            Description = description;
        }
    }
}
