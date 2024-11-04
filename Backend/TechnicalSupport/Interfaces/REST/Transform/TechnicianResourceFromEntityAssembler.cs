using Backend.TechnicalSupport;
using Backend.TechnicalSupport.Interfaces.REST.Resources;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform;

public class TechnicianResourceFromEntityAssembler
{
    public static TechnicianResource ToResourceFromEntity(Technician entity)
    {
        return new TechnicianResource(entity.Id, entity.Name, entity.Status, entity.Stars);
    }
}