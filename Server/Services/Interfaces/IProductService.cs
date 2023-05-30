using Microsoft.AspNetCore.Mvc;
using Server.DTOs;
using Server.DTOs.Interfaces;
using Server.Models;

namespace Server.Services.Interfaces
{
    public interface IProductService : IService<ProductDTO, Product>
    {
        public Task<ActionResult<string>> Sale(int budget);
    }
}
