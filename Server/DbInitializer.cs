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
                   new Product() { Id = 1, Price = 3500, Category = "PRODUNO" },
                   new Product() { Id = 2, Price = 2500, Category = "PRODDOS" }
            );
        }
    }
}
