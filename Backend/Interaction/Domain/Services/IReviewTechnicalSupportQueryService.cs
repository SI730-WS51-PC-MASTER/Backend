using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;

namespace Backend.Interaction.Domain.Services;

public interface IReviewTechnicalSupportQueryService
{
    Task<IEnumerable<ReviewTechnicalSupport>> Handle(GetAllReviewTechnicalSupportByTechnicalSupportIdQuery query);
}