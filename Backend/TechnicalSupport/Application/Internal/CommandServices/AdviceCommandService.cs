using Backend.Shared.Domain.Repositories;
using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Domain.Services;
using Backend.TechnicalSupport.Infrastructure.Repositories;

namespace Backend.TechnicalSupport.Application.Internal.CommandServices;

public class AdviceCommandService(IAdviceRepository adviceRepository, 
    IUnitOfWork unitOfWork) : IAdviceCommandService
{
    public async Task<Advice?> Handle(CreateAdviceCommand command)
    {
        var favoriteTechnician = 
            await adviceRepository.FindByTechnicalSupportApiKeyAndTechnicianIdAsync(command.TechnicalSupportApiKey, command.TechnicianId);
        if (favoriteTechnician != null) 
            throw new Exception($"Technician with id {command.TechnicianId} already exists.");
        favoriteTechnician = new Advice(command);

        try
        {
            await adviceRepository.AddAsync(favoriteTechnician);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return favoriteTechnician;
    }
    
    public async Task<Advice> Handle(UpdateAdviceCommand command)
    {
        // Fetch the existing technician
        var favoriteTechnician = await adviceRepository.FindByIdAsync(command.Id);

        if (favoriteTechnician == null)
        {
            throw new Exception($"Technician with id {command.TechnicianId} does not exist.");
        }

        // Update the technician's properties
        favoriteTechnician.UpdateProperties(command); // Assuming you have an UpdateProperties method in your Advice class

        try
        {
            // Save the updated technician
            await adviceRepository.UpdateAsync(favoriteTechnician);
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