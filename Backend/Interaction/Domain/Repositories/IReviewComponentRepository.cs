using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend. Interaction. Domain. Repositories;

public interface IReviewComponentRepository: IBaseRepository<ReviewComponent>
{
    Task<IEnumerable<ReviewComponent>> FindByComponentIdAsync(int componentId);
}