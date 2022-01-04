using System.Net.Mail;

namespace Mailhub.Core.Domain.ValueObject
{
    public class Port
    {
        private int _port { get; }

        public Port(int port)
        {
            if (port <= 0)
                throw new ArgumentException("A porta precisa ser um número inteiro maior que 0");

            _port = port;
        }

        public static implicit operator int(Port p) => p._port;

        public override string ToString() => _port.ToString();
    }
}
