using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;

namespace Backend.Interaction.Application.Internal.QueryServices;

public class ReviewComponentQueryService(IReviewComponentRepository reviewComponentRepository)
    : IReviewComponentQueryService
{
    public async Task<IEnumerable<ReviewComponent>> Handle(GetAllReviewComponentByComponentIdQuery query)
    {
        return await reviewComponentRepository.FindByComponentIdAsync(query.ComponentId);
    }
}