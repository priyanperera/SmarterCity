using Application.Common.Interfaces;
using Application.Services.Common;
using Application.Services.Customers;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using Moq;
using NUnit.Framework;
using System;
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
            dataRepository = new Mock<IDataRepository>(MockBehavior.Strict);
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new CustomerProfile());
                    mc.AddProfile(new AddressProfile());
                });
                mapper = mappingConfig.CreateMapper();
            }
        }

        [Test]
        public void ShouldThrowExceptionWhenFirstNameIsNull()
        {
            // arrange
            var customer = GetCustomerDto();
            customer.FirstName = string.Empty;
            var customerService = new CustomerService(dataRepository.Object, mapper);

            // act/ assert
            Assert.ThrowsAsync<ApplicationException>(async () => { await customerService.CreateCustomer(customer); }, "Validation failed for Customer object", customer);
        }

        [Test]
        public void ShouldThrowExceptionWhenEmailIsNull()
        {
            // arrange
            var customer = GetCustomerDto();
            customer.Email = string.Empty;
            var customerService = new CustomerService(dataRepository.Object, mapper);

            // act/ assert
            Assert.ThrowsAsync<ApplicationException>(async () => { await customerService.CreateCustomer(customer); }, "Validation failed for Customer object", customer);
        }

        [Test]
        public void ShouldThrowExceptionWhenAddressIsNull()
        {
            // arrange
            var customer = GetCustomerDto();
            customer.Address = null;
            var customerService = new CustomerService(dataRepository.Object, mapper);

            // act/ assert
            Assert.ThrowsAsync<ApplicationException>(async () => { await customerService.CreateCustomer(customer); }, "Validation failed for Customer object", customer);
        }

        [Test]
        public async Task ShouldCreateCustomer()
        {
            // arrange
            var customerDto = GetCustomerDto();
            var customer = mapper.Map<CustomerDto, Customer>(customerDto);
            customer.Id = 1;
            dataRepository.Setup(x => x.Create<Customer>(It.IsAny<Customer>())).ReturnsAsync(customer);
            var customerService = new CustomerService(dataRepository.Object, mapper);

            // act
            var result = await customerService.CreateCustomer(customerDto);
            var dto = mapper.Map<CustomerDto, Customer>(result);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(dto.Id, 1);
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
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(1, result?.Count);
        }

        private CustomerDto GetCustomerDto()
        {
            return new CustomerDto { FirstName = "First1", LastName = "Last1", Email = "1@1.com", MobileNumber = "123", Address = new AddressDto { Street = "Street 1", City = "City 1", State = "State 1", PostCode = "1", Country = "1" } };
        }

        private Customer GetCustomer()
        {
            return new Customer { Id = 1, FirstName = "First1", LastName = "Last1", Email = "1@1.com", MobileNumber = "123", Address = new Address("Street 1", "City 1", "State 1", "1", "1") };
        }

        private IQueryable<Customer> GetCustomers()
        {
            return new List<Customer> { new Customer { Id = 1, FirstName = "First", LastName = "Last", Email = "1@1.com" } }.AsQueryable();
        }
    }
}
