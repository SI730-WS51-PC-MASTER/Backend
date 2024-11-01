using Google.Protobuf.WellKnownTypes;

namespace Backend.TechnicalSupport;

public class FavoriteTechnician
{
    public int Id { get; }
    public string TechnicalSupportApiKey { get; set; }
    public string TechnicianId { get; set; }
    public string SupportType { get; set; }
    public string DateOfRequest { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
   
    protected FavoriteTechnician()
    {
        TechnicalSupportApiKey = string.Empty;
        TechnicianId = string.Empty;  
        SupportType = string.Empty;
        DateOfRequest = string.Empty;
        StartDate = string.Empty;
        EndDate = string.Empty;
    }

    public FavoriteTechnician(CreateFavoriteTechnicianCommand command)
    {
        TechnicalSupportApiKey = command.TechnicalSupportApiKey;
        TechnicianId = command.TechnicianId;
        SupportType = command.SupportType;
        DateOfRequest = command.DateOfRequest;
        StartDate = command.StartDate;
        EndDate = command.EndDate;
    }
}