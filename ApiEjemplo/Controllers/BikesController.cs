using System.Collections.Generic;
using System.Threading.Tasks;
using ApiEjemplo.Features.Bikes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BikesController : ControllerBase
    {
        private readonly IMediator mediator;

        public BikesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{bikeId}/components")]
        public async Task<ICollection<GetAllComponents.ComponentRead>> GetComponent(int bikeId)
        {
            return await mediator.Send(new GetAllComponents.GetAllComponentsRequest(bikeId));
        }

        [HttpPost("{bikeId}/components")]
        public async Task<int> CreateComponent(int bikeId, CreateComponent.ComponentInfo componentInfo)
        {
            return await mediator.Send(new CreateComponent.Request(bikeId, componentInfo));
        }
    }
}