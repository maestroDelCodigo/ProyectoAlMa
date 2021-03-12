using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEjemplo.Features.Products;
using MediatR;

namespace ApiEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<ICollection<GetAllProducts.ProductRead>> GetAll()
        {
            return await mediator.Send(new GetAllProducts.Request());
        }
        //[HttpGet (template:"{productId)")]
        //public async Task<ICollection<GetAllProducts.ProductRead>> GetProduct(int productId)
        //{
        //    return await mediator.Send(new GetProduct.Request(productId));
        //}
    }
}
