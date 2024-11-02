using Backend.Shared.Domain.Repositories;

namespace Backend.TechnicalSupport;

public interface IAdviceRepository : IBaseRepository<Advice>
{
    Task<IEnumerable<Advice>> FindByTechnicalSupportApiKeyAsync(string technicalSupportApiKey);
    
    Task<Advice?> FindByTechnicalSupportApiKeyAndTechnicianIdAsync(string technicalSupportApiKey, string technicianId);
    
    Task UpdateAsync(Advice advice);
}