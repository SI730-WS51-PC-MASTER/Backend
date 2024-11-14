using Backend.Component.Domain.Model.Aggregates;
using Backend.Component.Domain.Repositories;
using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Repositories;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Component.Infrastructure.Persistence.EFC.Repositories;
public class ComponentRepository(AppDbContext context) : BaseRepository<Domain.Model.Aggregates.Component>(context), IComponentRepository
{
    public async Task<IEnumerable<Domain.Model.Aggregates.Component>> FindComponentByIdAsync(int componentId)
    {
        return await Context.Set<Domain.Model.Aggregates.Component>()
            .Where(component => component.ComponentId == componentId)
            .ToListAsync();
    }
    public Task<Domain.Model.Aggregates.Component?> GetComponentByIdAsync(Guid componentId)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Model.Aggregates.Component> GetComponentsByCategoryAsync(string category)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Model.Aggregates.Component> GetComponentsByProviderAsync(string providerId)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync()
    {
        throw new NotImplementedException();
    }
}