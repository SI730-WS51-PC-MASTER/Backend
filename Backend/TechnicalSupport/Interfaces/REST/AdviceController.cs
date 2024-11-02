using System.Net.Mime;
using Backend.TechnicalSupport.Domain.Services;
using Backend.TechnicalSupport.Interfaces.REST.Resources;
using Backend.TechnicalSupport.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend.TechnicalSupport.Interfaces.REST;

[ApiController]
[Route("/api/v1/advices")]
[Produces(MediaTypeNames.Application.Json)]
[Tags ("Advices by Technicians")]
public class AdviceController(IAdviceCommandService commandService, 
    IAdviceQueryService queryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetFavoriteTechnicians([FromBody] CreateAdviceResource resource)
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
            new GetAllAdviceByTechnicalSupportApiKeyQuery(technicalSupportApiKey);
        var result = await queryService.Handle(getAllFavoriteTechniciansByTechnicalSupportApiKey);
        var resources = result.Select(FavoriteTechnicianResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    private async Task<ActionResult> GetFavoriteTechniciansByTechnicalSupportApiKeyAndTechniciansId(string technicalSupportApiKey, string technicianId)
    {
        var getFavoriteTechniciansByTechnicalSupportApiKeyAndTechniciansIdQuery = new GetAdviceByTechnicalSupportApiKeyAndTechnicianIdQuery(technicalSupportApiKey, technicianId);
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
        var getFavoriteTechnicianById = new GetAdviceByIdQuery(id);
        var result = await queryService.Handle(getFavoriteTechnicianById);
        if (result is null) return NotFound();
        var resources = FavoriteTechnicianResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFavoriteTechnician(int id, [FromBody] UpdateAdviceResource resource)
    {
        var command = UpdateFavoriteTechnicianCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
    
        if (result is null) return NotFound();

        return Ok(FavoriteTechnicianResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
}