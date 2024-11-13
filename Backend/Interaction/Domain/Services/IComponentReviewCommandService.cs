using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;

namespace Backend.Interaction.Domain.Services;

public interface IComponentReviewCommandService
{
    Task<ComponentReview?> Handle(CreateComponentReviewCommand command);
}