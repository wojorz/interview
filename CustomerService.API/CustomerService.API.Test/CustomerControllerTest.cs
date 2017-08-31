using CustomerDTOService.API.Controllers;
using CustomerService.API.Models;
using CustomerService.BLL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.API.Test
{
    [TestFixture]
    public class CustomerControllerTest
    {
        private Mock<ICustomerBusinessLogicLayer> _logicLayerMock;


        [SetUp]
        public void Init()
        {
            _logicLayerMock = new Mock<ICustomerBusinessLogicLayer>();
        }

        public void Post_GivenCustomer_CallsBLL()
        {
            int callCounter = 0;
            _logicLayerMock.Setup(x => x.Add(It.Is<CustomerDTO>(c => c.PassportId == 1))).Callback(() => callCounter++);
            var controller = new CustomerController(_logicLayerMock.Object);
            var customer = CreateDummyCustomer(1);

            // controller.Post(customer);

            Assert.AreEqual(1, callCounter);

        }

        private CustomerDTO CreateDummyCustomer(int id)
        {
            return new CustomerDTO
            {
                FirstName = "Name",
                LastName = "Surname",
                DateOfBirth = new DateTime(2017, 08, 31),
                PassportId = id
            };
        }
    }
}
