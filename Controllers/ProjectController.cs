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
    public class ProjectController : ControllerBase
    {
        public ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("get-all-project")]
        public IActionResult GetAllProject()
        {
            var allproject = _projectService.GetAllProject();
            return Ok(allproject);
        }
        [HttpGet("get-project-by-id/{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _projectService.GetProjectById(id);
            return Ok(project);
        }

        [HttpPost("add-project-with-manager")]
        public IActionResult AddProjectWithManager([FromBody] ProjectVM project)
        {
            _projectService.AddProjectWithManager(project);
            return Ok();
        }
        [HttpPut("update-project-by-id/{id}")]
        public IActionResult UpdateProjectById(int id,[FromBody] ProjectVM project)
        {
            var UpdatedProject = _projectService.UpdateProjectById(id, project);
            return Ok(UpdatedProject);
        }
        [HttpDelete("delete-project-by-id/{id}")]
        public IActionResult DeleteProjectById(int id)
        {
            _projectService.DeleteProjectById(id);
            return Ok();
        }
    }
}
