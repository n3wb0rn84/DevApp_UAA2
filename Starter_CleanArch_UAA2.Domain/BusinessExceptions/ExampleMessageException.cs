namespace Starter_CleanArch_UAA2.Domain.BusinessExceptions
{
    public class ExampleMessageException : Exception
    {
        public ExampleMessageException(string message) : base(message) { }
    }

    public class ExampleMessageInvalidException : ExampleMessageException
    {
        public ExampleMessageInvalidException() : base("Le contenu du message est invalide") { }
    }
}
