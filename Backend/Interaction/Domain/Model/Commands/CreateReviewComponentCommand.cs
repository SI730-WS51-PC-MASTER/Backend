namespace Backend.Interaction.Domain.Model.Commands;

public record CreateReviewComponentCommand(
    int Rating,
    string Comment,
    string UserName,
    int ComponentId,
    string ComponentName
    );