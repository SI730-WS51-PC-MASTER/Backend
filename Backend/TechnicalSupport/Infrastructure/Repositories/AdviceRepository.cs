using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.TechnicalSupport.Infrastructure.Repositories;

public class AdviceRepository(AppDbContext ctx)
: BaseRepository<Advice>(ctx), IAdviceRepository
{
    public async Task<IEnumerable<Advice>> FindByTechnicalSupportApiKeyAsync(string technicalSupportApiKey)
    {
        return await Context.Set<Advice>().Where(f=>f.TechnicalSupportApiKey == technicalSupportApiKey).ToListAsync();
    }

    public async Task<Advice?> FindByTechnicalSupportApiKeyAndTechnicianIdAsync(string technicalSupportApiKey, string technicianId)
    {
        return await Context.Set<Advice>().FirstOrDefaultAsync(f=>f.TechnicalSupportApiKey == technicalSupportApiKey && f.TechnicianId == technicianId);
    }
    
    public async Task UpdateAsync(Advice advice)
    {
        //Update method of DbSet
        Context.Set<Advice>().Update(advice);
        await Context.SaveChangesAsync(); // Ensure you save the changes
    }
}