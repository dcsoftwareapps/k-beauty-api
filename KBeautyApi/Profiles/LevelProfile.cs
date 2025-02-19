using AutoMapper;
using FidelityApi.Dtos;
using FidelityApi.Models;

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
