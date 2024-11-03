using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Interfaces.Rest.Resources;
using Backend.Interaction.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Interaction.Interfaces.Rest;
[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Available Review Component Endpoints")]

public class ReviewComponentController(IReviewComponentCommandService reviewComponentCommandService, 
    IReviewComponentQueryService reviewComponentQueryService) : ControllerBase
{
    [HttpGet("{componentId:int}")]
    [SwaggerOperation(
        Summary = "Get a review by Component id",
        Description = "Get all reviews for a specific Component Id",
        OperationId = "GetComponentById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Reviews found", typeof(IEnumerable<ReviewComponentResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No reviews found")]
    public async Task<IActionResult> GetAllReviewComponentByComponentIdQuery(int componentId)
    {
        var getAllReviewComponentByComponentIdQuery = new GetAllReviewComponentByComponentIdQuery(componentId);
        var reviews = await reviewComponentQueryService.Handle(getAllReviewComponentByComponentIdQuery);

        if (reviews == null || !reviews.Any())
        {
            return NotFound();
        }

        var resources = reviews.Select(ReviewComponentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
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
        return CreatedAtAction(nameof(GetAllReviewComponentByComponentIdQuery), new { componentId = review.Id }, reviewComponentResource);
    }
}