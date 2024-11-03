using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;

namespace Backend.Interaction.Domain.Services;

public interface IReviewComponentCommandService
{
    Task<ReviewComponent?> Handle(CreateReviewComponentCommand command);
}