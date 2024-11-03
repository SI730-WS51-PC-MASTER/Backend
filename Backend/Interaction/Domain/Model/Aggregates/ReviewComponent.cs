using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Model.ValueObjects;

namespace Backend.Interaction.Domain.Model.Aggregates;

public class ReviewComponent
{
    public int Id { get; }
    public Rating Rating { get; private set; }
    public string Comment { get; private set; }
    public string UserName { get; private set; }
    public int ComponentId { get; private set; }
    public string ComponentName { get; private set; }
    

    public ReviewComponent(Rating rating, string comment, string userName, int componentId, string componentName)
    {
        Rating = rating;
        Comment = comment;
        UserName = userName;
        ComponentId = componentId;
        ComponentName = componentName;
    }

    public ReviewComponent(CreateReviewComponentCommand command)
    {
        
    }
}