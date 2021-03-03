using ApiEjemplo.Features.Activities;
using AutoMapper;

namespace ApiEjemplo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, ActivityRead>();
        }
    }
}