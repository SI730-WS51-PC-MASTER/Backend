namespace Backend.Interaction.Interfaces.Rest.Resources;

public record CreateReviewComponentResource(int Rating, string Comment, string UserName, int ComponentId, string ComponentName)
{
    
}