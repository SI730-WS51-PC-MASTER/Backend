using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Model.ValueObjects;

namespace Backend.Interaction.Domain.Model.Aggregates;

public class ReviewTechnicalSupport
{
    public int Id { get; }
    public Rating Rating { get; private set; }
    public string Comment { get; private set; }
    public string UserName { get; private set; }
    public int TechnicalSupportId { get; private set; }
    public string TechnicalSupport { get; private set; }

    public ReviewTechnicalSupport(Rating rating, string comment, string userName, int technicalSupportId, string technicalSupport)
    {
        Rating = rating;
        Comment = comment;
        UserName = userName;
        TechnicalSupportId = technicalSupportId;
        TechnicalSupport = technicalSupport;
    }
    
    public ReviewTechnicalSupport(CreateReviewTechnicalSupportCommand command)
    {
        
    }
}