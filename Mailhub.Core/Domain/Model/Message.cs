using Mailhub.Core.Domain.ValueObject;

namespace Mailhub.Core.Domain.Model
{
    public class Message
    {
        public Email To { get;  }
        public Email From { get;  }
        public Email? ReplyTo { get; set; }
        public String Subject { get; }
        public String Body { get; }
        public Boolean IsHtml { get; }
        public ICollection<Email> Cc { get; }
        public ICollection<Email> Bcc { get; }


        public Message(Email to, Email from, String subject, String body)
        {
            To = to;
            From = from;
            Subject = subject;
            Body = body;
            IsHtml = true;
            Cc = new List<Email>();
            Bcc = new List<Email>();
        }

        public void SetReplyTo(Email replyTo)
        {
            this.ReplyTo = replyTo;
        }
    }
}