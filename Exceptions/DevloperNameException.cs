using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_pract.Exceptions
{
    public class DevloperNameException : Exception
    {
        public string _DevloperName { get; set; }
        public DevloperNameException()
        {

        }
        public DevloperNameException(string message) : base(message)
        {

        }
        public DevloperNameException(string message, Exception inner) : base(message,inner)
        {

        }
        public DevloperNameException(string message,string DevloperName):this(message)
        {
            _DevloperName = DevloperName;
        }

    }
}
