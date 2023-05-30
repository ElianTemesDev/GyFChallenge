using Microsoft.AspNetCore.Mvc;
using Server.DTOs.Interfaces;
using Server.Entities.Interfaces;

namespace Server.Services.Interfaces
{
    public interface IService<Dto, Entity> where Dto : IDto where Entity : IEntity
    {
        public Task<ActionResult<IEnumerable<Dto>>> GetAll();
        public Task<ActionResult<Dto>> GetById(int id);
        public Task<ActionResult<Dto>> Post(Dto obj);
        public Entity ToEntity(Dto dto);
        public Dto ToDto(Entity entity);
    }
}
