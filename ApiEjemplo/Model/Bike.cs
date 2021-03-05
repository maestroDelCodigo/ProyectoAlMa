using System.Collections.Generic;

namespace ApiEjemplo.Model
{
    public class Bike : Entity
    {
        public string Brand { get; set; }
        public double Distance { get; set; }
        public string Model { get; set; }
        public User User { get; set; }
        public ICollection<Component> Components { get; set; }
    }

    // Por cada agregado debemos tener una raíz

    // AGREGADOS
    // UNO POR CADA ENTIDAD
    // * Bike => *Bike*, Component
    // * User => *User*
    
    // OTRA MANERA

}