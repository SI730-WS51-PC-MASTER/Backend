using Backend.TechnicalSupport;
using Backend.TechnicalSupport.Domain.Model.Queries;
using Backend.TechnicalSupport.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Services;

namespace Backend.TechnicalSupport.Application.Internal.QueryServices;

public class TechnicianQueryService(ITechnicianRepository technicianRepository) : ITechnicianQueryService
{
    /// <summary>
    /// Retrieves a single Technician entity by a specified Name.
    /// </summary>
    /// <param name="query"></param>
    /// <returns> The Technician entity associated with the specified Name </returns>
    public async Task<Technician> Handle(GetTechnicianByNameQuery query)
    {
        return await technicianRepository.FindByNameAsync(query.Name);
    }

    /// <summary>
    /// Retrieves a single Technician entity by a specified Stars Quantity.
    /// </summary>
    /// <param name="query"></param>
    /// <returns> The Technician entity associated with the specified Stars Quantity </returns>
    public async Task<Technician> Handle(GetTechnicianByStarsQuery query)
    {
        return await technicianRepository.FindByStarsAsync(query.Stars);
    }

    /// <summary>
    /// Retrieves a Technician entity by its unique identifier.
    /// </summary>
    /// <param name="query"></param>
    /// <returns> The Technician entity with the specified ID, if found; otherwise, null. </returns>
    public async Task<Technician> Handle(GetTechnicianByIdQuery query)
    {
        return await technicianRepository.FindByIdAsync(query.Id);
    }
}