using CustomerService.API.Models;
using CustomerService.Repository;
using CustomerService.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.BLL.Test
{
    [TestFixture]
    public class CustomerBusinessLogicLayerTest
    {
        private Mock<ICustomerRepository> _repositoryMock;

        [SetUp]
        public void Init()
        {
            _repositoryMock = new Mock<ICustomerRepository>();
        }

        [Test]
        public void Add_ArgumentIsNull_ThrowsArgumentNullException()
        {
            var logicLayer = new CustomerBusinessLogicLayer(_repositoryMock.Object);
            Assert.Throws<ArgumentNullException>(() => logicLayer.Add(null));
        }

        [Test]
        public void Add_CustomerNotExist_AddsCustomer()
        {
            var customerEntity = CreateCustomer(1);
            _repositoryMock.Setup(x => x.Add(It.Is<Customer>(c => c.PassportId == 1))).Returns(customerEntity);
            var logicLayer = new CustomerBusinessLogicLayer(_repositoryMock.Object);
            
            CustomerDTO customer = CreateDummyCustomerDTO(1);
            var actual = logicLayer.Add(customer);

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.PassportId);
            Assert.AreEqual("NameDB", actual.FirstName);
            Assert.AreEqual("SurnameDB", actual.LastName);
            Assert.AreEqual(new DateTime(2017, 08, 31), actual.DateOfBirth);
        }

        private CustomerDTO CreateDummyCustomerDTO(int id)
        {
            return new CustomerDTO
            {
                FirstName = "Name",
                LastName = "Surname",
                DateOfBirth = new DateTime(2010, 08, 31),
                PassportId = id
            };
        }

        private Customer CreateCustomer(int id)
        {
            return new Customer
            {
                FirstName = "NameDB",
                LastName = "SurnameDB",
                DateOfBirth = new DateTime(2017, 08, 31),
                PassportId = id
            };
        }
    }

}
