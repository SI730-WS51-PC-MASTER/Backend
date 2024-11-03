using Backend.Shared.Domain.Repositories;

namespace Backend.Component.Domain.Repositories;

public interface IComponentRepository : IBaseRepository<Model.Aggregates.Component>
{
    Task<Model.Aggregates.Component?> GetComponentByIdAsync(Guid componentId);
}