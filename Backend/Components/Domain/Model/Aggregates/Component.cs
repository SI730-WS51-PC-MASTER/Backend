using Backend.Component.Domain.Model.Commands;
using Backend.Products.Domain.Model.ValueObjects;

namespace Backend.Products.Domain.Model.Aggregates;

public partial class Component
{
    public int id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float Price { get; private set; }
    public int stock { get; private set; }
    public string ProviderId { get; set; }
    public Image Image { get; set; } = new Image();
    public int Ratings { get; set; }
    public Categories Categories { get; set; } = new Categories();
    public Attributes Attributes { get; set; } = new Attributes();
    public string Country { get; set; }

    public Component(int id, string name, string description, float price, int stock, string providerId, int ratings, string country)
    {
        this.id = id;
        Name = name;
        Description = description;
        Price = price;
        this.stock = stock;
        ProviderId = providerId;
        Ratings = ratings;
        Country = country;
    }

    public Component(CreateComponentCommand command)
    {
        
    }
}