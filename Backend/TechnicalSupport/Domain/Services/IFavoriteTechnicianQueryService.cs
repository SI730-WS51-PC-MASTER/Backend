namespace Backend.TechnicalSupport.Domain.Services;

public interface IFavoriteTechnicianQueryService
{
    Task<IEnumerable<FavoriteTechnician>> Handle(GetAllFavoriteTechnicianByTechnicalSupportApiKeyQuery query);
    
    Task<FavoriteTechnician> Handle(GetFavoriteTechnicianByTechnicalSupportApiKeyAndTechnicianIdQuery query);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<FavoriteTechnician> Handle(GetFavoriteTechnicianByIdQuery query);
}