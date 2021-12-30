using Mailhub.Core.Domain.Model;
using Mailhub.Core.Domain.ValueObject;
using System.Net.Mail;

namespace Mailhub.Core.Resource.ExtensionMethods
{
    public static class EmailExtension
    {
        public static MailAddress toMailAddress(this Email address)
        {
            return new MailAddress(address.ToString());
        }

    }
}
