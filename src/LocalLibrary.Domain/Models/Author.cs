using LocalLibrary.Domain.ValidationDomainException;
using System.Runtime.Serialization;

namespace LocalLibrary.Domain.Models
{
    public class Author : BaseModel
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime? DateOfDeath { get; private set; }

        [IgnoreDataMember]
        public IEnumerable<Book> Books { get; private set; }

        public void ValidateDomain(string name, DateTime dateOfBirth, DateTime? dateOfDeath)
        {
            DomainException.When(string.IsNullOrEmpty(name), "name is required");
            DomainException.When(dateOfBirth > DateTime.Now, "date of birth cannot be greater than current date.");
            DomainException.When(dateOfDeath > DateTime.Now, "date of death cannot be greater than current date.");

            DomainException.When(name.Length > 75, "max length is 75");

            Name = name;
            DateOfBirth = dateOfBirth;
            DateOfDeath = dateOfDeath;
        }

        public Author(string name, DateTime dateOfBirth, DateTime? dateOfDeath)
        {
            ValidateDomain(name, dateOfBirth, dateOfDeath);
        }
    }

}
