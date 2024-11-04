using Backend.Component.Domain.Model.Commands;
using Backend.Component.Interfaces.REST.Resources;

namespace Backend.Component.Interfaces.REST.Transform;

public static class CreateComponentCommandFromResourceAssembler
{
    public static CreateComponentCommand ToCommand(CreateComponentResource resource)
    {
        return new CreateComponentCommand(
            resource.Name,
            resource.Description ?? string.Empty,
            resource.Price,
            resource.Stock,
            resource.ProviderId,
            resource.Image,
            resource.Ratings,
            resource.Attributes,
            resource.Categories,
            resource.Country
        );
    }
}