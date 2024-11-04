using Backend.Interaction.Domain.Model.Aggregates;

namespace Backend.Interaction.Domain.Model.Commands;

public record CreateReviewTechnicalSupportCommand(
    int Rating,
    string Comment,
    string UserName,
    int TechnicalSupportId,
    string TechnicalSupport
    )
{
}