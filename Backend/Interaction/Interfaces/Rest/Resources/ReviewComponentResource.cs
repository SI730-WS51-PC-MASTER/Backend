namespace Backend.Interaction.Interfaces.Rest.Resources;

public record ReviewComponentResource(int Id, int Rating, string Comment, string UserName, int ComponentId, string ComponentName)
{
    
}