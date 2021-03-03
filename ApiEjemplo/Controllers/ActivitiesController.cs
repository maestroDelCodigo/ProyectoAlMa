using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ApiEjemplo.Features;
using ApiEjemplo.Features.Activities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService service;
        private readonly IMediator mediator;

        public ActivitiesController(IActivitiesService service, IMediator mediator)
        {
            this.service = service;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<GetAll.ListActivitiesResponse> Get(bool isSortingDescending)
        {
            return await mediator.Send(new GetAll.ListActivitiesRequest(isSortingDescending));
        }

        [HttpPost]
        public async Task<int> Create(Create.CreateActivityRequest request)
        {
            return await mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<ActivityRead> Get(int id)
        {
            var activity = await service.Get(id);
            var dto = Mapper.Map(activity);

            return dto;
        }

        [HttpPut("{id}")]
        public async Task Update(int id, ActivityUpdate activity)
        {
            await service.Update(id, activity);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.Delete(id);
        }
    }
}