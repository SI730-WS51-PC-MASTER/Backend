using Backend.Interaction.Domain.Model.Queries;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Interfaces.Rest.Resources;
using Backend.Interaction.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Interaction.Interfaces.Rest;

[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Available Review Technical Support Endpoints")]
public class ReviewTechnicalSupportController(IReviewTechnicalSupportCommandService reviewTechnicalSupportCommandService, 
    IReviewTechnicalSupportQueryService reviewTechnicalSupportQueryService) : ControllerBase
{
    [HttpGet("{TechnicalSupportId:int}")]
    [SwaggerOperation(
        Summary = "Get a review by its Technical Support id",
        Description = "Get a review by its id",
        OperationId = "GetTechnicalSupportById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was found", typeof(ReviewTechnicalSupportResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No review found")]
    public async Task<IActionResult> GetAllReviewTechnicalSupportByIdQuery(int technicalSupportId)
    {
        var getAllReviewTechnicalSupportByIdQuery = new GetAllReviewTechnicalSupportByIdQuery(technicalSupportId);
        var review = await reviewTechnicalSupportQueryService.Handle(getAllReviewTechnicalSupportByIdQuery);
        if (review is null)
        {
            return NotFound();
        }
        var resource = ReviewTechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new review technical support",
        Description = "Create a new review technical support",
        OperationId = "CreateReviewTechnicalSupport")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was created", typeof(ReviewTechnicalSupportResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review could not be created")]
    public async Task<IActionResult> CreateReviewTechnicalSupport([FromBody] CreateReviewTechnicalSupportResource resource)
    {
        var createReviewTechnicalSupportCommand = CreateReviewTechnicalSupportCommandFromResourceAssembler.ToCommandFromResource(resource);
        var review = await reviewTechnicalSupportCommandService.Handle(createReviewTechnicalSupportCommand);
        if (review is null)
        {
            return BadRequest();
        }
        var reviewTechnicalSupportResource = ReviewTechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity(review);
        return CreatedAtAction(nameof(GetAllReviewTechnicalSupportByIdQuery), new { technicalSupportId = review.Id }, reviewTechnicalSupportResource);
        

    }
}