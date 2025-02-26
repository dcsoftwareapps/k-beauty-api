using AutoMapper;
using KBeautyApi.Dtos;
using KBeautyApi.Models;

namespace KBeautyApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserCreateDto, User>().ReverseMap();
        }
    }
}
