using FluentAssertions;
using LocalLibrary.Domain.Models;

namespace DomainTest
{
    public class BookUnitTest
    {
        [Fact(DisplayName = "Create Valid Book throws DoaminException")]
        public void Create_Book_Valid_Throws_DoaminException()
        {
            Action action = () => new Book(
                "It a Coisa",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry",
                "123.456/789-1234",
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            );

            action.Should().NotThrow<LocalLibrary.Domain.ValidationDomainException.DomainException>();
        }

        [Fact(DisplayName = "Update Method Valid Book throws DoaminException")]
        public void Update_Book_Valid()
        {
            var book = new Book(
                "It a Coisa",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry",
                "123.456/789-1234",
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            );

            Assert.Equal(book.Title, "It a Coisa");
            book.UpdateTitle("It a coisa 2");
            Assert.Equal(book.Title, "It a coisa 2");
        }

        [Fact(DisplayName = "Create Book Invalid Title Length Throws DomainException")]
        public void Create_Book_Invalid_Title_Length__Throws_DoaminException()
        {
            Action action = () => new Book(
                "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. ",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry",
                "123.456/789-1234",
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            ); ;
            action.Should().Throw<LocalLibrary.Domain.ValidationDomainException.DomainException>();
        }

        [Fact(DisplayName = "Create Book Invalid Summary Length Throws DomainException")]
        public void Create_Book_Invalid_Summary_Length__Throws_DoaminException()
        {
            Action action = () => new Book(
                "It is a layout.",
                "It is a long established fact that a reader will be" +
                " distracted by the readable content of a page when looking " +
                "at its layout.It is a long established fact that a " +
                "reader will be distracted by the readable content of " +
                "a page when looking at its layout. At its layout.",
                "123.456/789-1234",
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            ); ;
            action.Should().Throw<LocalLibrary.Domain.ValidationDomainException.DomainException>();
        }

        [Fact(DisplayName = "Create Book Invalid ISBN Length Throws DomainException")]
        public void Create_Book_Invalid_ISBN_Length__Throws_DoaminException()
        {
            Action action = () => new Book(
                "It is a layout.",
                "It is a long established fact that a reader will be",
                "123.456/789-12346",
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            ); ;
            action.Should().Throw<LocalLibrary.Domain.ValidationDomainException.DomainException>();
        }
    }
}
