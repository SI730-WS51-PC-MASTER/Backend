using Backend.Component.Domain.Model.Queries;
using Backend.Component.Domain.Services;
using Backend.Component.Interfaces.REST.Resources;
using Backend.Component.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Component.Interfaces.REST;

[ApiController]
[Route("api/[controller]")]

public class ComponentController(
    IComponentCommandService componentCommandService,
    IComponentQueryService componentQueryService)
    : ControllerBase
{
    private readonly IComponentCommandService _componentCommandService = componentCommandService;
    private readonly IComponentQueryService _componentQueryService = componentQueryService;

    
    [HttpGet("{componentId:int}")]
    [SwaggerOperation(
        Summary = "Get a component by its ID",
        Description = "Get a component by its ID",
        OperationId = "GetComponentById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The component was found", typeof(ComponentResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No component found")]
    public async Task<IActionResult> GetComponentById(int componentId)
    {
        var query = new GetComponentByIdQuery(componentId);
        var component = await _componentQueryService.Handle(query); // Usar instancia en lugar de static
        if (component is null)
        {
            return NotFound();
        }
        var resource = ComponentResourceFromEntityAssembler.ToResource(component);
        return Ok(resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new component",
        Description = "Create a new component",
        OperationId = "CreateComponent")]
    [SwaggerResponse(StatusCodes.Status201Created, "The component was created", typeof(ComponentResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The component could not be created")]
    public async Task<IActionResult> CreateComponent([FromBody] CreateComponentResource resource)
    {
        var createComponentCommand = CreateComponentCommandFromResourceAssembler.ToCommand(resource);
        var component = await componentCommandService.Handle(createComponentCommand);
        if (component is null)
        {
            return BadRequest();
        }
        var componentResource = ComponentResourceFromEntityAssembler.ToResource(component);
        return CreatedAtAction(nameof(GetComponentById), new { componentId = component.ComponentId }, componentResource);
    }
}
