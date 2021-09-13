using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_pract.Data.Models
{
    public class Devloper
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        //navigation proprety
        public List<Project_Devloper> project_devlopers { get; set; }
    }
}
