namespace Backend.Component.Domain.Model.ValueObjects;

public record Categories(List<string> Type)
{
    public Categories() : this(new List<string>()) { }
}