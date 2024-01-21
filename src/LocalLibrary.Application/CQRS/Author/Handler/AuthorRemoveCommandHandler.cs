using LocalLibrary.Application.CQRS.Author.Commands;
using LocalLibrary.Domain.IRepository;
using MediatR;

namespace LocalLibrary.Application.CQRS.Author.Handler
{
    public class AuthorRemoveCommandHandler : IRequestHandler<AuthorRemoveCommand, bool>
    {
        private readonly IGenericRepository<Domain.Models.Author> _authorRepository;

        public AuthorRemoveCommandHandler(IGenericRepository<Domain.Models.Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<bool> Handle(AuthorRemoveCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(request.AuhtorId);

            if (author is null)
                throw new ApplicationException($"Error could not be found.");
            return await _authorRepository.DeleteByIdAsync(author.Id);

        }
    }
}
