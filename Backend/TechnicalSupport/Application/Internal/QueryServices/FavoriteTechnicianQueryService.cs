using Backend.TechnicalSupport.Domain.Services;

namespace Backend.TechnicalSupport.Application.Internal.QueryServices;

public class FavoriteTechnicianQueryService(IFavoriteTechnicianRepository favoriteTechnicianRepository) : IFavoriteTechnicianQueryService
{
    public async Task<IEnumerable<FavoriteTechnician>> Handle(GetAllFavoriteTechnicianByTechnicalSupportApiKeyQuery query)
    {
        return await favoriteTechnicianRepository.FindByTechnicalSupportApiKeyAsync(query.TechnicalSupportApiKey);
    }

    public async Task<FavoriteTechnician> Handle(GetFavoriteTechnicianByTechnicalSupportApiKeyAndTechnicianIdQuery query)
    {
        return await favoriteTechnicianRepository.FindByTechnicalSupportApiKeyAndTechnicianIdAsync(query.TechnicalSupportApiKey, query.TechnicianId);
    }

    public async Task<FavoriteTechnician> Handle(GetFavoriteTechnicianByIdQuery query)
    {
        return await favoriteTechnicianRepository.FindByIdAsync(query.id);
    }
}