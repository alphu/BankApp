using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Application.Models
{
   public class CustomerDto
    {

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string Pan { get; set; }
        public string ContactNo { get; set; }
        public DateTime DOB { get; set; }
        public string AccountType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? Updateddate { get; set; }
    }
}
