namespace Backend.Interaction.Interfaces.Rest.Resources;

public record CreateWishlistResource(int UserId, string ComponentName, int QuantityComponents)
{
    
}