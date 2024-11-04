using Backend.Orders.Domain.Model.Aggregates;
using Backend.Orders.Domain.Model.Commands;
using Backend.Orders.Domain.Repositories;
using Backend.Orders.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Orders.Application.Internal.CommandServices;

public class CartCommandService(ICartRepository cartRepository,
    IUnitOfWork unitOfWork) : ICartCommandService
{
    public async Task<Cart?> Handle(CreateCartCommand command)
    {
        var cart =
            await cartRepository.FindByComponentIdAsync(command.ComponentId);
        if (cart != null)
            throw new Exception("Cart with componentId already exists");

        cart = new Cart(command);

        try
        {
            await cartRepository.AddAsync(cart);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return cart;
    }
}