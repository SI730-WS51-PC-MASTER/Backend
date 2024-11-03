using Backend.TechnicalSupport.Domain.Model.Queries;
using Backend.TechnicalSupport.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Services;

namespace Backend.TechnicalSupport.Application.Internal.QueryServices;

/// <summary>
/// Service to handle query operations for the TechnicalSupport entity. This service provides methods 
/// to retrieve TechnicalSupport instances by various criteria, including API key, technician ID, and ID (the TechnicalSupport entity identifier).
/// </summary>
/// <param name="technicalSupportRepository"> The repository interface for accessing TechnicalSupport data. </param>
public class TechnicalSupportQueryService(ITechnicalSupportRepository technicalSupportRepository) : ITechnicalSupportQueryService
{
    /// <summary>
    /// Retrieves all TechnicalSupport entities associated with a specified Technical Support API key.
    /// </summary>
    /// <param name="query"> The query containing the Technical Support API key. </param>
    /// <returns> An enumerable collection of TechnicalSupport entities associated with the provided API key. </returns>
    public async Task<IEnumerable<TechnicalSupport>> Handle(GetAllTechnicalSupportByApiKeyQuery query)
    {
        return await technicalSupportRepository.FindByTechnicalSupportApiKeyAsync(query.TechnicalSupportApiKey);
    }

    /// <summary>
    /// Retrieves a single TechnicalSupport entity by a specified Technical Support API key and Technician ID.
    /// </summary>
    /// <param name="query"> The query containing the Technical Support API key and Technician ID. </param>
    /// <returns> The TechnicalSupport entity associated with the specified API key and Technician ID, if found; otherwise, null. </returns>
    public async Task<TechnicalSupport> Handle(GetTechnicalSupportByApiKeyAndTechnicianIdQuery query)
    {
        return await technicalSupportRepository.FindByTechnicalSupportApiKeyAndTechnicianIdAsync(query.TechnicalSupportApiKey, query.TechnicianId);
    }

    /// <summary>
    /// Retrieves an TechnicalSupport entity by its unique identifier.
    /// </summary>
    /// <param name="query"> The query containing the unique identifier of the TechnicalSupport entity. </param>
    /// <returns> The TechnicalSupport entity with the specified ID, if found; otherwise, null. </returns>
    public async Task<TechnicalSupport> Handle(GetTechnicalSupportByIdQuery query)
    {
        return await technicalSupportRepository.FindByIdAsync(query.Id);
    }
}