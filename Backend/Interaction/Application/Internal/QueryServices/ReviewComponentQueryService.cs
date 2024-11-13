using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;

namespace Backend.Interaction.Application.Internal.QueryServices;

public class ReviewComponentQueryService : IReviewComponentQueryService
{
    private readonly IReviewComponentRepository _reviewComponentRepository;

    public ReviewComponentQueryService(IReviewComponentRepository reviewComponentRepository)
    {
        _reviewComponentRepository = reviewComponentRepository;
    }

    public async Task<IEnumerable<ReviewComponent>> Handle(GetAllReviewComponentByComponentIdQuery query)
    {
        return await _reviewComponentRepository.FindReviewComponentByComponentIdAsync(query.ComponentId.CompId);
    }
}