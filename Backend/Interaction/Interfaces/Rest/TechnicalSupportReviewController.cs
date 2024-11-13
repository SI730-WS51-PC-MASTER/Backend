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
public class TechnicalSupportReviewController(ITechnicalSupportReviewCommandService technicalSupportReviewCommandService, 
    ITechnicalSupportReviewQueryService technicalSupportReviewQueryService) : ControllerBase
{
    [HttpGet("{technicalSupportId:int}")]
    [SwaggerOperation(
        Summary = "Get reviews by Technical Support ID",
        Description = "Get all reviews for a specific Technical Support ID",
        OperationId = "GetTechnicalSupportById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Reviews found", typeof(IEnumerable<TechnicalSupportReviewResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No reviews found")]
    public async Task<IActionResult> GetAllReviewTechnicalSupportByIdQuery(int technicalSupportId)
    {
        var getAllReviewTechnicalSupportByTechnicalSupportIdQuery = new GetAllTechnicalSupportReviewsByTechnicalSupportIdQuery(technicalSupportId);
        var reviews = await technicalSupportReviewQueryService.Handle(getAllReviewTechnicalSupportByTechnicalSupportIdQuery);

        if (reviews == null || !reviews.Any())
        {
            return NotFound();
        }

        var resources = reviews.Select(TechnicalSupportReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new review technical support",
        Description = "Create a new review technical support",
        OperationId = "CreateReviewTechnicalSupport")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was created", typeof(TechnicalSupportReviewResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review could not be created")]
    public async Task<IActionResult> CreateReviewTechnicalSupport([FromBody] CreateTechnicalSupportReviewResource resource)
    {
        var createReviewTechnicalSupportCommand = CreateTechnicalSupportReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
        var review = await technicalSupportReviewCommandService.Handle(createReviewTechnicalSupportCommand);
        if (review is null)
        {
            return BadRequest();
        }
        var reviewTechnicalSupportResource = TechnicalSupportReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return CreatedAtAction(nameof(GetAllReviewTechnicalSupportByIdQuery), new { technicalSupportId = review.Id }, reviewTechnicalSupportResource);
        

    }
}