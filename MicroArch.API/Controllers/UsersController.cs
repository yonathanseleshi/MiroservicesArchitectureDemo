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
    public class UsersController : ControllerBase
    {

        private readonly IBusClient _busClient;

        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }




      

        // POST users/register
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {

            await _busClient.PublishAsync(command);

            return Accepted();

        }
        
    }
}
