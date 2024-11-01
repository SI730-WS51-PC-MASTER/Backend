using Backend.TechnicalSupport.Interfaces.REST.Resources;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform;

public class CreateFavoriteTechnicianCommandFromResourceAssembler
{
    public static CreateFavoriteTechnicianCommand ToCommandFromResource(CreateFavoriteTechnicianResource resource)
    {
        return new CreateFavoriteTechnicianCommand(resource.TechnicalSupportApiKey, resource.TechnicianId, resource.SupportType, resource.DateOfRequest, resource.StartDate, resource.EndDate);
    }
}