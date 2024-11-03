using Backend.Interaction.Domain.Model.ValueObjects;

namespace Backend.Interaction.Interfaces.Rest.Resources;

public record CreateReviewTechnicalSupportResource(Rating Rating, string Comment, string UserName, int TechnicalSupportId, string TechnicalSupport)
{
    
}