using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;

namespace Backend.Interaction.Application.Internal.QueryServices;

public class ReviewTechnicalSupportQueryService : IReviewTechnicalSupportQueryService
{
    private readonly IReviewTechnicalSupportRepository _reviewTechnicalSupportRepository;

    public ReviewTechnicalSupportQueryService(IReviewTechnicalSupportRepository reviewTechnicalSupportRepository)
    {
        _reviewTechnicalSupportRepository = reviewTechnicalSupportRepository;
    }

    public async Task<IEnumerable<ReviewTechnicalSupport>> Handle(GetAllReviewTechnicalSupportByTechnicalSupportIdQuery query)
    {
        return await _reviewTechnicalSupportRepository.FindByTechnicalSupportIdAsync(query.TechnicalSupportId);
    }
}