using Api.Domain.Contracts.Core.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Sample.Template.ApplicationService.ViewModels
{
    public class FundViewModel
    {
        [Key]
        [Required(ErrorMessage = "The Id field is Required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name field is Required")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is Required")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}
