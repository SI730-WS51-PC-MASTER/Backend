using Backend.TechnicalSupport.Domain.Model.Command;

namespace Backend.TechnicalSupport.Domain.Services;

public interface ITechnicianCommandService
{
    Task<Technician?> Handle(CreateTechnicianCommand command);
    
    Task<Technician> Handle(UpdateTechnicianCommand command);
    
    Task<bool> Handle(DeleteTechnicianCommand command);
}