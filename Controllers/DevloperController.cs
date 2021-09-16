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
        [HttpGet("get-all-devlopers")]
        public IActionResult GetAllDevlopers()
        {
            var _devlopers = _devloperService.GetAllDevloper();
            return Ok(_devlopers);
        }
        
        [HttpGet("get-devloper-whith-projects-by-id/{id}")]
        public IActionResult GetDevloperWhithProject(int id)
        {
            var _respensee = _devloperService.GetDevloperWithProjects(id);
            return Ok(_respensee);
        }
        [HttpPost("add-devloper")]
        public IActionResult AddManager([FromBody] DevloperVM devloper)
        {
            _devloperService.AddDevloper(devloper);
            return Ok();
        }
        [HttpPut("update-devloper-by-id")]
        public IActionResult UpdateDevloperById(int id, [FromBody] DevloperVM devloper)
        {
            var _UpdatedDevloper = _devloperService.UpdateDevloperById(id, devloper);
            return Ok(_UpdatedDevloper);
        }
        [HttpDelete("delete-devloper-by-id/{id}")]
        public IActionResult DeleteDevloper(int id)
        {
            _devloperService.DeleteDevloperById(id);
            return Ok();
        }
       
    }
}
