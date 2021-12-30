namespace Mailhub.Core.Domain.Model
{
    public class Result
    {
        public ICollection<String> Errors { get; }
        
        public bool HasErrors { 
            get {
                return ( Errors.Any() );
            }
        }

        public Result()
        {
            Errors = new List<String>();
        }

        public Result(ICollection<string> errors)        {
            if (errors == null)
                throw new ArgumentNullException("A lista de erros não pode ser nula");
            
            Errors = errors;
        }

    }
}