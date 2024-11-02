namespace Backend.TechnicalSupport;

/// <summary>
/// Command to create favorite technician
/// </summary>
/// <param name="TechnicalSupportApiKey"></param>
/// <param name="TechnicianId"></param>
public record CreateAdviceCommand(string TechnicalSupportApiKey, string TechnicianId, string SupportType, string DateOfRequest, string StartDate, string EndDate);