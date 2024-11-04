using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public static class ReviewTechnicalSupportResourceFromEntityAssembler
{
    public static ReviewTechnicalSupportResource ToResourceFromEntity(ReviewTechnicalSupport entity)
    {
        return new ReviewTechnicalSupportResource(entity.Id, entity.Rating, entity.Comment, entity.UserName, entity.TechnicalSupportId, entity.TechnicalSupport);
    }
}