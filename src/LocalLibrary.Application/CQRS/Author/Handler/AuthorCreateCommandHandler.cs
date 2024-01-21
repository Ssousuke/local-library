using LocalLibrary.Application.CQRS.Author.Commands;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Author.Handler
{
    public class AuthorCreateCommandHandler : IRequestHandler<AuthorCreateCommand, Domain.Models.Author>
    {
        private readonly IGenericRepository<Domain.Models.Author> _authorRepository;

        public AuthorCreateCommandHandler(IGenericRepository<Domain.Models.Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Domain.Models.Author> Handle(AuthorCreateCommand request, CancellationToken cancellationToken)
        {
            var author = new Domain.Models.Author(request.Name, request.DateOfBirth, request.DateOfDeath);
            if (author is null) throw new ApplicationException(nameof(author));
            return await _authorRepository.AddAsync(author);
        }
    }
}
