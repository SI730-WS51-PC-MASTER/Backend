namespace Backend.TechnicalSupport.Domain.Services;

public interface IAdviceQueryService
{
    Task<IEnumerable<Advice>> Handle(GetAllAdviceByTechnicalSupportApiKeyQuery query);
    
    Task<Advice> Handle(GetAdviceByTechnicalSupportApiKeyAndTechnicianIdQuery query);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<Advice> Handle(GetAdviceByIdQuery query);
}