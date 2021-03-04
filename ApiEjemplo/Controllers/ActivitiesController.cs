using System.Threading.Tasks;
using ApiEjemplo.Features.Activities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ActivitiesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<GetAll.ListActivitiesResponse> Get([FromQuery]GetAll.ListActivitiesRequest request)
        {
            return await mediator.Send(request);
        }

        [HttpPost]
        public async Task<int> Create(Create.CreateActivityRequest request)
        {
            return await mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<ActivityRead> Get(int id)
        {
            return await mediator.Send(new Get.GetRequest { Id = id });
        }

        [HttpPut]
        public async Task Update(Update.UpdateActivityRequest request)
        {
            await mediator.Send(request);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await mediator.Send(new Delete.DeleteActivityRequest(){ Id = id });
        }
    }
}