using Backend.TechnicalSupport.Domain.Services;

namespace Backend.TechnicalSupport.Application.Internal.QueryServices;

public class AdviceQueryService(IAdviceRepository adviceRepository) : IAdviceQueryService
{
    public async Task<IEnumerable<Advice>> Handle(GetAllAdviceByTechnicalSupportApiKeyQuery query)
    {
        return await adviceRepository.FindByTechnicalSupportApiKeyAsync(query.TechnicalSupportApiKey);
    }

    public async Task<Advice> Handle(GetAdviceByTechnicalSupportApiKeyAndTechnicianIdQuery query)
    {
        return await adviceRepository.FindByTechnicalSupportApiKeyAndTechnicianIdAsync(query.TechnicalSupportApiKey, query.TechnicianId);
    }

    public async Task<Advice> Handle(GetAdviceByIdQuery query)
    {
        return await adviceRepository.FindByIdAsync(query.id);
    }
}