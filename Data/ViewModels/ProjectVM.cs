using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_pract.Data.ViewModels
{
    public class ProjectVM
    {
        public string Name { get; set; }
        public DateTime createDate { get; set; }
        public bool finished { get; set; }
        public string custumer { get; set; }
        public int ManagerId { get; set; }
        public List<int> DevloperId { get; set; }

    }
    public class ProjectWhithMangerVM
    {
        public string Name { get; set; }
        public DateTime createDate { get; set; }
        public bool finished { get; set; }
        public string custumer { get; set; }
        public string ManagerName { get; set; }
        public List<string> DevlopersName { get; set; }

    }
}
