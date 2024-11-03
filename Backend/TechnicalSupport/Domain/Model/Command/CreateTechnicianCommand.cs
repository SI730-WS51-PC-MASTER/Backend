namespace Backend.TechnicalSupport.Domain.Model.Command;

public record CreateTechnicianCommand(string Name, bool Status, int Stars);