namespace Backend.Interaction.Interfaces.Rest.Resources;

public record ComponentReviewResource(int Id, int Rating, string Comment, string UserName, int ComponentId)
{
    
}