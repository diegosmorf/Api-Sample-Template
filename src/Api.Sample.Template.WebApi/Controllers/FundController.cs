using System;
using Api.Cqrs.Core.Bus;
using Api.Cqrs.Core.Notifications;
using Api.Sample.Template.ApplicationService.Interfaces;
using Api.Sample.Template.ApplicationService.ViewModels;
using Api.Sample.Template.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Sample.Template.WebApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class FundController : Controller
    {
        private readonly IFundAppService fundAppService;
        private readonly IMessageBus bus;

        public FundController(
            IFundAppService fundAppService,
            IMessageBus bus)
        {
            this.fundAppService = fundAppService;
            this.bus = bus;
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(fundAppService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(fundAppService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateFundCommand command)
        {
            return Ok(fundAppService.Create(command));
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody]UpdateFundCommand command)
        {
            return Ok(fundAppService.Update(command));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            return Ok(fundAppService.Delete(id));
        }
    }
}
