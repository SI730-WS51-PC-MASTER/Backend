namespace Backend.TechnicalSupport.Domain.Model.Command;

public record UpdateTechnicianCommand(
    int Id,
    string Name,
    bool Status,
    int Stars
    );