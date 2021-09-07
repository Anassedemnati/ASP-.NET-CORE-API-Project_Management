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
        public void AddProject(ProjectVM project) {

            var _project = new Project() {
                Name = project.Name,
                createDate = DateTime.Now,
                custumer = project.custumer,
                finished = project.finished 
            };
            _context.Projects.Add(_project);
            _context.SaveChanges();

        }
        public List<Project> GetAllProject() =>_context.Projects.ToList();
        public Project GetProjectById(int projectId) => _context.Projects.FirstOrDefault(i=>i.Id== projectId);
        public Project UpdateProjectById(int projectId,ProjectVM project)
        {
           var _project = _context.Projects.FirstOrDefault(n => n.Id == projectId);
            if (_project!=null)
            {
                _project.Name = project.Name;
                _project.custumer = project.custumer;
                _project.finished = project.finished;
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
