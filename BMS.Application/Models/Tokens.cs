using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Application.Models
{
    public class Response
    {
        public string Access_Token { get; set; }
        public string Refresh_Token { get; set; }
    }
    public class Request
    {
        public string Username { get; set; }
        public string Password { get; set; }


    }
}
