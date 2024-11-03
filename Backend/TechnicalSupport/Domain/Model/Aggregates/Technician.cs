using Backend.TechnicalSupport.Domain.Model.Command;

namespace Backend.TechnicalSupport;

public class Technician
{
    public int Id { get; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public int Stars { get; set; }
   
    protected Technician()
    {
        Name = string.Empty;
        Status = false;  
        Stars = 0;
    }

    public Technician(CreateTechnicianCommand command)
    {
        Name = command.Name;
        Status = command.Status;
        Stars = command.Stars;
    }
    
    public void UpdateProperties(UpdateTechnicianCommand command)
    {
        this.Name = command.Name;
        this.Status = command.Status;
        this.Stars = command.Stars;
    }
}