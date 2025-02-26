using AutoMapper;
using KBeautyApi.Models;
using KBeautyApi.Dtos;

namespace FidelityApi.Profiles
{
    public class LevelProfile : Profile
    {
        public LevelProfile()
        {
            CreateMap<Level, LevelDto>();
        }
    }
}
