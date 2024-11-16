using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Model.ValueObjects;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Interfaces.Rest.Resources;
using Backend.Interaction.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Interaction.Interfaces.Rest;

[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Available Wishlist Endpoints")]
public class WishlistController(IWishlistCommandService wishlistCommandService, 
    IWishlistQueryService wishlistQueryService) : ControllerBase
{
    [HttpGet("{userId:int}")]
    [SwaggerOperation(
        Summary = "Get wishlist by user ID",
        Description = "Get wishlist for a specific User ID",
        OperationId = "GetWishlistByUserId")]
    [SwaggerResponse(StatusCodes.Status200OK, "Wishlist found", typeof(IEnumerable<WishlistResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No wishlist found")]
    public async Task<IActionResult> GetWishlistByUserIdQuery(int userId)
    {
        var getWishlistByUserIdQuery = new GetWishlistByUserId(new UserId(userId));
        var wishlist = await wishlistQueryService.Handle(getWishlistByUserIdQuery);

        if (wishlist == null || !wishlist.Any())
        {
            return NotFound();
        }

        var resources = wishlist.Select(WishlistResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpPost("{userId:int}")]
    [SwaggerOperation(
        Summary = "Create a new wishlist",
        Description = "Create a new wishlist",
        OperationId = "CreateWishlist")]
    [SwaggerResponse(StatusCodes.Status200OK, "The wishlist was created", typeof(WishlistResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The wishlist could not be created")]
    public async Task<IActionResult> CreateWishlist([FromBody] CreateWishlistResource resource, int userId)
    {
        var createWishlistCommand = CreateWishlistCommandFromResourceAssembler.ToCommandFromResource(resource, userId);
        var wishlist = await wishlistCommandService.Handle(createWishlistCommand);
        if (wishlist is null)
        {
            return BadRequest();
        }
        var wishlistResource = WishlistResourceFromEntityAssembler.ToResourceFromEntity(wishlist);
        return Ok(wishlistResource);
    }
}