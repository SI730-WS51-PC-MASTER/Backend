using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.Commands;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;
using Backend.Shared.Domain.Repositories;

namespace Backend.Interaction.Application.Internal.CommandServices;

public class ReviewComponentCommandService(IReviewComponentRepository reviewComponentRepository,
    //ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork)
    : IReviewComponentCommandService
{
    public Task<ReviewComponent?> Handle(CreateReviewComponentCommand command)
    {
        throw new NotImplementedException();
    }
}