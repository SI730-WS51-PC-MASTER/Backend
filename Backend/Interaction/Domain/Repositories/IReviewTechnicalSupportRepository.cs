using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend. Interaction. Domain. Repositories;

public interface IReviewTechnicalSupportRepository: IBaseRepository<ReviewTechnicalSupport>
{
    Task<IEnumerable<ReviewTechnicalSupport>> FindByTechnicalSupportIdAsync(int technicalSupportId);
}