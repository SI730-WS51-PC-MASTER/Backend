using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.ValueObjects;
using Backend.Interaction.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;

public class ReviewComponentRepository(AppDbContext context) : BaseRepository<ReviewComponent>(context), IReviewComponentRepository
{
    public async Task<IEnumerable<ReviewComponent>> FindReviewComponentByComponentIdAsync(int componentId)
    {
        return await Context.Set<ReviewComponent>()
            .Where(reviewComponent => reviewComponent.ComponentId.CompId == componentId)
            .ToListAsync();
    }
}