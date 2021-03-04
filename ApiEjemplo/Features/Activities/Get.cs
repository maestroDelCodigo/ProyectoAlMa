using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            private readonly BikingContext context;
            private readonly IConfigurationProvider mappingConfig;

            public Handler(BikingContext context, IConfigurationProvider mappingConfig)
            {
                this.context = context;
                this.mappingConfig = mappingConfig;
            }

            public Task<ActivityRead> Handle(GetRequest request, CancellationToken cancellationToken)
            {
                return context.Activities
                    .ProjectTo<ActivityRead>(mappingConfig)
                    .FirstAsync(a => a.Id == request.Id, cancellationToken);
            }
        }
    }
}