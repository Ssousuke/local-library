namespace LocalLibrary.Domain.ValidationDomainException
{
    public class DomainException : Exception
    {
        public DomainException(string err) : base(err) { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainException(error);
        }
    }
}
