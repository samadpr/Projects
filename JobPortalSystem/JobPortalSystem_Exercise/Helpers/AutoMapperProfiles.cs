
using AutoMapper;
using JobPortalSystem_Exercise.Dtos;
using JobPortalSystem_Exercise.Models;

namespace JobPortalSystem_Exercise.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CompanyDto, Company>().ForMember(dest => dest.Logo, opt => opt.Ignore());
        }
    }
}
