namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record FavoriteTechnicianResource(int id, string TechnicalSupportApiKey, string TechnicianId, string DateOfRequest, string StartDate, string EndDate);