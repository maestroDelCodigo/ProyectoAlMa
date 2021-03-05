using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEjemplo.Features.Users
{
    public class GetAllBikes
    {
        public class Request : IRequest<ICollection<BikeRead>>
        {
            public string Username { get; set; }
        }

        public class Handler : IRequestHandler<Request, ICollection<BikeRead>>
        {
            private readonly BikingContext bikingContext;
            private readonly IConfigurationProvider mappingConfig;

            public Handler(BikingContext bikingContext, IConfigurationProvider mappingConfig)
            {
                this.bikingContext = bikingContext;
                this.mappingConfig = mappingConfig;
            }

            public async Task<ICollection<BikeRead>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await bikingContext.Users
                    .Where(x => x.Username == request.Username)
                    .SelectMany(s => s.Bikes)
                    .ProjectTo<BikeRead>(mappingConfig)
                    .ToListAsync(cancellationToken);
            }
        }

        public class BikeRead
        {
            public string Username { get; set; }
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}