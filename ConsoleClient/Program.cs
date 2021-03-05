using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ConsoleClient.Model;
using Refit;

namespace ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = CreateClient();
            //await PrintComponents(client, 1);
            //await CreateComponents(client, 1);
            await PrintUsers(client);
        }

        private static async Task PrintUsers(IBikingService client)
        {
            var users = await client.GetUsers();
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.ReadLine();
        }

        private static async Task PrintComponents(IBikingService client, int bikeId)
        {
            var components = await client.GetComponents(bikeId);

            foreach (var component in components)
            {
                Console.WriteLine(component);
            }

            Console.ReadLine();
        }

        private static async Task CreateComponents(IBikingService client, int bikeId)
        {
            var componentInfo = new ComponentInfo()
            {
                ComponentType = ComponentType.Chain,
                AddedOn = DateTimeOffset.Now,
                Brand = "Niidea",
                Model = "Modelo",
                Distance = 0D,
                Weight = 0.4D,
            };

            var createdId = await client.CreateComponent(bikeId, componentInfo);

            Console.WriteLine($"Componente creado con el id {createdId}");
            Console.ReadLine();
        }

        private static IBikingService CreateClient()
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
