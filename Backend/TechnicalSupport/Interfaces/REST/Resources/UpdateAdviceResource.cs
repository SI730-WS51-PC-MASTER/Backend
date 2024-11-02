namespace Backend.TechnicalSupport.Interfaces.REST.Resources;

public record UpdateAdviceResource()
{
    public string TechnicalSupportApiKey { get; set; }
    public string TechnicianId { get; set; }
    public string DateOfRequest { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
}