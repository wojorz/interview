using CustomerService.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerService.API.Models;
using CustomerService.Repository;
using CustomerService.Repository.Interfaces;
using CustomerService.BLL.Mappers;

namespace CustomerService.BLL
{
    public class CustomerBusinessLogicLayer : ICustomerBusinessLogicLayer
    {
        private readonly ICustomerRepository _repository = new CustomerRepository();

        public CustomerBusinessLogicLayer()
        {
        }

        public CustomerBusinessLogicLayer(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public CustomerDTO Get(int id)
        {
            var entity = _repository.Get(id);
            return CustomerMapper.Map(entity);
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            var entities = _repository.GetAll();
            return entities.Select(x => CustomerMapper.Map(x));
        }

        public CustomerDTO Add(CustomerDTO customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException();
            }

            var entityToAdd = CustomerMapper.Map(customer);
            var dto = _repository.Add(entityToAdd);
            return CustomerMapper.Map(dto);
        }

        public bool Remove(int id)
        {
            return _repository.Remove(id);
        }

        public bool Update(CustomerDTO customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException();
            }

            var entityToUpdate = CustomerMapper.Map(customer);
            return _repository.Update(entityToUpdate);
        }
    }
}
