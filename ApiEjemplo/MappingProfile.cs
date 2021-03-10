using ApiEjemplo.Features.Activities;
using ApiEjemplo.Features.Bikes;
using ApiEjemplo.Features.Products;
using ApiEjemplo.Features.Users;
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
            CreateMap<User, GetAllUsers.UserRead>();
            CreateMap<Bike, GetAllBikes.BikeRead>();
            CreateMap<CreateBike.BikeInfo, Bike>();
            CreateMap<Product, GetAllProducts.ProductRead>();

        }
    }
}