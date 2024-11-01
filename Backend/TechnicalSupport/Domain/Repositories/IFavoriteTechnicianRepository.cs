using Backend.Shared.Domain.Repositories;

namespace Backend.TechnicalSupport;

public interface IFavoriteTechnicianRepository : IBaseRepository<FavoriteTechnician>
{
    Task<IEnumerable<FavoriteTechnician>> FindByTechnicalSupportApiKeyAsync(string technicalSupportApiKey);
    
    Task<FavoriteTechnician?> FindByTechnicalSupportApiKeyAndTechnicianIdAsync(string technicalSupportApiKey, string technicianId);
}