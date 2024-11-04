using Backend.Shared.Domain.Repositories;

namespace Backend.Component.Infrastructure.Persistence.EFC.Repositories
{
    public interface IComponentRepository : IBaseRepository<System.ComponentModel.Component>
    {
        Task<System.ComponentModel.Component?> FindComponentByIdAsync(int id);
        Task AddAsync();
    }
}