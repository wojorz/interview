using CustomerService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetAll()
        {
            using (var context = new CustomerContext())
            {
                return context.Customers.ToList();
            }
        }

        public Customer Get(int id)
        {
            using (var context = new CustomerContext())
            {
                return context.Customers.FirstOrDefault(x => x.PassportId == id);
            }
        }

        public Customer Add(Customer customer)
        {
            using (var context = new CustomerContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return customer;
            }
        }

        public bool Remove(int id)
        {
            using (var context = new CustomerContext())
            {
                var toRemove = context.Customers.FirstOrDefault(x => x.PassportId == id);
                if (toRemove == null)
                {
                    return false;
                }
                context.Customers.Remove(toRemove);
                return true;
            }
        }

        public bool Update(Customer customer)
        {
            using (var context = new CustomerContext())
            {
                var toRemove = context.Customers.FirstOrDefault(x => x.PassportId == customer.PassportId);
                if (toRemove ==null)
                {
                    return false;
                }

                context.Customers.Remove(toRemove);
                context.Customers.Add(customer);
                return true;
            }
        }
    }
}
