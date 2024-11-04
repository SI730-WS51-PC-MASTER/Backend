using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public static class CreateReviewTechnicalSupportCommandFromResourceAssembler
{
    public static CreateReviewTechnicalSupportCommand ToCommandFromResource(CreateReviewTechnicalSupportResource resource)
    {
        return new CreateReviewTechnicalSupportCommand(resource.Rating, resource.Comment, resource.UserName, resource.TechnicalSupportId, resource.TechnicalSupport);
    }
}