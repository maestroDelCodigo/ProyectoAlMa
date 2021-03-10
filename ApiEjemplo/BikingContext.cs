using ApiEjemplo.Features.Activities;
using ApiEjemplo.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiEjemplo
{
    public class BikingContext : DbContext
    {
        public BikingContext(DbContextOptions<BikingContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}