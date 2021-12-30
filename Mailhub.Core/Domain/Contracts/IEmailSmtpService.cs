using Mailhub.Core.Domain.Model;

namespace Mailhub.Core.Domain.Contracts
{
    public interface IEmailSmtpService
    {
        Task<Result> SendAsync(Message message, SmtpCredentials smtp);
    }
}
