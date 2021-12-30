namespace Mailhub.Core.Domain.ValueObject
{
    public class Host
    {
        private string _host { get; }

        public Host(string host)
        {
            if (host == null)
                throw new ArgumentNullException("O host não pode ser nulo");

            if (String.IsNullOrWhiteSpace(host))
                throw new ArgumentException("O host não pode ser vazio");

            if ( ! IsValid(host) )
                throw new ArgumentException("O host '"+host+"' informado não é válido.");


            _host = host;
        }

        public override string ToString() => _host;

        private bool IsValid(string host)
        {
            var type = Uri.CheckHostName(host);
            return (type != UriHostNameType.Unknown);
        }
    }
}
