using Backend.TechnicalSupport.Interfaces.REST.Resources;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform;

public static class TechnicalSupportResourceFromEntityAssembler
{
    public static TechnicalSupportResource ToResourceFromEntity(TechnicalSupport entity)
    {
        return new TechnicalSupportResource(entity.Id, entity.TechnicalSupportApiKey, entity.TechnicianId, entity.DateOfRequest, entity.StartDate, entity.EndDate);
    }
}