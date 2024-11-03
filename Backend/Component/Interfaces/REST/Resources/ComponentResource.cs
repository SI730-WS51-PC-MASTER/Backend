using Backend.Component.Domain.Model.ValueObjects;

namespace Backend.Component.Interfaces.REST.Resources
{
    public record ComponentResource(
        int ComponentId,
        string Name,
        string Description,
        float Price,
        int Stock,
        string ProviderId,
        Image Image,
        int Ratings,
        Categories Categories,
        Attributes Attributes,
        string Country
    );
}
public abstract record ImageResource(string Main, List<string> Secondary);
public abstract record CategoriesResource(List<string> Type);
public abstract record AttributesResource(Dictionary<string, string> AttributeList);
