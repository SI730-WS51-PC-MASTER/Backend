using Backend.TechnicalSupport.Domain.Model.Queries;

namespace Backend.TechnicalSupport.Domain.Services;

public interface ITechnicianQueryService
{
    Task<Technician> Handle(GetTechnicianByNameQuery query);
    
    Task<Technician> Handle(GetTechnicianByStarsQuery query);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<Technician> Handle(GetTechnicianByIdQuery query);
}