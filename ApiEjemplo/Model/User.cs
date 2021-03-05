using System.Collections.Generic;

namespace ApiEjemplo.Model
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Bike> Bikes { get; set; }
    }
}