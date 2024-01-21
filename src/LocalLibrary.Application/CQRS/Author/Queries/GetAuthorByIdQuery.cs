using MediatR;

namespace LocalLibrary.Application.CQRS.Author.Queries
{
    public class GetAuthorByIdQuery : IRequest<Domain.Models.Author>
    {
        public GetAuthorByIdQuery(Guid authorId)
        {
            AuthorId = authorId;
        }

        public Guid AuthorId { get; set; }
    }
}
