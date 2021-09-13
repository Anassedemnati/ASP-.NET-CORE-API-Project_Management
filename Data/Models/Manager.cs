using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_pract.Data.Models
{
    public class Manager
    {

        public int Id { get; set; }
        public string fullName { get; set; }
        //navigation proprety
        public List<Project> Projects { get; set; }



    }
}
