using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikingUltimate.Client;
using PaymentSystem.Client;

namespace ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = PaymentSystemClient.Create();
            await GetProduct(client);
            await ScanProducts(client);
        }

        
        private static async Task GetProduct(IPaymentSystemService client)
        {
            var products = await client.GetProducts();
            Console.WriteLine("Elija un producto: ");
            foreach (var product in products)
            {
                Console.WriteLine(product.Id + " - " + product.Name + ": " + product.Price + " libras");
            }
            
            Console.ReadLine();
        }

        public static async Task ScanProducts(IPaymentSystemService client)
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
    }
}
