using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;

namespace Backend.Interaction.Domain.Services;

public interface IWishlistCommandService
{
    Task<Wishlist?> Handle(CreateWishlistCommand command);
}