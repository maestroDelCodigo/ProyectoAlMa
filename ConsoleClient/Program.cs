using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var baseUrl = "https://localhost:44305";
            var client = RestService.For<IBikingService>(baseUrl);
            var components = await client.GetComponents(1);
            foreach (var component in components)
            {
                Console.WriteLine(component);
            }
            Console.ReadLine();
        }
    }
}
