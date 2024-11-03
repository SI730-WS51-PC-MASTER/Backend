namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record TechnicalSupportResource(int Id, string TechnicalSupportApiKey, string TechnicianId, string DateOfRequest, string StartDate, string EndDate);