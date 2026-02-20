namespace Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Response;

public class NewsletterResponseDto
{
    public long Id { get; set; }
    public string Email { get; set; }
    public bool IsNews { get; set; }
    public bool IsMonthly { get; set; }
    public bool IsDayFact { get; set; }
}
