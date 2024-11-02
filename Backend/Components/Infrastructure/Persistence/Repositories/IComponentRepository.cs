using Backend.Component.Domain.Model.Aggregates.Component;
using Backend.Shared.Domain.Repositories;
namespace Backend.Component.Infrastructure.Persistence.Repositories;

public interface IComponentRepository : IBaseRepository<Component>
{
    Task<Component?> FindComponentByIdAsync(int id);
}