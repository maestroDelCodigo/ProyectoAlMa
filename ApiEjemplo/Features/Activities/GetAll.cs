﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEjemplo.Features.Activities
{
    public class GetAll
    {
        public class Query : IRequest<ListActivitiesResponse>
        {
            public bool IsSortingDescending { get; set; }
        }

        public class ListActivitiesResponse : Collection<ActivityRead>
        {
            public ListActivitiesResponse(IEnumerable<ActivityRead> items) : base(items.ToList())
            {
            }
        }

        public class Handler : IRequestHandler<Query, ListActivitiesResponse>
        {
            private readonly BikingContext context;
            private readonly IConfigurationProvider mappingConfig;

            public Handler(BikingContext context, IConfigurationProvider mappingConfig)
            {
                this.context = context;
                this.mappingConfig = mappingConfig;
            }

            public async Task<ListActivitiesResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var source = context.Activities.AsQueryable();

                if (request.IsSortingDescending)
                {
                    source = source.OrderByDescending(x => x.Id);
                }
                else
                {
                    source = source.OrderBy(x => x.Id);
                }

                var activities = await source
                    .ProjectTo<ActivityRead>(mappingConfig)
                    .ToListAsync(cancellationToken);

                return new ListActivitiesResponse(activities);
            }
        }
    }
}