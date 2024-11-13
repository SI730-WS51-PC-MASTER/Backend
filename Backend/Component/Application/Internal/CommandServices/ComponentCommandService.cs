using Backend.Component.Domain.Model.Commands;
using Backend.Component.Domain.Repositories;
using Backend.Component.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Component.Application.Internal.CommandServices;

public class ComponentCommandService(
    IComponentRepository componentRepository,
    IUnitOfWork unitOfWork)
    : IComponentCommandService
{
    public async Task<Domain.Model.Aggregates.Component?> Handle(CreateComponentCommand command)
    {
        var component = new Domain.Model.Aggregates.Component(command);
        try
        {
            await componentRepository.AddAsync();
            await unitOfWork.CompleteAsync();
            return component;
        } catch (Exception)
        {
            return null;
        }
    }
}