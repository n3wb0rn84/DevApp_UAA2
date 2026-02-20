using System.ComponentModel.DataAnnotations;

namespace Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Request
{
    public class ExampleMessageRequestDto
    {
        [Required]
        [MinLength(5), MaxLength(500)]
        public required string Content { get; set; }
    }
}
