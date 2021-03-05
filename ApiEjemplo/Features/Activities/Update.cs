using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ApiEjemplo.Features.Activities
{
    public class Update
    {

        public class UpdateActivityRequest : IRequest
        {
            public DateTimeOffset StartDate { get; set; }
            public DateTimeOffset FinishDate { get; set; }
            public int Id { get; set; }
        }

        public class Handler : AsyncRequestHandler<UpdateActivityRequest>

        {
            private readonly BikingContext context;

            public Handler(BikingContext context)
            {
                this.context = context;
            }


            protected override async Task Handle(UpdateActivityRequest request, CancellationToken cancellationToken)
            {
                var activity = context.Activities.First(a => a.Id == request.Id);
                activity.FinishDate = request.FinishDate;
                activity.StartDate = request.StartDate;
                await context.SaveChangesAsync(cancellationToken);
            }
        }

    }
}