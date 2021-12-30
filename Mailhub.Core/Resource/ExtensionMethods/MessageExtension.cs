using Mailhub.Core.Domain.Model;
using System.Net.Mail;
using System.Linq;

namespace Mailhub.Core.Resource.ExtensionMethods
{
    public static class MessageExtension
    {
        public static MailMessage toMailMessage(this Message message)
        {
            //Build mail message object
            var _from = message.From.toMailAddress();
            var _to = message.To.toMailAddress();
            MailMessage mail = new MailMessage(_from, _to);

            //Add BCC 
            message.Bcc.ToList().ForEach(bcc => mail.Bcc.Add(bcc.toMailAddress()));

            //Add CC 
            message.Cc.ToList().ForEach(cc => mail.Bcc.Add(cc.toMailAddress()));

            //Add message
            mail.IsBodyHtml = message.IsHtml;
            mail.Body = message.Body;
            mail.Subject = message.Subject;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            return mail;
        }

    }
}
