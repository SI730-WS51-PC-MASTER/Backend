namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record UpdateTechnicianResource()
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public int Stars { get; set; }
}