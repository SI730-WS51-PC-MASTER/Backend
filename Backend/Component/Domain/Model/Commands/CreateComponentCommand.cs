namespace Backend.Component.Domain.Model.Commands;

public record CreateComponentCommand(
    string Name,
    string Description,
    float Price,
    int Stock,
    string ProviderId,
    string Image,
    int Ratings,
    Dictionary<string, string> Attributes,
    List<string> Categories,
    string Country
);