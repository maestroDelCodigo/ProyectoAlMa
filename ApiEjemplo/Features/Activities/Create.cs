﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ApiEjemplo.Features.Activities
{
    public class Create
    {
        public class Command : IRequest<int>
        {
            public DateTimeOffset StartDate { get; set; }
            public DateTimeOffset FinishDate { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly BikingContext context;

            public Handler(BikingContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
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