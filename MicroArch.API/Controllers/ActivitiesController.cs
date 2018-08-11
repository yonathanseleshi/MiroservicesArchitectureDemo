using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroArch.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;


namespace MicroArch.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {

        private readonly IBusClient _busClient;

        public ActivitiesController(IBusClient busClient)
        {
            _busClient = busClient;
        }




       

        // POST activities
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateActivity command)
        {

            command.ID = Guid.NewGuid();
            command.CreatedAtDate = DateTime.UtcNow;

            await _busClient.PublishAsync(command);

            return Accepted($"activities/{command.ID}");

        }

      
    }
}
