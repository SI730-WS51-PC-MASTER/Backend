using Backend.TechnicalSupport.Domain.Model.Command;

namespace Backend.TechnicalSupport;

public class Technician
{
    /// <summary>
    /// Entity Identifier
    /// </summary>
    public int Id { get; }
    
    /// <summary>
    /// Technician Name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Technician Status could be available (if true) or unavailable (if false)
    /// </summary>
    public bool Status { get; set; }
    
    /// <summary>
    /// Stars Quantity (maximum could be five stars)
    /// </summary>
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