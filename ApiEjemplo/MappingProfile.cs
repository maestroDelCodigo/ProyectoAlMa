using ApiEjemplo.Features.Products;
using ApiEjemplo.Model;
using AutoMapper;


namespace ApiEjemplo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetAllProducts.ProductRead>();
        }
    }
}