namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record AdviceResource(int id, string TechnicalSupportApiKey, string TechnicianId, string DateOfRequest, string StartDate, string EndDate);