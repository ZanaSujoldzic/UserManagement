using AutoMapper;
using UserManagement.Dto;
using UserManagement.Models;
using AutoMapper;

namespace UserManagement
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
