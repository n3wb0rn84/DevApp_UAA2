using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Services;
using Starter_CleanArch_UAA2.Domain.Models;

namespace Starter_CleanArch_UAA2.ApplicationCore.Services
{
    public class ExampleMessageService : IExampleMessageService
    {
        private static List<ExampleMessage> _Messages { get; set; } = [
            new ExampleMessage("Hello World"),
            new ExampleMessage("Exemple de Clean architecture"),
        ];
        private readonly Random _Random;

        public ExampleMessageService(Random random)
        {
            _Random = random;
        }


        public ExampleMessage AddMessage(ExampleMessage message)
        {
            _Messages.Add(message);
            return message;
        }

        public IEnumerable<ExampleMessage> GetAllMessage()
        {
            return _Messages.AsReadOnly();
        }

        public ExampleMessage? GetRandomMessage()
        {
            if (!_Messages.Any())
                return null;

            int index = _Random.Next(0, _Messages.Count());
            return _Messages[index];
        }
    }
}
