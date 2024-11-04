using Backend.Shared.Domain.Repositories;

namespace Backend.Component.Domain.Repositories;

public interface IComponentRepository : IBaseRepository<Model.Aggregates.Component>
{
    Task<Model.Aggregates.Component?> GetComponentByIdAsync(Guid componentId);
    Task<Model.Aggregates.Component> GetComponentsByCategoryAsync(string category);
    Task<Model.Aggregates.Component> GetComponentsByProviderAsync(string providerId);
}