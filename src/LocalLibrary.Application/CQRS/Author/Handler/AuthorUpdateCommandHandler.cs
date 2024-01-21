using LocalLibrary.Application.CQRS.Author.Commands;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Author.Handler
{
    public class AuthorUpdateCommandHandler : IRequestHandler<AuthorUpdateCommand, Domain.Models.Author>
    {
        private readonly IGenericRepository<Domain.Models.Author> _authorRepository;

        public AuthorUpdateCommandHandler(IGenericRepository<Domain.Models.Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Domain.Models.Author> Handle(AuthorUpdateCommand request, CancellationToken cancellationToken)
        {
            var author = new Domain.Models.Author(request.AuthorId, request.Name, request.DateOfBirth, request.DateOfDeath);

            if (author is null) throw new ApplicationException(nameof(author));
            return await _authorRepository.UpdateAsync(author);
        }
    }
}
