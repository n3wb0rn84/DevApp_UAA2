using Starter_CleanArch_UAA2.Domain.Models;
using Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Request;
using Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Response;

namespace Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Mappers
{
    public static class ExampleMessageMapper
    {
        public static ExampleMessageResponseDto ToResponse(this ExampleMessage data)
        {
            return new ExampleMessageResponseDto()
            {
                Content = data.Content,
                UpdateDate = data.UpdateAt ?? data.CreateAt
            };
        }

        public static ExampleMessage ToDomain(this ExampleMessageRequestDto requestDto)
        {
            return new ExampleMessage(
                requestDto.Content
            );
        }
    }
}
