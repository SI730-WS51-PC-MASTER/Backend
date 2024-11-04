using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public static class ReviewComponentResourceFromEntityAssembler
{
    public static ReviewComponentResource ToResourceFromEntity(ReviewComponent entity)
    {
        return new ReviewComponentResource(entity.Id, entity.Rating, entity.Comment, entity.UserName, entity.ComponentId, entity.ComponentName);
    }
}