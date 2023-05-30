using Server.DTOs.Interfaces;

namespace Server.DTOs
{
    public class ProductDTO : IDto
    {
        public string UploadDate { get; } = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
        public int Price { get; set; }
        public string Category { get; set; }
    }
}
