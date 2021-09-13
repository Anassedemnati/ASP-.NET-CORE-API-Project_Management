using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_pract.Data.ViewModels
{
    public class DevloperVM
    {
        public string fullName { get; set; }
    }
    public class DevloperWithProjectsVM
    {
        public string fullName { get; set; }
        public List<string> ProjectName { get; set; }
    }
}
