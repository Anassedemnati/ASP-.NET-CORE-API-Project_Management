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
    public class ManagerController : ControllerBase
    {
        public ManagerService _managerService;

        public ManagerController(ManagerService managerService)
        {
            _managerService = managerService;
        }
        [HttpGet("get-all-managers")]
        public IActionResult GetAllManagers()
        {
            var _managers = _managerService.GetAllManagers();
            return Ok(_managers);
        }
       
        [HttpGet("get-manager-data-by-id/{id}")]
        public IActionResult GetManagerData(int id)
        {
            var _respense = _managerService.GetManagerData(id);
            return Ok(_respense);
        }
        [HttpPost("add-manager")]
        public IActionResult AddManager([FromBody] ManagerVM manager)
        {
            _managerService.AddManager(manager);
            return Ok();
        }
        [HttpDelete("delete-manager-by-id/{id}")]
        public IActionResult DeleteManager(int id)
        {
            _managerService.DeleteManagerById(id);
            return Ok();
        }
    }
}
