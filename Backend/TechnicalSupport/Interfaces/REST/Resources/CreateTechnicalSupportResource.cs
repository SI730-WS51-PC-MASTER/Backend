namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record CreateTechnicalSupportResource(string TechnicalSupportApiKey, string TechnicianId, string SupportType, string DateOfRequest, string StartDate, string EndDate);