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
    public class DevloperService
    {
        private ApplicationDbContext _context;

        public DevloperService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Devloper AddDevloper(DevloperVM devloper)
        {
            if (StringStartWithNumber(devloper.fullName)) throw new DevloperNameException("Name start with number",devloper.fullName);
            

            
            var _devloper = new Devloper()
            {
                fullName = devloper.fullName,

            };
            _context.Devlopers.Add(_devloper);
            _context.SaveChanges();
            return _devloper;

        }
        public DevloperWithProjectsVM GetDevloperWithProjects(int devloperId)
        {
            var _devloper = _context.Devlopers.Where(n => n.Id == devloperId).Select(n=> new DevloperWithProjectsVM() { 
            fullName=n.fullName,
            ProjectName=n.project_devlopers.Select(p=>p.project.Name).ToList()
            }).FirstOrDefault();

            return _devloper;
        }
        public void DeleteDevloperById(int DevloperId)
        {
            var _devloper = _context.Devlopers.FirstOrDefault(n => n.Id == DevloperId);
            if (_devloper != null)
            {
                _context.Devlopers.Remove(_devloper);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"the devloper with id : {DevloperId} does not exist!");
            }

        }
        public List<Devloper> GetAllDevloper() => _context.Devlopers.ToList();
        public Devloper UpdateDevloperById(int devloperId, DevloperVM devloper)
        {
            var _devloper = _context.Devlopers.FirstOrDefault(n => n.Id == devloperId);
            if (_devloper != null)
            {
                _devloper.fullName = devloper.fullName;
               
                _context.SaveChanges();
                return _devloper;
            }
             else
            {
                throw new Exception($"the devloper with id : {devloperId} does not exist!");
            }
        }
        private bool StringStartWithNumber(string Name) => (Regex.IsMatch(Name, @"^\d"));
        
            //if (Regex.IsMatch(Name, @"^\d")) return true;
            //return false;
        
    }
}
