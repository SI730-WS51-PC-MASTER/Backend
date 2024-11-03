namespace Backend.Interaction.Domain.Model.Commands;

public record CreateReviewTechnicalSupportCommand(
    int Rating,
    string Comment,
    string UserName,
    int TechnicalSupportId,
    string TechnicalSupportName
    );