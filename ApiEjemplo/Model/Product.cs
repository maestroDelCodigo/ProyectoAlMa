using System.Collections.Generic;

namespace ApiEjemplo.Model
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<Discount> Discount { get; set; }
    }
}