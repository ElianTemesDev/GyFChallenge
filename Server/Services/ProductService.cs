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

        //Trae todos los productos existentes y devuelve un estado 200 Ok o si no encuentra nada devuelve un 404 not found
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            List<ProductDTO> result = new();

            if (products.Count != 0)
            {
                products.ForEach(product => result.Add(ToDto(product)));
                return new OkObjectResult(result);
            }
            return new NotFoundResult();
        }

        //Busca un producto especifico por id y lo devuelve en forma de dto junto a un estado 200 ok, en caso de no existir devuelve un not found
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            return product != null ? new OkObjectResult(ToDto(product)) : new NotFoundResult();
        }

        /*
            Permite cargar un producto nuevo, en caso de error devuelve un codigo 400 bad request junto al 
            mensaje de la excepcion, en caso de funcionar devuelve un codigo 200 Ok
        */
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

        //Filtra en base al presupuesto y arma la venta optima siguiendo las reglas planteadas en el challenge
        public async Task<ActionResult<string>> Sale(int budget)
        {
            List<Product> products = await _context.Products.ToListAsync();
            List<Product> productsTypeOne = products.FindAll(x => x.Category == "PRODUNO" && x.Price < budget).OrderByDescending(x => x.Price).ToList();
            List<Product> productsTypeTwo = products.FindAll(x => x.Category == "PRODDOS" && x.Price < budget).OrderByDescending(x => x.Price).ToList();

            if(productsTypeOne.Count == 0 || productsTypeTwo.Count == 0)
            {
                return "No existe una oferta para ese presupuesto";
            }                              

            int priceTypeOne = productsTypeOne[0].Price;
            int priceTypeTwo = productsTypeTwo[0].Price;
            int idProdOne = productsTypeOne[0].Id;
            int idProdTwo = productsTypeTwo[0].Id;

            for (int indexTypeOne = 1; indexTypeOne < productsTypeOne.Count; indexTypeOne++)
            {
                for (int indexTypeTwo = 1; indexTypeTwo < productsTypeTwo.Count; indexTypeTwo++)
                {
                    if (priceTypeOne + priceTypeTwo > budget)
                    {
                        idProdTwo = productsTypeTwo[indexTypeTwo].Id;
                        priceTypeTwo = productsTypeTwo[indexTypeTwo].Price;
                    }
                }
                if (priceTypeOne + priceTypeTwo > budget)
                {
                    idProdOne = productsTypeOne[indexTypeOne].Id;
                    priceTypeOne = productsTypeOne[indexTypeOne].Price;
                }
            }

            if(priceTypeOne + priceTypeTwo > budget)
            {
                return "No existe una oferta para ese presupuesto";
            }

            return $"Presupuesto: {budget}, Id Prod 1: {idProdOne}, Precio: {priceTypeOne}, Id Prod 2: {idProdTwo}, Precio: {priceTypeTwo}";
        }


        //Esto realmente deberia estar en un helper o algo del estilo seguramente pero lo dejo aca por conveniencia.
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
