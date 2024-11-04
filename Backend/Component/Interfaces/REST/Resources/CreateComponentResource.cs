namespace Backend.Component.Interfaces.REST.Resources
{
    public record CreateComponentResource(
        string Name,
        string? Description,
        float Price,
        int Stock,
        string ProviderId,
        string Image,
        int Ratings,
        Dictionary<string, string> Attributes,
        List<string> Categories,
        string Country
    );
}