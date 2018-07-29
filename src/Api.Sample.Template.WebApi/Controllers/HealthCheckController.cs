using Api.Cqrs.Core.Bus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Sample.Template.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class HealthCheckController : Controller
    {
        private readonly IMessageBus bus;

        protected HealthCheckController(IMessageBus bus) 
        {
            this.bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.Run(() =>
            {
                try
                {
                    //TODO: Test DbConnection and important external dependencies resources

                    return Ok("Status OK");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { ex.Message });
                }
            });
        }
    }
}
