namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record CreateFavoriteTechnicianResource(string TechnicalSupportApiKey, string TechnicianId, string SupportType, string DateOfRequest, string StartDate, string EndDate);