using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApiEjemplo.Controllers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEjemplo.Features.Activities
{
    public class GetAll
    {
        public class ListActivitiesRequest : IRequest<GetAll.ListActivitiesResponse>
        {
            public bool IsSortingDescending { get; }

            public ListActivitiesRequest(bool isSortingDescending)
            {
                IsSortingDescending = isSortingDescending;
            }
        }

        public class ListActivitiesResponse : Collection<ActivityRead>
        {
            public ListActivitiesResponse(IEnumerable<ActivityRead> items) : base(items.ToList())
            {
            }
        }

        public class Handler : IRequestHandler<ListActivitiesRequest, ListActivitiesResponse>
        {
            private readonly StravaContext context;

            public Handler(StravaContext context)
            {
                this.context = context;
            }

            public async Task<ListActivitiesResponse> Handle(ListActivitiesRequest request, CancellationToken cancellationToken)
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
                    .ToListAsync(cancellationToken);

                return new ListActivitiesResponse(activities.Select(Mapper.Map));
            }
        }
    }
}