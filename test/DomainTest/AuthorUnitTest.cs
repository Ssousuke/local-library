using FluentAssertions;
using LocalLibrary.Domain.Models;

namespace DomainTest;

public class AuthorUnitTest
{
    [Fact(DisplayName = "Create Author with Invalid Date of Birth throws DomainException")]
    public void Author_Create_Invalid_DateOfBirth_Throws_DomainException()
    {
        Action action = () => new Author("Wesley Matheus", DateTime.Now.AddDays(1), DateTime.Now);
        action.Should().Throw<LocalLibrary.Domain.ValidationDomainException.DomainException>();
    }


    [Fact(DisplayName = "Create Author with Invalid Date of Death throws DomainException")]
    public void Author_Create_Invalid_DateOfDeath_Throws_DomainException()
    {
        Action action = () => new Author("Wesley Matheus", DateTime.Now, DateTime.Now.AddDays(1));
        action.Should().Throw<LocalLibrary.Domain.ValidationDomainException.DomainException>();
    }

    [Fact(DisplayName = "Create Author without Name throws DomainException")]
    public void Author_Create_Without_Name_Throws_DomainException()
    {
        Action action = () => new Author("", DateTime.Now, DateTime.Now);
        action.Should().Throw<LocalLibrary.Domain.ValidationDomainException.DomainException>();
    }

    [Fact(DisplayName = "Create Author without Date of Death does not throw DomainException")]
    public void Author_Create_Without_Date_Of_Death_Does_Not_Throw_DomainException()
    {
        Action action = () => new Author("Wesley Farias", DateTime.Now, null);
        action.Should().NotThrow<LocalLibrary.Domain.ValidationDomainException.DomainException>();
    }

    [Fact(DisplayName = "Create Author with Name Longer Than 75 Characters throws DomainException")]
    public void Author_Create_With_Name_Longer_Than_75_Characters_Throws_DomainException()
    {
        Action action = () => new Author("It is a long established fact that It is a long established", DateTime.Now, null);
        action.Should().Throw<LocalLibrary.Domain.ValidationDomainException.DomainException>();
    }
}