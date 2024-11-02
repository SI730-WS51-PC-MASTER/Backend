namespace Backend.Products.Domain.Model.ValueObjects;

public record Image(string Main, List<string> Secondary) {
    public Image() : this(string.Empty, new List<string>()) { }
}