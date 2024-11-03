using Backend.TechnicalSupport;
using Backend.TechnicalSupport.Domain.Model.Queries;
using Backend.TechnicalSupport.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Services;

namespace Backend.TechnicalSupport.Application.Internal.QueryServices;

public class TechnicianQueryService(ITechnicianRepository technicianRepository) : ITechnicianQueryService
{
    
    public async Task<Technician> Handle(GetTechnicianByNameQuery query)
    {
        return await technicianRepository.FindByNameAsync(query.Name);
    }


    public async Task<Technician> Handle(GetTechnicianByStarsQuery query)
    {
        return await technicianRepository.FindByStarsAsync(query.Stars);
    }


    public async Task<Technician> Handle(GetTechnicianByIdQuery query)
    {
        return await technicianRepository.FindByIdAsync(query.Id);
    }
}