using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;

namespace Backend.Interaction.Domain.Services;

public interface IReviewComponentQueryService
{
    Task<IEnumerable<ReviewComponent>> Handle(GetAllReviewComponentByComponentIdQuery query);
}