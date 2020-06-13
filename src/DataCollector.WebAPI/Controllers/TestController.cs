using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCollector.WebAPI.Models.Api;
using DataCollector.WebAPI.Models.Entities;
using DataCollector.WebAPI.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataCollector.WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUserService _userService;
        public TestController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("find")]
        public async Task<IActionResult> Find(string name)
        {
            //var filter = new UserFilterModel()
            //{
            //    CommonInfo = new CommonInfoFilteModel() { FirstName = name },
            //    Contacts = new Contacts(),
            //    Education = new Education(),
            //    Interest = new InterestFilteModel(),
            //    Сareer = new Career(),
            //    Activity = new ActivityFilteModel(),
            //    LifePositions = new LifePositions()
            //};

            //var users = await _userService.GetAsync(filter);

            var user = await _userService.GetByIdAsync("5d6276970df4710c10f21e6e");

            return Ok(user);
        }
    }
}