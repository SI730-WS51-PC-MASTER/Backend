using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;

namespace Backend.Interaction.Application.Internal.QueryServices;

public class ReviewTechnicalSupportQueryService(IReviewTechnicalSupportRepository reviewTechnicalSupportRepository):
    IReviewTechnicalSupportQueryService
{
    public async Task<ReviewTechnicalSupport?> Handle(GetAllReviewTechnicalSupportByIdQuery query)
    {
        return await reviewTechnicalSupportRepository.FindByIdAsync(query.TechnicalSupportId);
    }
}