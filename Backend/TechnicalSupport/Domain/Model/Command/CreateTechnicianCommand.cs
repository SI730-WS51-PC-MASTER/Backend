namespace Backend.TechnicalSupport.Domain.Model.Command;

/// <summary>
/// Command to create technician
/// </summary>
/// <param name="Name"></param>
/// <param name="Status"></param>
/// <param name="Stars"></param>
public record CreateTechnicianCommand(string Name, bool Status, int Stars);