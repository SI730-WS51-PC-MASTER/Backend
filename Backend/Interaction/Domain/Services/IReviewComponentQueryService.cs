using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Queries;

namespace Backend.Interaction.Domain.Services;

public interface IReviewComponentQueryService
{
    Task<ReviewComponent?> Handle(GetAllReviewComponentByIdQuery query);
}