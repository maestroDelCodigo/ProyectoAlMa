using System;
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
    public class Create
    {
        public class CreateActivityRequest : IRequest<int>
        {
            public CreateActivityRequest()
            {
            }

            public DateTimeOffset StartDate { get; set; }
            public DateTimeOffset FinishDate { get; set; }
        }

        public class CreateActivityResponse : Collection<ActivityRead>
        {
            public CreateActivityResponse(IEnumerable<ActivityRead> items) : base(items.ToList())
            {
            }
        }

        public class Handler : IRequestHandler<CreateActivityRequest, int>
        {
            private readonly StravaContext context;

            public Handler(StravaContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(CreateActivityRequest request, CancellationToken cancellationToken)
            {
                var activity = new Activity
                {
                    FinishDate = request.FinishDate,
                    StartDate = request.StartDate,
                    Creator = "Yo",
                };

                await context.Activities.AddAsync(activity, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);

                return activity.Id;
            }
        }
    }
}