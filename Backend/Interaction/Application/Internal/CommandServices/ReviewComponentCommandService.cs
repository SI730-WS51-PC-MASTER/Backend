using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Interaction.Application.Internal.CommandServices;
/// <summary>
/// Initializes a new instance of the <see cref="ReviewComponentCommandService"/> class.
/// </summary>
/// <param name="reviewComponentRepository">Repository for managing component reviews.</param>
/// <param name="unitOfWork"></param>
public class ReviewComponentCommandService(IReviewComponentRepository reviewComponentRepository,
    IUnitOfWork unitOfWork)
    : IReviewComponentCommandService
{
    /// <summary>
    /// Handles the creation of a new component review.
    /// </summary>
    /// <param name="command">The command containing the necessary data to create the component review.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The result contains the created component review, 
    /// or <c>null</c> if it could not be created.
    /// </returns>
    public async Task<ReviewComponent?> Handle(CreateReviewComponentCommand command)
    {
        var reviewComponent = new ReviewComponent(command);
        await reviewComponentRepository.AddAsync(reviewComponent);
        await unitOfWork.CompleteAsync();
        return reviewComponent;
    }
}