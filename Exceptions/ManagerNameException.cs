using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_pract.Exceptions
{
    public class ManagerNameException:Exception
    {
        public string _ManagerName { get; set; }
        public ManagerNameException()
        {

        }
        public ManagerNameException(string message):base(message)
        {

        }
        public ManagerNameException(string message,Exception inner):base(message,inner)
        {

        }
        public ManagerNameException(string messsage,string managerName):this(messsage)
        {
            _ManagerName = managerName;
        }
    }
}
