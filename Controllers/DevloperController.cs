using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api_pract.Data.Services;
using web_api_pract.Data.ViewModels;
using web_api_pract.Exceptions;

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
            if (_devlopers != null)
            {
                return Ok(_devlopers);
            }
            else
                return NotFound();
        }
        
        [HttpGet("get-devloper-whith-projects-by-id/{id}")]
        public IActionResult GetDevloperWhithProject(int id)
        {
            var _respensee = _devloperService.GetDevloperWithProjects(id);
            if (_respensee != null)
            {
                return Ok(_respensee);
            }
            else
                return NotFound();
            
        }
        [HttpPost("add-devloper")]
        public IActionResult AddDevloper([FromBody] DevloperVM devloper)
        {
            try
            {
                var _NewDevloper = _devloperService.AddDevloper(devloper);
                return Created(nameof(AddDevloper), _NewDevloper);
            }
            catch(DevloperNameException ex)
            {
                return BadRequest($"{ex.Message }, Devloper name {ex._DevloperName}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }
        [HttpPut("update-devloper-by-id")]
        public IActionResult UpdateDevloperById(int id, [FromBody] DevloperVM devloper)
        {
            try
            {
                var _UpdatedDevloper = _devloperService.UpdateDevloperById(id, devloper);
                return Ok(_UpdatedDevloper);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        [HttpDelete("delete-devloper-by-id/{id}")]
        public IActionResult DeleteDevloper(int id)
        {
            try
            {
                _devloperService.DeleteDevloperById(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
       
    }
}
