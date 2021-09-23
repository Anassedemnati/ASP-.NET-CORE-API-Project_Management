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
            if (_managers!=null)
            {
                return Ok(_managers);
            }
            else
            {
                return NotFound();
            }
        }
       
        [HttpGet("get-manager-data-by-id/{id}")]
        public IActionResult GetManagerData(int id)
        {
            var _respense = _managerService.GetManagerData(id);

            if (_respense != null)
            {
                return Ok(_respense);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("get-manager-by-id/{id}")]
        public IActionResult GetManagerById(int id)
        {
            var _respense = _managerService.GetManagerById(id);
            if (_respense!= null)
            {
                return Ok(_respense);
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpPost("add-manager")]
        public IActionResult AddManager([FromBody] ManagerVM manager)
        {
            try
            {
                var NewManager = _managerService.AddManager(manager);
                return Created(nameof(AddManager), NewManager);
            }
            catch(ManagerNameException ex)
            {
                return BadRequest($"{ex.Message }, Manager name {ex._ManagerName}");
            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message);
            }
          
        }

        [HttpPut("update-manager-by-id")]
        public IActionResult UpdateManagerById(int id,[FromBody] ManagerVM manager)
        {
            try
            {
                var _UpdatedManager = _managerService.UpdateManagerByID(id, manager);
                return Ok(_UpdatedManager);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("delete-manager-by-id/{id}")]
        public IActionResult DeleteManager(int id)
        {
            try
            {
                _managerService.DeleteManagerById(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }
    }
}
