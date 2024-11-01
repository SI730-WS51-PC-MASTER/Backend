using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.TechnicalSupport.Infrastructure.Repositories;

public class FavoriteTechnicianRepository(AppDbContext ctx)
: BaseRepository<FavoriteTechnician>(ctx), IFavoriteTechnicianRepository
{
    public async Task<IEnumerable<FavoriteTechnician>> FindByTechnicalSupportApiKeyAsync(string technicalSupportApiKey)
    {
        return await Context.Set<FavoriteTechnician>().Where(f=>f.TechnicalSupportApiKey == technicalSupportApiKey).ToListAsync();
    }

    public async Task<FavoriteTechnician?> FindByTechnicalSupportApiKeyAndTechnicianIdAsync(string technicalSupportApiKey, string technicianId)
    {
        return await Context.Set<FavoriteTechnician>().FirstOrDefaultAsync(f=>f.TechnicalSupportApiKey == technicalSupportApiKey && f.TechnicianId == technicianId);
    }
}