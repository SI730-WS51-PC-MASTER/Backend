using Backend.Orders.Domain.Model.Aggregates;
using Backend.Orders.Domain.Model.Commands;

namespace Backend.Orders.Domain.Services;

public interface ICartCommandService
{

    Task<Cart?> Handle(CreateCartCommand command);

}