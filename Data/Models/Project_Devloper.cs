using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_pract.Data.Models
{
    public class Project_Devloper
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project project { get; set; }
        public int DevloperId { get; set; }
        public Devloper devloper { get; set; }
    }
}
