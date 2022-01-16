using Domain.Entities;

namespace Application.Services.Customers
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
