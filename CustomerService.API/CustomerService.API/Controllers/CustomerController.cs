using CustomerService.API.Models;
using CustomerService.BLL;
using CustomerService.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace CustomerDTOService.API.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerBusinessLogicLayer _customerBusinessLogicLayer;

        public CustomerController()
        {
            _customerBusinessLogicLayer = new CustomerBusinessLogicLayer();
        }

        public CustomerController(ICustomerBusinessLogicLayer customerBusinessLogicLayer)
        {
            _customerBusinessLogicLayer = customerBusinessLogicLayer;
        }

        // GET api/<controller>
        public IEnumerable<CustomerDTO> GetAll()
        {
            return _customerBusinessLogicLayer.GetAll();
        }

        // POST api/<controller>
        public CustomerDTO Post([FromBody]CustomerDTO customer)
        {
            return _customerBusinessLogicLayer.Add(customer);
        }

        //// PUT api/<controller>/5
        public void Put(int id, [FromBody]CustomerDTO customer)
        {
            if (!_customerBusinessLogicLayer.Update(customer))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //// DELETE api/<controller>/5
        public void Delete(int id)
        {
            if (!_customerBusinessLogicLayer.Remove(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}