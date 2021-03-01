using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService service;

        public ActivitiesController(IActivitiesService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<List<ActivityRead>> Get()
        {
            var activities = await service.Get();
            return activities.Select(Mapper.Map).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActivityRead> Get(int id)
        {
            var activity = await service.Get(id);
            var dto = Mapper.Map(activity);

            return dto;
        }

        [HttpPost]
        public async Task<int> Create(ActivityCreate activity)
        {
            var createdId = await service.Create(activity);
            return createdId;
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