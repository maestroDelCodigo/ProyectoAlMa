using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEjemplo.Features.Products
{
    public class GetAllProducts
    {
        public class Request : IRequest<ICollection<ProductRead>>
        {
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
                    public string Name { get; set; }
                    public double Price { get; set; }
                    public int Discount { get; set; }
                }
       
    }
}