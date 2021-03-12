using System.Collections.Generic;
using System.Threading.Tasks;
using BikingUltimate.Client;
using Refit;

namespace PaymentSystem.Client
{
    public interface IPaymentSystemService
    {
        [Get("/Products")]
        Task<ICollection<Product>> GetProducts();

        [Get("/Products/{productId}")]
        Task GetProduct(int productId);
    }
}