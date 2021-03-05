using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ConsoleClient.Model;
using Refit;

namespace ConsoleClient
{
    internal interface IBikingService
    {
        [Get("/Bikes/{bikeId}/components")]
        Task<Collection<Component>> GetComponents(int bikeId);
    }
}