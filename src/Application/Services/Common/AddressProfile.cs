using Domain.ValueObjects;

namespace Application.Services.Common
{
    public class AddressProfile : AutoMapper.Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
