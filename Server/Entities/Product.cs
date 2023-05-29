using Server.Entities;

namespace Server.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public int Price { get; set; }
        public string? Category { get; set; }
    }
}