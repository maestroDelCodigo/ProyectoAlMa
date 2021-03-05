using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ApiEjemplo.Features.Activities
{
    public class Update
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public ActivityInfo ActivityInfo { get; set; }
        }

        public class Handler : AsyncRequestHandler<Command>
        {
            private readonly BikingContext context;

            public Handler(BikingContext context)
            {
                this.context = context;
            }

            protected override async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = context.Activities.First(a => a.Id == request.Id);
                activity.FinishDate = request.ActivityInfo.FinishDate;
                activity.StartDate = request.ActivityInfo.StartDate;
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        public class ActivityInfo
        {
            public DateTimeOffset StartDate { get; set; }
            public DateTimeOffset FinishDate { get; set; }
        }
    }
}