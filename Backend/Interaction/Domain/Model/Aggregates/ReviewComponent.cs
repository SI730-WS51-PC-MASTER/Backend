using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Model.ValueObjects;

namespace Backend.Interaction.Domain.Model.Aggregates;

public class ReviewComponent
{
    public int Id { get; }
    public int Rating { get; private set; }
    public string Comment { get; private set; }
    public UserName UserName { get; private set; }
    public ComponentId ComponentId { get; private set; }
    public ComponentName ComponentName { get; private set; }
    
    public ReviewComponent()
    {
        Rating = 0;
        Comment = "";
        UserName = new UserName();
        ComponentId = new ComponentId();
        ComponentName = new ComponentName();
    }
    

    public ReviewComponent(int rating, string comment, string userName, int componentId, string componentName)
    {
        Rating = rating;
        Comment = comment;
        UserName = new UserName(userName);
        ComponentId = new ComponentId(componentId);
        ComponentName = new ComponentName(componentName);
    }

    public ReviewComponent(CreateReviewComponentCommand command)
    {
        Rating = command.Rating;
        Comment = command.Comment;
        UserName = new UserName(command.UserName);
        ComponentId = new ComponentId(command.ComponentId);
        ComponentName = new ComponentName(command.ComponentName);
    }
}