using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataCollector.WebAPI.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = "my")]
        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}