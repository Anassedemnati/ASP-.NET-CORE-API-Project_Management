using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api_pract.Data.Services;
using web_api_pract.Data.ViewModels;

namespace web_api_pract.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevloperController : ControllerBase
    {
        public DevloperService _devloperService;

        public DevloperController(DevloperService devloperService)
        {
            _devloperService = devloperService;
        }
        [HttpPost("add-devloper")]
        public IActionResult AddManager([FromBody] DevloperVM devloper)
        {
            _devloperService.AddDevloper(devloper);
            return Ok();
        }
        [HttpGet("get-devloper-whith-projects-by-id/{id}")]
        public IActionResult GetDevloperWhithProject(int id)
        {
            var _respensee = _devloperService.GetDevloperWithProjects(id);
            return Ok(_respensee);
        }
    }
}
