namespace Backend.Interaction.Interfaces.Rest.Resources;

public record CreateReviewTechnicalSupportResource(int Rating, string Comment, string UserName, int TechnicalSupportId, string TechnicalSupport)
{
    
}