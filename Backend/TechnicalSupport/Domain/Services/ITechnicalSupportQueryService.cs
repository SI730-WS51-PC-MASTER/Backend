using Backend.TechnicalSupport.Domain.Model.Queries;

namespace Backend.TechnicalSupport.Domain.Services;

public interface ITechnicalSupportQueryService
{
    Task<IEnumerable<TechnicalSupport>> Handle(GetAllTechnicalSupportByApiKeyQuery query);
    
    Task<TechnicalSupport> Handle(GetTechnicalSupportByApiKeyAndTechnicianIdQuery query);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<TechnicalSupport> Handle(GetTechnicalSupportByIdQuery query);
}