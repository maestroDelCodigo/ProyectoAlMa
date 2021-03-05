using ApiEjemplo.Features.Activities;
using ApiEjemplo.Features.Bikes;
using ApiEjemplo.Model;
using AutoMapper;

namespace ApiEjemplo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, ActivityRead>();
            CreateMap<Component, GetAllComponents.ComponentRead>();
            CreateMap<CreateComponent.ComponentInfo, Component>();
        }
    }
}