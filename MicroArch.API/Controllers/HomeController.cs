using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MicroArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET api/values
        [HttpGet("")]
        public ActionResult<IEnumerable<string>> Get() => Content("Hello from MicroArch API!");

    }
}
