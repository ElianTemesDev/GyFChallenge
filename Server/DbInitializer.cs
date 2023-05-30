using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Product>().HasData(
                   new Product(1, 150, "PRODUNO"),
                   new Product(2, 180, "PRODUNO"),
                   new Product(3, 15, "PRODUNO"),
                   new Product(4, 20, "PRODUNO"),
                   new Product(5, 250, "PRODDOS"),
                   new Product(6, 500, "PRODDOS"),
                   new Product(7, 5, "PRODDOS"),
                   new Product(8, 800, "PRODDOS")
            );
        }
    }
}
