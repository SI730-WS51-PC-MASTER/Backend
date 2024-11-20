namespace Backend.Interaction.Domain.Model.Commands;

public record CreateComponentReviewCommand(
    int Rating,
    string Comment,
    string UserName,
    int ComponentId
    );