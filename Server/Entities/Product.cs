using Server.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Product : IEntity
    {
        public Product(int id, int price, string category)
        {
            Id = id;
            Price = price;
            Category = category;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string UploadDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
        [Required]
        public int Price { get; set; }
        [Required]
        public string Category { get; set; }
    }
}