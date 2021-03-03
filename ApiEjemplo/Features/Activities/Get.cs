using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEjemplo.Features.Activities
{
    public class Get
    {
        public class GetRequest : IRequest<ActivityRead>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<GetRequest, ActivityRead>
        {
            private readonly StravaContext context;

            public Handler(StravaContext context)
            {
                this.context = context;
            }

            public async Task<ActivityRead> Handle(GetRequest request, CancellationToken cancellationToken)
            {
                return Mapper.Map(await context.Activities.FirstAsync(a => a.Id == request.Id, cancellationToken));
            }
        }
    }
}