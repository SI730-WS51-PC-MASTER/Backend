using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Interfaces.Rest.Resources;
using Backend.Interaction.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Interaction.Interfaces.Rest;

public class ReviewComponentController(IReviewComponentCommandService reviewComponentCommandService, 
    IReviewComponentQueryService reviewComponentQueryService) : ControllerBase
{
    [HttpGet("{componentId:int}")]
    [SwaggerOperation(
        Summary = "Get a review by its Component id",
        Description = "Get a review by its id",
        OperationId = "GetReviewComponentById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was found", typeof(ReviewComponentResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No review found")]
    public async Task<IActionResult> GetAllReviewComponentByIdQuery(int componentId)
    {
        var getAllReviewComponentByIdQuery = new GetAllReviewComponentByIdQuery(componentId);
        var review = await reviewComponentQueryService.Handle(getAllReviewComponentByIdQuery);
        if (review is null)
        {
            return NotFound();
        }
        var resource = ReviewComponentResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(resource);
    }
    
    
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new review component",
        Description = "Create a new review component",
        OperationId = "CreateReviewComponent")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was created", typeof(ReviewComponentResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review could not be created")]
    public async Task<IActionResult> CreateReviewComponentSupport([FromBody] CreateReviewComponentResource resource)
    {
        var createReviewComponentCommand = CreateReviewComponentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var review = await reviewComponentCommandService.Handle(createReviewComponentCommand);
        if (review is null)
        {
            return BadRequest();
        }
        var reviewComponentResource = ReviewComponentResourceFromEntityAssembler.ToResourceFromEntity(review);
        return CreatedAtAction(nameof(GetAllReviewComponentByIdQuery), new { componentId = review.Id }, reviewComponentResource);
    }
}