namespace LocalLibrary.Domain.Models
{
    public class Author : BaseModel
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime? DateOfDeath { get; private set; }
        public IEnumerable<Book> Books { get; private set; }
    }
}
