using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public static class CreateReviewComponentCommandFromResourceAssembler
{
    public static CreateReviewComponentCommand ToCommandFromResource(CreateReviewComponentResource resource)
    {
        return new CreateReviewComponentCommand(resource.Rating, resource.Comment, resource.UserName, resource.ComponentId, resource.ComponentName);
    }
}