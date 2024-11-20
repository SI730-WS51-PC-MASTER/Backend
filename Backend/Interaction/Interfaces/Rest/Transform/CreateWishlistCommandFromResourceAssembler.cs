using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Interfaces.Rest.Resources;

namespace Backend.Interaction.Interfaces.Rest.Transform;

public static class CreateWishlistCommandFromResourceAssembler
{
    public static CreateWishlistCommand ToCommandFromResource(CreateWishlistResource resource, int userId)
    {
        return new CreateWishlistCommand(userId, resource.ComponentName, resource.QuantityComponents);
    }
}