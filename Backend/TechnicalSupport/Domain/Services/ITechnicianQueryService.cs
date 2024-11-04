using Backend.TechnicalSupport.Domain.Model.Queries;

namespace Backend.TechnicalSupport.Domain.Services;

public interface ITechnicianQueryService
{
    /// <summary>
    /// Retrieves a Technician record based on the technician's name.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<Technician> Handle(GetTechnicianByNameQuery query);
    
    /// <summary>
    /// Retrieves a Technician record based on their rating in stars.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<Technician> Handle(GetTechnicianByStarsQuery query);
    
    /// <summary>
    /// Retrieves a Technician record by its unique identifier.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<Technician> Handle(GetTechnicianByIdQuery query);
}