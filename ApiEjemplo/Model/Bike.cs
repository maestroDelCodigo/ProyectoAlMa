using System.Collections.Generic;

namespace ApiEjemplo.Model
{
    public class Bike : Entity
    {
        public string Brand { get; set; }
        public double Distance { get; set; }
        public string Model { get; set; }
        public ICollection<Component> Components { get; set; }
    }
}