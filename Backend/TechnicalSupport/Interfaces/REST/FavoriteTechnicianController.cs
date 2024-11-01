using System.Net.Mime;
using Backend.TechnicalSupport.Domain.Services;
using Backend.TechnicalSupport.Interfaces.REST.Resources;
using Backend.TechnicalSupport.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend.TechnicalSupport.Interfaces.REST;

[ApiController]
[Route("/api/v1/technicians")]
[Produces(MediaTypeNames.Application.Json)]
[Tags ("Favorite Technician")]
public class FavoriteTechnicianController(IFavoriteTechnicianCommandService commandService, 
    IFavoriteTechnicianQueryService queryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetFavoriteTechnicians([FromBody] CreateFavoriteTechnicianResource resource)
    {
        var command = CreateFavoriteTechnicianCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        
        return CreatedAtAction(nameof(GetFavoriteTechnicianById), new { id = result.Id},
        FavoriteTechnicianResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    private async Task<ActionResult> GetAllFavoriteTechniciansByTechnicalSupportApiKey(string technicalSupportApiKey)
    {
        var getAllFavoriteTechniciansByTechnicalSupportApiKey =
            new GetAllFavoriteTechnicianByTechnicalSupportApiKeyQuery(technicalSupportApiKey);
        var result = await queryService.Handle(getAllFavoriteTechniciansByTechnicalSupportApiKey);
        var resources = result.Select(FavoriteTechnicianResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    private async Task<ActionResult> GetFavoriteTechniciansByTechnicalSupportApiKeyAndTechniciansId(string technicalSupportApiKey, string technicianId)
    {
        var getFavoriteTechniciansByTechnicalSupportApiKeyAndTechniciansIdQuery = new GetFavoriteTechnicianByTechnicalSupportApiKeyAndTechnicianIdQuery(technicalSupportApiKey, technicianId);
        var result = await queryService.Handle(getFavoriteTechniciansByTechnicalSupportApiKeyAndTechniciansIdQuery);
        if (result is null) return NotFound();
        var resources = FavoriteTechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }

    [HttpGet]
    public async Task<ActionResult> GetFavoriteTechnicianFromQuery([FromQuery] string technicalSupportApiKey, [FromQuery] string technicianId = "")
    {
        return string.IsNullOrEmpty(technicianId) 
            ? await GetAllFavoriteTechniciansByTechnicalSupportApiKey(technicalSupportApiKey)
            : await GetFavoriteTechniciansByTechnicalSupportApiKeyAndTechniciansId(technicalSupportApiKey, technicianId);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetFavoriteTechnicianById(int id)
    {
        var getFavoriteTechnicianById = new GetFavoriteTechnicianByIdQuery(id);
        var result = await queryService.Handle(getFavoriteTechnicianById);
        if (result is null) return NotFound();
        var resources = FavoriteTechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }
    
    
}