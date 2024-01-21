using LocalLibrary.Domain.ValidationDomainException;
using System.Runtime.Serialization;

namespace LocalLibrary.Domain.Models
{
    public class Genre : BaseModel
    {

        public string Name { get; private set; }

        [IgnoreDataMember]
        public IEnumerable<Book> Books { get; private set; }

        public void ValidateDomain(string name)
        {
            DomainException.When(string.IsNullOrEmpty(name), "name is required");
            DomainException.When(name.Length > 25, "max length is 25");

            Name = name;
        }

        public Genre(string name)
        {
            ValidateDomain(name);
        }

        public Genre(Guid id, string name)
        {
            ValidateDomain(name);
            this.Id = id;
        }
    }
}
