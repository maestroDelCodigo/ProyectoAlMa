using System;
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

        [Post("/Bikes/{bikeId}/components")]
        Task<int> CreateComponent(int bikeId, ComponentInfo componentInfo);
    }

    internal class ComponentInfo
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Distance { get; set; }
        public double Weight { get; set; }
        public ComponentType ComponentType { get; set; }
        public DateTimeOffset AddedOn { get; set; }
        public DateTimeOffset? RetiredOn { get; set; }
    }
}