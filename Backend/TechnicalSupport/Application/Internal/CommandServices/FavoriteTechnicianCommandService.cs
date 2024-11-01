using Backend.Shared.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Services;
using Backend.TechnicalSupport.Infrastructure.Repositories;

namespace Backend.TechnicalSupport.Application.Internal.CommandServices;

public class FavoriteTechnicianCommandService(IFavoriteTechnicianRepository favoriteTechnicianRepository, 
    IUnitOfWork unitOfWork) : IFavoriteTechnicianCommandService
{
    public async Task<FavoriteTechnician?> Handle(CreateFavoriteTechnicianCommand command)
    {
        var favoriteTechnician = 
            await favoriteTechnicianRepository.FindByTechnicalSupportApiKeyAndTechnicianIdAsync(command.TechnicalSupportApiKey, command.TechnicianId);
        if (favoriteTechnician != null) 
            throw new Exception($"Technician with id {command.TechnicianId} already exists.");
        favoriteTechnician = new FavoriteTechnician(command);

        try
        {
            await favoriteTechnicianRepository.AddAsync(favoriteTechnician);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return favoriteTechnician;
    }
}