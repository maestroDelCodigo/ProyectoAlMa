using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ApiEjemplo.Features.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
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
                context.Activities.Remove(activity);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}