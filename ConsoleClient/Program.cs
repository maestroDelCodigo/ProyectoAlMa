using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BikingUltimate.Client;
using ConsoleClient.Model;
using Refit;

namespace ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = BikingUltimateClient.Create();
            //await PrintComponents(client, 1);
            //await CreateComponents(client, 1);
            //await PrintUsers(client);
            await GetProduct(client);
            await ScanProducts(client);
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
        private static async Task GetProduct(IBikingService client)
        {
            var products = await client.GetProducts();
            Console.WriteLine("Elija un producto: ");
            foreach (var product in products)
            {
                Console.WriteLine(product.Id + " - " + product.Name + ": " + product.Price + " libras");
            }
            
            Console.ReadLine();
        }

        public static async Task ScanProducts(IBikingService client)
        {
            bool endApp = false;
            ICollection<Product> checkout = new List<Product>();

            while (endApp == false)
            {
                var selectProduct = await client.GetProducts();
                Console.Write("Para finalizar su compra pulse 5: ");
                
                switch (Console.ReadLine())
                {
                    case ("2"):
                        selectProduct.Where(s => s.Id == 2).Select(s => s.Name).ToList().Add(selectProduct.ToString());
                        checkout = selectProduct;
                        Console.WriteLine($"Scan Strawberries ");
                        break;
                    case ("3"):
                        Console.WriteLine($"Scan Green Tea ");
                        selectProduct.Where(s => s.Id == 3).Select(s => s.Name).ToList().Add(selectProduct.ToString());
                        break;
                    case ("4"):
                        Console.WriteLine($"Scan Coffee ");
                        selectProduct.Where(s => s.Id == 4).Select(s => s.Name).ToList().Add(selectProduct.ToString());
                        break;
                    case ("5"):
                        endApp = true;
                        break;

                }
                
            }

            Console.WriteLine("Su carrito esta compuesto por: ");
            foreach (var product in checkout)
            {   
                
                Console.WriteLine(product.Name);
            }
            
            Console.ReadLine();

            double total = 0;
            foreach (var productBasket in checkout)
            {
                total += productBasket.Price;
            }

            Console.WriteLine(total);
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
    }
}
