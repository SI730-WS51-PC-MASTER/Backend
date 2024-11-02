using Backend.TechnicalSupport.Interfaces.REST.Resources;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform;

public static class FavoriteTechnicianResourceFromEntityAssembler
{
    public static AdviceResource ToResourceFromEntity(Advice entity)
    {
        return new AdviceResource(entity.Id, entity.TechnicalSupportApiKey, entity.TechnicianId, entity.DateOfRequest, entity.StartDate, entity.EndDate);
    }
}