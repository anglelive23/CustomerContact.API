using AutoMapper;
using CustomerContacts.Dtos;
using CustomerContacts.Models;

namespace CustomerContacts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>().ReverseMap().ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id));
            Mapper.CreateMap<Contact, ContactDto>().ReverseMap().ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id));
        }
    }
}
