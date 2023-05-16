using TestPortalen.Application.Interfaces;

namespace TestPortalen.Application.Entities;

public class IdGenerator
{
    private readonly IEntityRepository _entityRepository;

    public IdGenerator(IEntityRepository entityRepository)
    {
        _entityRepository = entityRepository;
    }

    public async Task<int> GetNextId()
    {
        var entities = await _entityRepository.GetAllEntities();

        var highestCurrentId = entities.Select(e => e.Id).Max();

        return highestCurrentId + 1;
    }

    public async Task IncreaseIdByTen(int currentId)
    {
        var newId = currentId + 10;

        await _entityRepository.UpdateId(currentId, newId);
    }
}
