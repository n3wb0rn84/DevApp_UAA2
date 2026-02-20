using Starter_CleanArch_UAA2.Domain.BusinessExceptions;

namespace Starter_CleanArch_UAA2.Domain.Models
{
    public class ExampleMessage
    {
        public string Content { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime? UpdateAt { get; private set; }

        public ExampleMessage(string content)
        {
            if(string.IsNullOrWhiteSpace(content)) 
                throw new ExampleMessageInvalidException();

            Content = content;
            CreateAt = DateTime.Now;
            UpdateAt = null;
        }

        public void UpdateContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ExampleMessageInvalidException();

            Content = content;
            UpdateAt = DateTime.Now;
        }
    }
}
