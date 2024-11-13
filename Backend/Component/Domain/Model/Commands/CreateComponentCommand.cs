using Backend.Component.Domain.Model.ValueObjects;

namespace Backend.Component.Domain.Model.Commands;

public record CreateComponentCommand(
    string Name,
    string Description,
    float Price,
    int Stock,
    int ProviderId,
    string Image,
    int Ratings,
    Attributes Attributes,
    Categories Categories,
    string Country
);