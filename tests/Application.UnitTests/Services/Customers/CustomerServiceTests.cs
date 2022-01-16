using Application.Common.Interfaces;
using Application.Services.Common;
using Application.Services.Customers;
using AutoMapper;
using Domain.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UnitTests.Services.Customers
{
    public class CustomerServiceTests
    {
        private Mock<IDataRepository> dataRepository;
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            dataRepository = new Mock<IDataRepository>();
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new CustomerProfile());
                });
                mapper = mappingConfig.CreateMapper();
            }
        }

        [Test]
        public async Task ShouldCreateCustomer()
        {
            // arrange
            var customer = GetCustomer();
            dataRepository.Setup(x => x.Create<Customer>(customer)).Returns(Task.FromResult(customer));
            var customerService = new CustomerService(dataRepository.Object, mapper);

            // act
            var result = await customerService.CreateCustomer(GetCustomerDto());

            // assert
            Assert.AreEqual(customer, result);
        }

        [Test]
        public void ShouldReturnAllCustomers()
        {
            // arrange
            dataRepository.Setup(x => x.Query<Customer>()).Returns(GetCustomers());
            var customerService = new CustomerService(dataRepository.Object, mapper);

            // act
            var result = customerService.GetAllCustomers();

            //assert
            Assert.AreEqual(1, result.Count);
        }

        private CustomerDto GetCustomerDto()
        {
            return new CustomerDto { FirstName = "First1", LastName = "Last1", Email = "1@1.com", MobileNumber = "123", Address = new AddressDto { Street = "Street 1", City = "City 1", State = "State 1", PostCode = "1", Country = "1" } };
        }

        private Customer GetCustomer()
        {
            return new Customer { Id = 1, FirstName = "First1", LastName = "Last1", Email = "1@1.com", MobileNumber = "123" };
        }

        private IQueryable<Customer> GetCustomers()
        {
            return new List<Customer> { new Customer { Id = 1, FirstName = "First", LastName = "Last", Email = "1@1.com" } }.AsQueryable();
        }
    }
}
