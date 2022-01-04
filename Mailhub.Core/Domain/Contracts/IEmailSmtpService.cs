using Mailhub.Core.Domain.Model;

namespace Mailhub.Core.Domain.Contracts
{
    public interface IEmailSmtpService : IEmailService<Message, SmtpCredentials>
    {
    }
}
