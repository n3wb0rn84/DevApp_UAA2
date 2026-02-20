using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Services;
using Starter_CleanArch_UAA2.Domain.Models;
using Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Mappers;
using Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Request;
using Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Response;

namespace Starter_CleanArch_UAA2.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsletterController : ControllerBase
{
    // Dépendance vers le service
    private readonly INewsletterService _newsletterService;

    // Injection via CTOR
    public NewsletterController(INewsletterService newsletterService)
    {
        _newsletterService = newsletterService;
    }
    // Endpoint de récupération d'une subscription
    [HttpGet("{id}")]
    [ProducesResponseType<NewsletterResponseDto>(200)]
    public IActionResult GetById([FromRoute]long id)
    {
        // Récupération de données 
        NewsletterSignUp result = _newsletterService.GetById(id);
        // Transfère en dto depuis le domain
        NewsletterResponseDto dto = result.ToResponseDto();
        // Renvoi la réponse sous forme de dto
        return Ok(dto);
    }
    // Endpoint pour ajouter une subscription
    [HttpPost]
    [ProducesResponseType<NewsletterResponseDto>(201)]
    public IActionResult AddElement(NewsletterRequestDto data)
    {
        // Transfo des données dto en type model domain
        NewsletterSignUp newsletter = data.ToDomain();
        // Ajout des données via le servie
        NewsletterSignUp result = _newsletterService.Create(newsletter);
        // Transfère les données domain vers un objet responsedto
        NewsletterResponseDto dto = result.ToResponseDto();

        // retour de l'objet crée
        return CreatedAtAction(
            nameof(GetById),
            new {
                result.Id
            },dto);
    }
    [HttpDelete]
    [ProducesResponseType(204)]
    public IActionResult Delete(long id)
    {
        _newsletterService.Delete(id);
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult UpdateSub([FromRoute] long id, [FromBody] NewsletterRequestPatchDto dto)
    {
        if(dto.IsNews is not null && dto.IsMonthly is not null && dto.IsDayFact is not null)
        {
            _newsletterService.UpdateNewsChoice(id, (bool)dto.IsNews, (bool)dto.IsMonthly, (bool)dto.IsDayFact);
        }

        return Accepted();
    }

}
