using Backend.TechnicalSupport.Domain.Model.Command;
using Google.Protobuf.WellKnownTypes;

namespace Backend.TechnicalSupport;

public class TechnicalSupport
{
    public int Id { get; }
    public string TechnicalSupportApiKey { get; set; }
    public string TechnicianId { get; set; }
    public string SupportType { get; set; }
    public string DateOfRequest { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
   
    protected TechnicalSupport()
    {
        TechnicalSupportApiKey = string.Empty;
        TechnicianId = string.Empty;  
        SupportType = string.Empty;
        DateOfRequest = string.Empty;
        StartDate = string.Empty;
        EndDate = string.Empty;
    }

    public TechnicalSupport(CreateTechnicalSupportCommand command)
    {
        TechnicalSupportApiKey = command.TechnicalSupportApiKey;
        TechnicianId = command.TechnicianId;
        SupportType = command.SupportType;
        DateOfRequest = command.DateOfRequest;
        StartDate = command.StartDate;
        EndDate = command.EndDate;
    }
    
    public void UpdateProperties(UpdateTechnicalSupportCommand command)
    {
        this.TechnicalSupportApiKey = command.TechnicalSupportApiKey;
        this.TechnicianId = command.TechnicianId;
        this.SupportType = command.SupportType;
        this.DateOfRequest = command.DateOfRequest;
        this.StartDate = command.StartDate;
        this.EndDate = command.EndDate;
    }
}