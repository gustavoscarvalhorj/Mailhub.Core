using System.Net.Mail;

namespace Mailhub.Core.Domain.ValueObject
{
    public class Email
    {
        private string _email { get; }

        public Email(string email)
        {
            if (email == null)
                throw new ArgumentNullException("O email não pode ser nulo");

            if (email.Trim() == "")
                throw new ArgumentException("O email não pode ser vazio");

            if (!IsValid(email))
                throw new ArgumentException("O endereço '" + email + "' não é válido");

            _email = email;
        }

        public override string ToString() => _email;
        

        public bool IsValid(string emailaddress)
        {
            MailAddress? mail;
            MailAddress.TryCreate(emailaddress, out mail);
            return (mail != null);
        }
    }
}
