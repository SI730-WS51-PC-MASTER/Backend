using Backend.Interaction.Domain.Model.ValueObjects;

namespace Backend.Interaction.Domain.Model.Commands;

public record CreateReviewComponentCommand(
    Rating Rating,
    string Comment,
    string UserName,
    int ComponentId,
    string ComponentName
    );