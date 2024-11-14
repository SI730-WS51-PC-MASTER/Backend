using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Component.Domain.Model.Commands;
using Backend.Component.Domain.Model.ValueObjects;

namespace Backend.Component.Domain.Model.Aggregates;

public class Component
{
    public int ComponentId { get; }
    [Required]
    public string Name { get; private set; }
    [Required]
    public string Description { get; private set; }
    public float Price { get; private set; }
    public int Stock { get; private set; }
    [Required]
    public int ProviderId { get; set; }
    [Required]
    public string Image {get; private set;}
    [Required]
    public int Ratings { get; set; }
    public Categories Categories { get; set; } = new Categories();
    public Attributes Attributes { get; set; } = new Attributes();
    public string Country { get; set; }
    
    [NotMapped]
    public List<string> Tags { get; set; } = new List<string>(); 
    public Component(int componentId, string name, string description, float price, int stock, string image, int providerId, int ratings,
        Categories categories,Attributes attributes, string country)
    {
        ComponentId = componentId;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
        ProviderId = providerId;
        Ratings = ratings;
        Categories = categories;
        Attributes = attributes;
        Country = country;
    }

    public Component(CreateComponentCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Price = command.Price;
        Stock = command.Stock;
        ProviderId = command.ProviderId;
        Image = command.Image;
        Ratings = command.Ratings;
        Attributes = command.Attributes;
        
        
        
        Categories = command.Categories;
        Country = command.Country;
    }
    public Component() { }  // Constructor vacío requerido por EF Core

}