using Google.Protobuf.WellKnownTypes;

namespace Backend.TechnicalSupport;

public class FavoriteTechnician
{
    public int Id { get; }
    public string TechnicalSupportApiKey { get; set; }
    public string TechnicianId { get; set; }

    protected FavoriteTechnician()
    {
        TechnicalSupportApiKey = string.Empty;
        TechnicianId = string.Empty;   
    }

    public FavoriteTechnician(CreateFavoriteTechnicianCommand command)
    {
        TechnicalSupportApiKey = command.TechnicalSupportApiKey;
        TechnicianId = command.TechnicianId;
    }
}