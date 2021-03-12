using System.Text.Json;
using System.Text.Json.Serialization;
using Refit;

namespace PaymentSystem.Client
{
    public class PaymentSystemClient
    {
        public static IPaymentSystemService Create()
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
            var client = RestService.For<IPaymentSystemService>(baseUrl, settings);
            return client;
        }
    }
}