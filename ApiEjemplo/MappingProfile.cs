using ApiEjemplo.Features.Activities;
using ApiEjemplo.Model;
using AutoMapper;
using GetAll = ApiEjemplo.Features.Bikes.GetAll;

namespace ApiEjemplo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, ActivityRead>();
            CreateMap<Component, GetAll.ComponentRead>();
        }
    }
}