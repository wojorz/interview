using CustomerService.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Repository
{
    class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<EyeColor> EyeColors { get; set; }
    }
}
