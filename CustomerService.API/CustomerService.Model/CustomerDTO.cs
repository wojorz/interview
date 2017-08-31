using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService.API.Models
{
    public class CustomerDTO
    {
        public int PassportId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? EyesColor { get; set; }
    }
}