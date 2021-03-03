using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ApiEjemplo.Features.Activities
{
    public class Delete
    {
        public class DeleteActivityRequest : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : AsyncRequestHandler<DeleteActivityRequest>
        {
            private readonly StravaContext context;

            public Handler(StravaContext context)
            {
                this.context = context;
            }

            protected override async Task Handle(DeleteActivityRequest request, CancellationToken cancellationToken)
            {
                var activity = context.Activities.First(a => a.Id == request.Id);
                context.Activities.Remove(activity);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}