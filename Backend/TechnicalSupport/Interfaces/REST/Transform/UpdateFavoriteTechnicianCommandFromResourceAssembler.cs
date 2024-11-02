using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Interfaces.REST.Resources;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform;

public class UpdateFavoriteTechnicianCommandFromResourceAssembler
{
    public static UpdateAdviceCommand ToCommandFromResource(int id, UpdateAdviceResource resource)
    {
        return new UpdateAdviceCommand
        (
            Id: id,
            TechnicalSupportApiKey: resource.TechnicalSupportApiKey,
            TechnicianId: resource.TechnicianId,
            DateOfRequest: resource.DateOfRequest,
            StartDate: resource.StartDate,
            EndDate: resource.EndDate
            // Map additional properties as needed
        );
    }
}