using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;
using Backend.Shared.Domain.Repositories;

namespace Backend.Interaction.Application.Internal.CommandServices;

public class ReviewComponentCommandService(IReviewComponentRepository reviewComponentRepository,
    IUnitOfWork unitOfWork)
    : IReviewComponentCommandService
{
    public async Task<ReviewComponent?> Handle(CreateReviewComponentCommand command)
    {
        var reviewComponent = new ReviewComponent(command);
        await reviewComponentRepository.AddAsync(reviewComponent);
        await unitOfWork.CompleteAsync();
        return reviewComponent;
    }
}