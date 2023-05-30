using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.DTOs;
using Server.Models;
using Server.Services.Interfaces;

namespace Server.Services
{
    public class ProductService : IProductService
    {
        private readonly CommerceContext _context;

        public ProductService(CommerceContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            List<ProductDTO> result = new();

            if(products.Count != 0)
            {
                products.ForEach( product => result.Add(ToDto(product)) );
                return new OkObjectResult(result);
            }
            return new NotFoundResult();
        }

        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            return product != null ? new OkObjectResult(ToDto(product)) : new NotFoundResult();
        }

        public async Task<ActionResult<ProductDTO>> Post(ProductDTO prod)
        {
            Product entity = ToEntity(prod);
            _context.Products.Add(entity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            { 
                return new BadRequestObjectResult("Failed to save product, error: " + ex.Message);
            }

            return new OkObjectResult("Entry successfully added.");
        }

        public async Task<ActionResult<string>> Sale(int budget)
        {
            List<Product> products = await _context.Products.ToListAsync();
            List<Product> productsTypeOne;
            List<Product> productsTypeTwo;

            productsTypeOne = products.FindAll(x => x.Category == "PRODUNO").OrderByDescending(x => x.Price).ToList();
            productsTypeTwo = products.FindAll(x => x.Category == "PRODDOS").OrderByDescending(x => x.Price).ToList();

            return "";
        }

        public ProductDTO ToDto(Product entity)
        {
            return new ProductDTO() { 
                Category = entity.Category,
                Price = entity.Price
            };
        }

        public Product ToEntity(ProductDTO dto)
        {
            return new Product(0, dto.Price, dto.Category);
        }
    }
}
