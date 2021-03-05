using System.Text.Json;
using System.Text.Json.Serialization;
using Refit;

namespace BikingUltimate.Client
{
    public class BikingUltimateClient
    {
        public static IBikingService Create()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            options.Converters.Add(new JsonStringEnumConverter());

            var settings = new RefitSettings()
            {
                ContentSerializer = new SystemTextJsonContentSerializer(options)
            };

            var baseUrl = "https://localhost:44305";
            var client = RestService.For<IBikingService>(baseUrl, settings);
            return client;
        }
    }
}