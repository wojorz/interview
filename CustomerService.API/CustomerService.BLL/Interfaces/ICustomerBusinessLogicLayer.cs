using CustomerService.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.BLL.Interfaces
{
    public interface ICustomerBusinessLogicLayer
    {
        IEnumerable<CustomerDTO> GetAll();

        CustomerDTO Add(CustomerDTO item);

        bool Remove(int id);

        bool Update(CustomerDTO item);
    }
}
