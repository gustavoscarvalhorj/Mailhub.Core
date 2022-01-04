using Mailhub.Core.Domain.Model;

namespace Mailhub.Core.Domain.Contracts
{
    public interface IEmailService<T,Z>
    {
        Task<Result> SendAsync(T p1, Z p2);
    }

    public interface IEmailService<T>
    {
        Task<Result> SendAsync(T p1);
    }
}
