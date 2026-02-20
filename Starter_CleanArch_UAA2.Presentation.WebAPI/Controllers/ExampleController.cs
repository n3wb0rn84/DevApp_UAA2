using Microsoft.AspNetCore.Mvc;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Services;
using Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Mappers;
using Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Request;
using Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Response;

namespace Starter_CleanArch_UAA2.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleMessageService _exampleMessageService;

        public ExampleController(IExampleMessageService exampleMessageService)
        {
            _exampleMessageService = exampleMessageService;
        }


        [HttpGet]
        [ProducesResponseType<IEnumerable<ExampleMessageResponseDto>>(200)]
        public IActionResult GetAll()
        {
            var result = _exampleMessageService.GetAllMessage().Select(ExampleMessageMapper.ToResponse);
            return Ok(result);
        }

        [HttpGet("random")]
        [ProducesResponseType<ExampleMessageResponseDto>(200)]
        public IActionResult GetRandom()
        {
            var result = _exampleMessageService.GetRandomMessage()?.ToResponse();

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType<ExampleMessageResponseDto>(201)]
        public IActionResult Add([FromBody] ExampleMessageRequestDto dto)
        {
            var data = _exampleMessageService.AddMessage(dto.ToDomain());
            return CreatedAtAction(null, data.ToResponse());
        }
    }
}
