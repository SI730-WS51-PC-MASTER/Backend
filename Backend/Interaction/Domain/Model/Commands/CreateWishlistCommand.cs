namespace Backend.Interaction.Domain.Model.Commands;

public record CreateWishlistCommand(
    int UserId, 
    string ComponentName,
    int QuantityComponents)
{
    
}