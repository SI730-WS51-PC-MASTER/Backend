using Backend.Shared.Domain.Repositories;
using Backend.TechnicalSupport;

namespace Backend.TechnicalSupport.Domain.Repositories;

public interface ITechnicalSupportRepository : IBaseRepository<TechnicalSupport>
{
    Task<IEnumerable<TechnicalSupport>> FindByTechnicalSupportApiKeyAsync(string technicalSupportApiKey);
    
    Task<TechnicalSupport?> FindByTechnicalSupportApiKeyAndTechnicianIdAsync(string technicalSupportApiKey, string technicianId);
    
    Task UpdateAsync(TechnicalSupport technicalSupport);
    
    Task DeleteAsync(TechnicalSupport technicalSupport);
}