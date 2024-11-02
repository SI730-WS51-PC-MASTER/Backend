namespace Backend.TechnicalSupport.Domain.Model.Command;

public record UpdateAdviceCommand    (
    int Id,
    string TechnicalSupportApiKey,
    string TechnicianId,
    string DateOfRequest,
    string StartDate,
    string EndDate
    // Add any additional properties as needed
);