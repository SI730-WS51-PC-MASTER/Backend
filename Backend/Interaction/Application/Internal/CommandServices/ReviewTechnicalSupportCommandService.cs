using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Repositories;
using Backend.Interaction.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Interaction.Application.Internal.CommandServices;

public class ReviewTechnicalSupportCommandService(IReviewTechnicalSupportRepository reviewTechnicalSupportRepository,
    IUnitOfWork unitOfWork)
    : IReviewTechnicalSupportCommandService
{
    public async Task<ReviewTechnicalSupport?> Handle(CreateReviewTechnicalSupportCommand command)
    {
        var reviewTechnicalSupport = new ReviewTechnicalSupport(command);
        await reviewTechnicalSupportRepository.AddAsync(reviewTechnicalSupport);
        await unitOfWork.CompleteAsync();
        return reviewTechnicalSupport;
    }
}