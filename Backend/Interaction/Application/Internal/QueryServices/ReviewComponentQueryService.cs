using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;

namespace Backend.Interaction.Application.Internal.QueryServices;

public class ReviewComponentQueryService(IReviewComponentRepository reviewComponentRepository):
    IReviewComponentQueryService
{
    public async Task<ReviewComponent?> Handle(GetAllReviewComponentByIdQuery query)
    {
        return await reviewComponentRepository.FindByIdAsync(query.ComponentId);
    }
}