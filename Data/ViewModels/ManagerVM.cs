using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_pract.Data.ViewModels
{
    public class ManagerVM
    {
        public string fullName { get; set; }
    }
    public class ManagerWithProjectsAndDevlopersVM
    {
        public string fullName { get; set; }
        public List<ProjectDevloperVM> projectDevlopers { get; set; }

    }
    public class ProjectDevloperVM
    {
        public string Name { get; set; }
        public List<string> projectDevloper { get; set; }
    }
}
