using System.Net.Mime;
using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Domain.Model.Queries;
using Backend.TechnicalSupport.Domain.Services;
using Backend.TechnicalSupport.Interfaces.REST.Resources;
using Backend.TechnicalSupport.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend.TechnicalSupport.Interfaces.REST;

[ApiController]
[Route("/api/v1/technical-support")]
[Produces(MediaTypeNames.Application.Json)]
[Tags ("Technical support services by Technicians")]
public class TechnicalSupportController(ITechnicalSupportCommandService commandService, 
    ITechnicalSupportQueryService queryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetTechnicalSupports([FromBody] CreateTechnicalSupportResource resource)
    {
        var command = CreateTechnicalSupportCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        
        return CreatedAtAction(nameof(GetTechnicalSupportById), new { id = result.Id},
        TechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    private async Task<ActionResult> GetAllTechnicalSupportByApiKey(string technicalSupportApiKey)
    {
        var getAllTechnicalSupportByApiKey =
            new GetAllTechnicalSupportByApiKeyQuery(technicalSupportApiKey);
        var result = await queryService.Handle(getAllTechnicalSupportByApiKey);
        var resources = result.Select(TechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    private async Task<ActionResult> GetTechnicalSupportByApiKeyAndTechniciansId(string technicalSupportApiKey, string technicianId)
    {
        var getTechnicalSupportByApiKeyAndTechniciansId = new GetTechnicalSupportByApiKeyAndTechnicianIdQuery(technicalSupportApiKey, technicianId);
        var result = await queryService.Handle(getTechnicalSupportByApiKeyAndTechniciansId);
        if (result is null) return NotFound();
        var resources = TechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }

    [HttpGet]
    public async Task<ActionResult> GetTechnicalSupportFromQuery([FromQuery] string technicalSupportApiKey, [FromQuery] string technicianId = "")
    {
        return string.IsNullOrEmpty(technicianId) 
            ? await GetAllTechnicalSupportByApiKey(technicalSupportApiKey)
            : await GetTechnicalSupportByApiKeyAndTechniciansId(technicalSupportApiKey, technicianId);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetTechnicalSupportById(int id)
    {
        var getTechnicalSupportById = new GetTechnicalSupportByIdQuery(id);
        var result = await queryService.Handle(getTechnicalSupportById);
        if (result is null) return NotFound();
        var resources = TechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTechnicalSupport(int id, [FromBody] UpdateTechnicalSupportResource resource)
    {
        var command = UpdateTechnicalSupportCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
    
        if (result is null) return NotFound();

        return Ok(TechnicalSupportResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTechnicalSupport(int id)
    {
        var command = new DeleteTechnicalSupportCommand(id);
        var result = await commandService.Handle(command);
    
        if (!result) return NotFound();

        return NoContent();
    }
}