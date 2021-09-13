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

        [HttpPost("add-manager")]
        public IActionResult AddManager([FromBody] ManagerVM manager)
        {
            _managerService.AddManager(manager);
            return Ok();
        }
        [HttpGet("get-manager-data-by-id/{id}")]
        public IActionResult GetManagerData(int id)
        {
            var _respense = _managerService.GetManagerData(id);
            return Ok(_respense);
        }
    }
}
