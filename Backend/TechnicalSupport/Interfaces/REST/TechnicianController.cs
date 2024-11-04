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
    /// <summary>
    /// Creates a new technician based on the provided resource.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> GetTechnicians([FromBody] CreateTechnicianResource resource)
    {
        var command = CreateTechnicianCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        
        return CreatedAtAction(nameof(GetTechnicianById), new { id = result.Id},
        TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /// <summary>
    /// Gets technicians by their name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet("by-name/{name}")]
    public async Task<ActionResult> GetTechniciansByName(string name)
    {
        var getTechniciansByName = new GetTechnicianByNameQuery(name);
        var result = await queryService.Handle(getTechniciansByName);
        if (result is null) return NotFound();
        var resources = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }
    
    /// <summary>
    /// Gets technicians by their stars rating.
    /// </summary>
    /// <param name="stars"></param>
    /// <returns></returns>
    [HttpGet("by-stars/{stars}")]
    public async Task<ActionResult> GetTechniciansByStars(int stars)
    {
        var getTechniciansByStars = new GetTechnicianByStarsQuery(stars);
        var result = await queryService.Handle(getTechniciansByStars);
        if (result is null) return NotFound();
        var resources = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }

    /// <summary>
    /// Gets technicians based on optional query parameters for name or star rating.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="stars"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult> GetTechnicianFromQuery([FromQuery] string? name = null, [FromQuery] int? stars = null)
    {
        if (!string.IsNullOrEmpty(name))
        {
            // Search technicians by name
            var getTechniciansByName = new GetTechnicianByNameQuery(name);
            var result = await queryService.Handle(getTechniciansByName);
            if (result is null) return NotFound();

            var resources = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resources);
        }
        else if (stars.HasValue)
        {
            // Search technicians by stars number
            var getTechniciansByStars = new GetTechnicianByStarsQuery(stars.Value);
            var result = await queryService.Handle(getTechniciansByStars);
            if (result is null) return NotFound();

            var resources = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resources);
        }
        else
        {
            // If neither name nor stars are specified, we return BadRequest
            return BadRequest("Debe especificar un parámetro de consulta, ya sea 'name' o 'stars'.");
        }
    }
    
    /// <summary>
    /// Gets a technician by their identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetTechnicianById(int id)
    {
        var getTechnicianById = new GetTechnicianByIdQuery(id);
        var result = await queryService.Handle(getTechnicianById);
        if (result is null) return NotFound();
        var resources = TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }
    
    /// <summary>
    /// Updates an existing technician's information.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTechnicianSupport(int id, [FromBody] UpdateTechnicianResource resource)
    {
        var command = UpdateTechnicianCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
    
        if (result is null) return NotFound();

        return Ok(TechnicianResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /// <summary>
    /// Deletes a technician by their identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTechnicianSupport(int id)
    {
        var command = new DeleteTechnicianCommand(id);
        var result = await commandService.Handle(command);
    
        if (!result) return NotFound();

        return NoContent();
    }
}