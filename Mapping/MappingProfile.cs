using AutoMapper;
using CreatorFlowApi.DTOs;
using CreatorFlowApi.DTOs.Auth;
using CreatorFlowApi.DTOs.Contents;
using CreatorFlowApi.DTOs.Projects;
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

            CreateMap<Project, ProjectDto>();
            CreateMap<CreateProjectDto, Project>();
            CreateMap<UpdateProjectDto, Project>();

            CreateMap<ContentItem, ContentItemDto>();
            CreateMap<CreateContentItemDto, ContentItem>();


        }
    }
}
