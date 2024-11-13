using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Interaction.Domain.Model.ValueObjects;
using Backend.Shared.Domain.Repositories;

namespace Backend. Interaction. Domain. Repositories;

public interface IReviewComponentRepository: IBaseRepository<ReviewComponent>
{
    Task<IEnumerable<ReviewComponent>> FindReviewComponentByComponentIdAsync(int componentId);
}