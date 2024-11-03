using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend.TechnicalSupport.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.TechnicalSupport.Infrastructure.Repositories;

public class TechnicalSupportRepository(AppDbContext ctx)
: BaseRepository<TechnicalSupport>(ctx), ITechnicalSupportRepository
{
    public async Task<IEnumerable<TechnicalSupport>> FindByTechnicalSupportApiKeyAsync(string technicalSupportApiKey)
    {
        return await Context.Set<TechnicalSupport>().Where(f=>f.TechnicalSupportApiKey == technicalSupportApiKey).ToListAsync();
    }

    public async Task<TechnicalSupport?> FindByTechnicalSupportApiKeyAndTechnicianIdAsync(string technicalSupportApiKey, string technicianId)
    {
        return await Context.Set<TechnicalSupport>().FirstOrDefaultAsync(f=>f.TechnicalSupportApiKey == technicalSupportApiKey && f.TechnicianId == technicianId);
    }
    
    public async Task UpdateAsync(TechnicalSupport technicalSupport)
    {
        //Update method of DbSet
        Context.Set<TechnicalSupport>().Update(technicalSupport);
        await Context.SaveChangesAsync(); // Ensure you save the changes
    }
    
    public async Task DeleteAsync(TechnicalSupport technicalSupport)
    {
        // Check if the technicalSupport exists in the database
        if (technicalSupport == null)
        {
            throw new ArgumentNullException(nameof(technicalSupport), "TechnicalSupport entity cannot be null.");
        }

        // Remove the entity from the DbSet
        Context.Set<TechnicalSupport>().Remove(technicalSupport);
        await Context.SaveChangesAsync(); // Save changes to the database
    }
}