using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;

public class ReviewTechnicalSupportRepository(AppDbContext context) : BaseRepository<ReviewTechnicalSupport>(context), IReviewTechnicalSupportRepository
{
    public async Task<IEnumerable<ReviewTechnicalSupport>> FindByTechnicalSupportIdAsync(int technicalSupportId)
    {
        return await Context.Set<ReviewTechnicalSupport>()
            .Where(reviewTechnicalSupport => reviewTechnicalSupport.TechnicalSupportId == technicalSupportId)
            .ToListAsync();
    }
}