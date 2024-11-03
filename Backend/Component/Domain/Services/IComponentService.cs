namespace Backend.Component.Domain.Services;

public interface IComponentService
{
    Task<Model.Aggregates.Component?> GetComponentByIdAsync(int componentId);
}