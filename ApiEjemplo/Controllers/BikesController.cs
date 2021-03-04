using System.Collections.ObjectModel;
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
        public async Task<Collection<GetAll.ComponentRead>> Get(int bikeId)
        {
            return await mediator.Send(new GetAll.GetAllComponentsRequest(bikeId));
        }
    }
}