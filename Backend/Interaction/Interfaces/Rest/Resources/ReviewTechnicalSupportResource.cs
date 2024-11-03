using Backend.Interaction.Domain.Model.ValueObjects;

namespace Backend.Interaction.Interfaces.Rest.Resources;

public record ReviewTechnicalSupportResource(int Id, Rating Rating, string Comment, string UserName, int TechnicalSupportId, string TechnicalSupport )
{
    
}