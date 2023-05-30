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
                   new Product(1, 10, "PRODUNO"),
                   new Product(2, 50, "PRODUNO"),
                   new Product(3, 100, "PRODUNO"),
                   new Product(4, 110, "PRODUNO"),
                   new Product(5, 150, "PRODUNO"),
                   new Product(6, 170, "PRODUNO"),
                   new Product(7, 200, "PRODUNO"),
                   new Product(8, 230, "PRODUNO"),
                   new Product(9, 250, "PRODUNO"),
                   new Product(10, 300, "PRODUNO"),
                   new Product(11, 320, "PRODUNO"),
                   new Product(12, 350, "PRODUNO"),
                   new Product(13, 400, "PRODUNO"),
                   new Product(14, 430, "PRODUNO"),
                   new Product(15, 450, "PRODUNO"),
                   new Product(16, 500, "PRODUNO"),
                   new Product(17, 10, "PRODDOS"),
                   new Product(18, 50, "PRODDOS"),
                   new Product(19, 100, "PRODDOS"),
                   new Product(20, 110, "PRODDOS"),
                   new Product(21, 150, "PRODDOS"),
                   new Product(22, 170, "PRODDOS"),
                   new Product(23, 200, "PRODDOS"),
                   new Product(24, 230, "PRODDOS"),
                   new Product(25, 250, "PRODDOS"),
                   new Product(26, 300, "PRODDOS"),
                   new Product(27, 320, "PRODDOS"),
                   new Product(28, 350, "PRODDOS"),
                   new Product(29, 400, "PRODDOS"),
                   new Product(30, 430, "PRODDOS"),
                   new Product(31, 450, "PRODDOS"),
                   new Product(32, 500, "PRODDOS")
            );
        }
    }
}
