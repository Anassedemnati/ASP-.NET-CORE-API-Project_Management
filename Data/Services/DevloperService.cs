using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api_pract.Data.Models;
using web_api_pract.Data.ViewModels;

namespace web_api_pract.Data.Services
{
    public class DevloperService
    {
        private ApplicationDbContext _context;

        public DevloperService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddDevloper(DevloperVM devloper)
        {

            var _devloper = new Devloper()
            {
                fullName = devloper.fullName,

            };
            _context.Devlopers.Add(_devloper);
            _context.SaveChanges();

        }
        public DevloperWithProjectsVM GetDevloperWithProjects(int devloperId)
        {
            var _devloper = _context.Devlopers.Where(n => n.Id == devloperId).Select(n=> new DevloperWithProjectsVM() { 
            fullName=n.fullName,
            ProjectName=n.project_devlopers.Select(p=>p.project.Name).ToList()
            }).FirstOrDefault();

            return _devloper;
        }
    }
}
