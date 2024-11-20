using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Model.ValueObjects;

namespace Backend.Interaction.Domain.Model.Aggregates;

public class Wishlist
{
    public int Id { get; }
    public UserId UserId { get; private set; }
    public ComponentName ComponentName { get; private set; }
    public int QuantityComponents { get; private set; }


    public Wishlist()
    {
        UserId = new UserId();
        ComponentName = new ComponentName();
        QuantityComponents = 0;
    }

    public Wishlist(int userId, string componentName, int quantityComponents)
    {
        UserId = new UserId(userId);
        ComponentName = new ComponentName(componentName);
        QuantityComponents = quantityComponents;
    }


    public Wishlist(CreateWishlistCommand command)
    {
        UserId = new UserId(command.UserId);
        ComponentName = new ComponentName(command.ComponentName);
        QuantityComponents = command.QuantityComponents;
    }

    public void Update(UpdateWishlistCommand command)
    {
        QuantityComponents = command.QuantityComponents;
    }
}