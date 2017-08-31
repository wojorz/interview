using CustomerService.API.Models;
using CustomerService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.BLL.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDTO Map(Customer customer)
        {
            return new CustomerDTO
            {
                PassportId = customer.PassportId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth?.Date,
                EyesColor = customer.EyeColor?.Id
            };
        }

        public static Customer Map(CustomerDTO customer)
        {
            return new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth?.Date,
                EyesColorId = customer.EyesColor
            };
        }
    }
}
