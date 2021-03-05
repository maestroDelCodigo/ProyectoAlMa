using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApiEjemplo.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEjemplo.Features.Bikes
{
    public class GetAllComponents
    {
        public class GetAllComponentsRequest : IRequest<Collection<ComponentRead>>
        {
            public int BikeId { get; }

            public GetAllComponentsRequest(int bikeId)
            {
                BikeId = bikeId;
            }
        }

        public class Handler : IRequestHandler<GetAllComponentsRequest, Collection<ComponentRead>>
        {
            private readonly BikingContext context;
            private readonly IConfigurationProvider mappingConfig;

            public Handler(BikingContext context, IConfigurationProvider mappingConfig)
            {
                this.context = context;
                this.mappingConfig = mappingConfig;
            }

            public async Task<Collection<ComponentRead>> Handle(GetAllComponentsRequest request, CancellationToken cancellationToken)
            {
                var components = context.Bikes
                    .Where(x => x.Id == request.BikeId)
                    .SelectMany(bike => bike.Components);

                var componentReads = await components
                    .ProjectTo<ComponentRead>(mappingConfig)
                    .ToListAsync(cancellationToken);

                return new Collection<ComponentRead>(componentReads);
            }
        }

        public class ComponentRead
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public double Distance { get; set; }
            public double Weight { get; set; }
            public ComponentType ComponentType { get; set; }
            public DateTimeOffset AddedOn { get; set; }
            public DateTimeOffset? RetiredOn { get; set; }
        }
    }
}