namespace LocalLibrary.Domain.Models
{
    public class Language : BaseModel
    {
        public string Name { get; private set; }
        public IEnumerable<Book> Books { get; private set; }
    }
}
