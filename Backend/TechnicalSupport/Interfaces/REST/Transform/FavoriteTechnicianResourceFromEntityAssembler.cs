using Backend.TechnicalSupport.Interfaces.REST.Resources;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.TechnicalSupport.Interfaces.REST.Transform;

public static class FavoriteTechnicianResourceFromEntityAssembler
{
    public static FavoriteTechnicianResource ToResourceFromEntity(FavoriteTechnician entity)
    {
        return new FavoriteTechnicianResource(entity.Id, entity.TechnicalSupportApiKey, entity.TechnicianId);
    }
}