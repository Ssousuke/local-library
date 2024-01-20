global using Xunit;
using LocalLibrary.Domain.Models;


public class EntitiesMock
{
    public static Book GetValidBook()
    {
        var book = new Book
            ("It a Coisa",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry",
                "123.456/789-1234",
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
                );

        return book;
    }
}