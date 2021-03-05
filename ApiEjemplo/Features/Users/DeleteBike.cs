using ApiEjemplo.Model;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiEjemplo.Features.Users
{
    public class DeleteBike
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
                var bike = context.Bikes.First(b => b.Id == request.bikeId);
                context.Bikes.Remove(bike);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
