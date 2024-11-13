using Backend.Component.Domain.Model.Commands;
using Backend.Component.Domain.Model.ValueObjects;
using Backend.Component.Interfaces.REST.Resources;
using Attributes = Backend.Component.Domain.Model.ValueObjects.Attributes;

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
            new Attributes(resource.Attributes.AttributeList),
            new Categories(resource.Categories.CategoriesList),
            resource.Country
        );
    }
}