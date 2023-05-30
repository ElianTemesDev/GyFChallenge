using Microsoft.AspNetCore.Mvc;
using Server.DTOs;
using Server.Services.Interfaces;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Categories = new[]
        {
            "PRODUNO", "PRODDOS"
        };
        
        private readonly IProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post(ProductDTO prod)
        {
            return await _service.Post(prod);
        }

        [HttpGet("/sale/{budget}")]
        public async Task<ActionResult<string>> Sale(int budget)
        {
            return await _service.Sale(budget);
        }
    }
}