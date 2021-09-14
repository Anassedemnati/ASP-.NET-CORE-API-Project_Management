using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api_pract.Data.Models;
using web_api_pract.Data.ViewModels;

namespace web_api_pract.Data.Services
{
    public class ProjectService
    {
        private ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddProjectWithManager(ProjectVM project) {

            var _project = new Project() {
                Name = project.Name,
                createDate = DateTime.Now,
                custumer = project.custumer,
                finished = project.finished,
                ManagerId= project.ManagerId
                
            };
            _context.Projects.Add(_project);
            _context.SaveChanges();
            foreach (var id in project.DevloperId)
            {
                var _project_devloper = new Project_Devloper() {
                    ProjectId = _project.Id,
                    DevloperId=id
                
                };
                _context.Project_Devlopers.Add(_project_devloper);
                _context.SaveChanges();
            }

        }
        public List<Project> GetAllProject() =>_context.Projects.ToList();
        public ProjectWhithMangerVM GetProjectById(int projectId)
        {
            var _projectWhitManager = _context.Projects.Where(n=>n.Id==projectId).Select(project => new ProjectWhithMangerVM()
            {
                Name = project.Name,
                createDate = DateTime.Now,
                custumer = project.custumer,
                finished = project.finished,
                ManagerName=project.manager.fullName,
                DevlopersName=project.project_devlopers.Select(n=>n.devloper.fullName).ToList()
                
                


            }).FirstOrDefault();
            return _projectWhitManager;
        }
        public Project UpdateProjectById(int projectId,ProjectVM project)
        {
           var _project = _context.Projects.FirstOrDefault(n => n.Id == projectId);
            if (_project!=null)
            {
                _project.Name = project.Name;
                _project.custumer = project.custumer;
                _project.finished = project.finished;
                _project.ManagerId = project.ManagerId;
                _context.SaveChanges();
            }
            return _project;
        }
        public void DeleteProjectById(int projectId)
        {
            var _project = _context.Projects.FirstOrDefault(n => n.Id == projectId);
            if (_project != null)
            {
                _context.Projects.Remove(_project);
                _context.SaveChanges();
            }
        }
    }
}
