namespace Backend.TechnicalSupport.Domain.Model.Command;

public record UpdateTechnicalSupportCommand    (
    int Id,
    string TechnicalSupportApiKey,
    string TechnicianId,
    string SupportType,
    string DateOfRequest,
    string StartDate,
    string EndDate
);