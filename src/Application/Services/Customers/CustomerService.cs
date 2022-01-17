using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IDataRepository dataRepository;
        private readonly IMapper mapper;

        public CustomerService(IDataRepository dataRepository, IMapper mapper)
        {
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        }

        public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            var customer = mapper.Map<CustomerDto, Customer>(customerDto);

            if (!customer.IsValid())
                throw new ApplicationException("Validation failed for Customer object");

            var result = await dataRepository.Create(customer);

            return mapper.Map<Customer, CustomerDto>(result);
        }

        public IList<CustomerDto>? GetAllCustomers()
        {
            var customers = dataRepository.Query<Customer>().ToList();
            if (customers.Any())
            {
                var result = mapper.Map<List<Customer>, List<CustomerDto>>(customers);
                return result;
            }
            return null;
        }

        public async Task<CustomerDto?> GetCustomer(int id)
        {
            var customer = await dataRepository.GetFirstOrDefault<Customer>(x => x.Id == id);
            if (customer == null) return null;
            var result = mapper.Map<Customer, CustomerDto>(customer);
            return result;
        }

    }
}
