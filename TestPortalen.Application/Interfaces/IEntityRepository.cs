using TestPortalen.Entities;

namespace TestPortalen.Application.Interfaces;

public interface IEntityRepository
{
    Task<ICollection<Entity>> GetAllEntities();
    Task UpdateId(int currentId, int newId);
}