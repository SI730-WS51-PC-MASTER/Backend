using System.Net.Mime;
using Backend.TechnicalSupport.Domain.Model.Command;
using Backend.TechnicalSupport.Domain.Model.Queries;
using Backend.TechnicalSupport.Domain.Services;
using Backend.TechnicalSupport.Interfaces.REST.Resources;
using Backend.TechnicalSupport.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend.TechnicalSupport.Interfaces.REST;

[ApiController]
[Route("/api/v1/technicians")]
[Produces(MediaTypeNames.Application.Json)]
[Tags ("Technicians")]
public class TechnicianController(ITechnicianCommandService commandService, 
    ITechnicianQueryService queryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetTechnicians([FromBody] CreateTechnicianResource resource)
    {
        var command = CreateTechnicianCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        
        return CreatedAtAction(nameof(GetTechnicianById), new { id = result.Id},
        TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    private async Task<ActionResult> GetTechniciansByName(string name)
    {
        var getTechniciansByName = new GetTechnicianByNameQuery(name);
        var result = await queryService.Handle(getTechniciansByName);
        if (result is null) return NotFound();
        var resources = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }
    
    private async Task<ActionResult> GetTechniciansByStars(int stars)
    {
        var getTechniciansByStars = new GetTechnicianByStarsQuery(stars);
        var result = await queryService.Handle(getTechniciansByStars);
        if (result is null) return NotFound();
        var resources = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }

    [HttpGet]
    public async Task<ActionResult> GetTechnicianFromQuery([FromQuery] string? name = null, [FromQuery] int? stars = null)
    {
        if (!string.IsNullOrEmpty(name))
        {
            // Buscar técnicos por nombre
            var getTechniciansByName = new GetTechnicianByNameQuery(name);
            var result = await queryService.Handle(getTechniciansByName);
            if (result is null) return NotFound();

            var resources = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resources);
        }
        else if (stars.HasValue)
        {
            // Buscar técnicos por estrellas
            var getTechniciansByStars = new GetTechnicianByStarsQuery(stars.Value);
            var result = await queryService.Handle(getTechniciansByStars);
            if (result is null) return NotFound();

            var resources = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resources);
        }
        else
        {
            // Si no se especifica ni nombre ni estrellas, devolvemos BadRequest
            return BadRequest("Debe especificar un parámetro de consulta, ya sea 'name' o 'stars'.");
        }
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetTechnicianById(int id)
    {
        var getTechnicianById = new GetTechnicianByIdQuery(id);
        var result = await queryService.Handle(getTechnicianById);
        if (result is null) return NotFound();
        var resources = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTechnicianSupport(int id, [FromBody] UpdateTechnicianResource resource)
    {
        var command = UpdateTechnicianCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
    
        if (result is null) return NotFound();

        return Ok(TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTechnicianSupport(int id)
    {
        var command = new DeleteTechnicianCommand(id);
        var result = await commandService.Handle(command);
    
        if (!result) return NotFound();

        return NoContent();
    }
}