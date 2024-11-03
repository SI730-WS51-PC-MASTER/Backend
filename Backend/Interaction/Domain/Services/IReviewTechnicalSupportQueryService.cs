using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;

namespace Backend.Interaction.Domain.Services;

public interface IReviewTechnicalSupportQueryService
{
    Task<ReviewTechnicalSupport?> Handle(GetAllReviewTechnicalSupportByIdQuery query);
}