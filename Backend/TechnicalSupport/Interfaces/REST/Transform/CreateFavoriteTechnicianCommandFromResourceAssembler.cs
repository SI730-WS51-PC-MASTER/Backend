using Backend.TechnicalSupport.Interfaces.REST.Resources;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform;

public class CreateFavoriteTechnicianCommandFromResourceAssembler
{
    public static CreateAdviceCommand ToCommandFromResource(CreateAdviceResource resource)
    {
        return new CreateAdviceCommand(resource.TechnicalSupportApiKey, resource.TechnicianId, resource.SupportType, resource.DateOfRequest, resource.StartDate, resource.EndDate);
    }
}