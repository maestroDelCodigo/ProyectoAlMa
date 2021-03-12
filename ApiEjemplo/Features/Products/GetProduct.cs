using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApiEjemplo.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEjemplo.Features.Products
{
    public class GetProduct
    {
        public class Request : IRequest<ICollection<ProductRead>>
        {
            public Request(int productId)
            {
                ProductId = productId;
            }

            public int ProductId { get; }
        }

        public class Handler : IRequestHandler<Request, ICollection<ProductRead>>
        {
            private readonly BikingContext bikingContext;
            private readonly IConfigurationProvider mappingConfig;

            public Handler(BikingContext bikingContext, IConfigurationProvider mappingConfig)
            {
                this.bikingContext = bikingContext;
                this.mappingConfig = mappingConfig;
            }

            public async Task<ICollection<ProductRead>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await bikingContext.Products
                    .ProjectTo<ProductRead>(mappingConfig)
                    .ToListAsync(cancellationToken: cancellationToken);
            }
        }
            public class ProductRead
            {
                public int ProductId { get; set; }
                public string Name { get; set; }
                public double Price { get; set; }
                
            }
       
    }
}