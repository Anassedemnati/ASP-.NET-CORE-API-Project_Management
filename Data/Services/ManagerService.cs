using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using web_api_pract.Data.Models;
using web_api_pract.Data.ViewModels;
using web_api_pract.Exceptions;

namespace web_api_pract.Data.Services
{
    public class ManagerService
    {
        private ApplicationDbContext _context;

        public ManagerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Manager AddManager(ManagerVM manager)
        {
            if (StringStartWithNumber(manager.fullName)) throw new ManagerNameException("Name start with number",manager.fullName);
            var _manager = new Manager()
            {
                fullName = manager.fullName,
                
            };
            _context.Managers.Add(_manager);
            _context.SaveChanges();
            return _manager;

        }
        public ManagerWithProjectsAndDevlopersVM GetManagerData(int managerid)
        {

            var _managerData = _context.Managers.Where(n => n.Id == managerid).Select(n=> new ManagerWithProjectsAndDevlopersVM() {
            
            fullName=n.fullName,
            projectDevlopers=n.Projects.Select(n=>new ProjectDevloperVM() {
                Name=n.Name,
                projectDevloper=n.project_devlopers.Select(n=>n.devloper.fullName).ToList()
            }).ToList()
            
            }).FirstOrDefault();

            return _managerData;
        }
        public Manager GetManagerById(int managerId) => _context.Managers.FirstOrDefault(n => n.Id == managerId);

        public void DeleteManagerById(int managerId)
        {
            var _manager = _context.Managers.FirstOrDefault(n=>n.Id==managerId);
            if (_manager!=null)
            {
                _context.Managers.Remove(_manager);
                _context.SaveChanges();
            }
           
           
        }
        public List<Manager> GetAllManagers() => _context.Managers.ToList();
        public Manager UpdateManagerByID(int managerId, ManagerVM manager)
        {
            var _manager = _context.Managers.FirstOrDefault(n => n.Id == managerId);
            if (_manager!=null)
            {
                _manager.fullName = manager.fullName;
                _context.SaveChanges();
                return _manager;
            }
            else
            {
                throw new Exception($"the Manager with the id : {managerId} dose not exist!");
            }

        }
        private bool StringStartWithNumber(string Name) => (Regex.IsMatch(Name, @"^\d"));
    }
}
