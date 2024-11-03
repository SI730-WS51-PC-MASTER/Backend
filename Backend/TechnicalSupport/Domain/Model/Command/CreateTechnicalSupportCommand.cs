namespace Backend.TechnicalSupport.Domain.Model.Command;

/// <summary>
/// Command to create technical support
/// </summary>
/// <param name="TechnicalSupportApiKey"></param>
/// <param name="TechnicianId"></param>
/// <param name="SupportType"></param>
/// <param name="DateOfRequest"></param>
/// <param name="StartDate"></param>
/// <param name="EndDate"></param>
public record CreateTechnicalSupportCommand(string TechnicalSupportApiKey, string TechnicianId, string SupportType, string DateOfRequest, string StartDate, string EndDate);