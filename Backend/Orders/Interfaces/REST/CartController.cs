using System.Net.Mime;
using Backend.Orders.Domain.Model.Aggregates;
using Backend.Orders.Domain.Model.Queries;
using Backend.Orders.Domain.Services;
using Backend.Orders.Interfaces.REST.Resource;
using Backend.Orders.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Orders.Interfaces.REST;

[ApiController]
[Route("/api/v1/cart")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Cart")]
public class CartController(
    ICartCommandService cartCommandService,
    ICartQueryService cartQueryService) : ControllerBase
{
    /// <summary>
    /// Create a new cart
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a cart",
        Description = "Create a cart source",
        OperationId = "CreateCart")]
    [SwaggerResponse(201, "Cart was created", typeof(Cart))]
    [SwaggerResponse(400, "Cart was not created")]
    public async Task<ActionResult> CreateCart([FromBody] CreateCartResource resource)
    {
        var command = CreateCartCommandFromResourceAssembler.toCommandFromResource(resource);
        var result = await cartCommandService.Handle(command);
        if (result is null) return BadRequest();
        
        //return CreatedAtAction(nameof())
        return Ok(command);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get carts",
        Description = "Get carts",
        OperationId = "GetCarts")]
    [SwaggerResponse(StatusCodes.Status200OK, "Carts", typeof(IEnumerable<Cart>))]
    public async Task<IActionResult> GetCarts()
    {
        var getCartsByUserIdQuery = new GetCartsByUserId(0); // TODO modify for path variable
        var carts = await cartQueryService.Handle(getCartsByUserIdQuery);
        var cartResource = carts.Select(CartResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(cartResource);
    }
}