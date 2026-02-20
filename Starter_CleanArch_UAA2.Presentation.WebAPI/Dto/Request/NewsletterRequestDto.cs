using System.ComponentModel.DataAnnotations;

namespace Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Request;

public class NewsletterRequestDto
{
    [Required]
    [EmailAddress]
    [MaxLength(320)]
    public required string Email {  get; set; }

    [Required]
    public required bool IsNews {  get; set; }

    [Required]
    public required bool IsMonthly { get; set; }

    [Required]
    public required bool IsDayFact { get; set; }
}
