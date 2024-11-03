using Backend.Interaction.Domain.Model.ValueObjects;

namespace Backend.Interaction.Interfaces.Rest.Resources;

public record CreateReviewComponentResource(Rating Rating, string Comment, string UserName, int ComponentId, string ComponentName)
{
    
}