using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;

namespace Backend.Interaction.Domain.Services;

public interface IReviewTechnicalSupportCommandService
{
    Task<ReviewTechnicalSupport?> Handle(CreateReviewTechnicalSupportCommand command);
}