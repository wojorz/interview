using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Customer Get(int id);

        Customer Add(Customer customer);

        bool Remove(int id);

        bool Update(Customer customer);
    }
}
