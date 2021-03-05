using System.Collections.Generic;
using System.Threading.Tasks;
using ApiEjemplo.Features.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ICollection<GetAll.UserRead>> GetAll()
        {
            return await mediator.Send(new GetAll.Request());
        }

        [HttpGet("{userId}/bikes")]
        public async Task<ICollection<GetAll.UserRead>> GetAllBikes()
        {
            return await mediator.Send(new GetAll.Request());
        }
    }
}