using Starter_CleanArch_UAA2.Domain.Models;

namespace Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Services
{
    public interface IExampleMessageService
    {
        IEnumerable<ExampleMessage> GetAllMessage();
        ExampleMessage? GetRandomMessage();
        ExampleMessage AddMessage(ExampleMessage message);
    }
}
