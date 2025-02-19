using AutoMapper;
using FidelityApi.Dtos;
using FidelityApi.Models;

namespace FidelityApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
