using Starter_CleanArch_UAA2.Domain.Models;
using Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Request;
using Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Response;

namespace Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Mappers
{
    public static class NewsletterMapper
    {
        // Mapper pour convertir du modèle domain vers la response dto de présentation
        public static NewsletterResponseDto ToResponseDto(this NewsletterSignUp data)
        {
            return new NewsletterResponseDto()
            {
                Id = data.Id,
                Email = data.Email,
                IsNews = data.IsNews,
                IsMonthly = data.IsMonthly,
                IsDayFact = data.IsDayFact
            };
        }

        // Mapper pour convertir le requestDto de la présentation vers le modèle du domain
        public static NewsletterSignUp ToDomain(this NewsletterRequestDto dto)
        {
            return new NewsletterSignUp(
                dto.Email,
                dto.IsNews,
                dto.IsMonthly,
                dto.IsDayFact
            );
        }
    }
}
