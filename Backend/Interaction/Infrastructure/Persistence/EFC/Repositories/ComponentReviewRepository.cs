using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.ValueObjects;
using Backend.Interaction.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;

public class ComponentReviewRepository(AppDbContext context) : BaseRepository<ComponentReview>(context), IComponentReviewRepository
{
    public async Task<IEnumerable<ComponentReview>> FindReviewComponentByComponentIdAsync(int componentId)
    {
        return await Context.Set<ComponentReview>()
            .Where(reviewComponent => reviewComponent.ComponentId.CompId == componentId)
            .ToListAsync();
    }
}