namespace Backend.Interaction.Interfaces.Rest.Resources;

public record ReviewTechnicalSupportResource(int Id, int Rating, string Comment, string UserName, int TechnicalSupportId, string TechnicalSupport)
{
    
}