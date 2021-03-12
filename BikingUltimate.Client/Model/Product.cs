using System.Collections.Generic;

namespace BikingUltimate.Client
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<Discount> Discount { get; set; }
    }
}