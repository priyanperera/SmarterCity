using Domain.Entities;

namespace Application.Services.Customers
{
    public interface ICustomerService
    {
        Task<CustomerDto> CreateCustomer(CustomerDto customerDto);
        IList<CustomerDto> GetAllCustomers();
        Task<CustomerDto> GetCustomer(int id);
    }
}
