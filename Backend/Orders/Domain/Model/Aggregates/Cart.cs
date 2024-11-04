namespace Backend.Orders.Domain.Model.Aggregates;

public class Carts
{
    public int Id { get; }

    public int ComponentId { get; set; } // value object
    
    public int UserId { get; set; } // value object
    
    public int Quantity { get; set; }

    protected Carts()
    {
        ComponentId = 0;
        UserId = 0;
        Quantity = 0;
    }
    
    // Command

    //public Carts(CreateCartCommand command)
    //{
    //}
}