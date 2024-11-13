using Backend.Component.Domain.Model.ValueObjects;

namespace Backend.Component.Interfaces.REST.Resources
{
    public record ComponentResource(
        int ComponentId,
        string Name,
        string Description,
        float Price,
        int Stock,
        int ProviderId,
        string Image,
        int Ratings,
        AttributesResource Attributes,
        CategoriesResource  Categories,
        string Country
    );
}
