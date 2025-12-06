using AutoMapper;
using CreatorFlowApi.DTOs;
using CreatorFlowApi.DTOs.Auth;
using CreatorFlowApi.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CreatorFlowApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }
}
