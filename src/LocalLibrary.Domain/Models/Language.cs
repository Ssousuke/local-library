using System.Runtime.Serialization;

namespace LocalLibrary.Domain.Models
{
    public class Language : BaseModel
    {
        public string Name { get; private set; }

        [IgnoreDataMember]
        public IEnumerable<Book>? Books { get; private set; }
    }
}
