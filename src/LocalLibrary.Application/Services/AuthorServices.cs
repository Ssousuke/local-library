using AutoMapper;
using LocalLibrary.Application.CQRS.Author.Commands;
using LocalLibrary.Application.CQRS.Author.Queries;
using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;
using MediatR;

namespace LocalLibrary.Application.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AuthorServices(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<AuthorDTO> Create(AuthorCreateCommand entity)
        {
            var result = await _mediator.Send(entity);
            return _mapper.Map<AuthorDTO>(result);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var productRemoveCommand = new AuthorRemoveCommand(id);
            if (productRemoveCommand == null)
                throw new Exception("Entity could not be loaded.");

            return await _mediator.Send(productRemoveCommand);
        }

        public async Task<IEnumerable<AuthorDTO>> GetAll()
        {
            var authors = new GetAuthorsQuery();
            if (authors == null)
                throw new Exception("Entity could not be loaded.");

            var result = await _mediator.Send(authors);
            return _mapper.Map<IEnumerable<AuthorDTO>>(result);
        }

        public async Task<AuthorDTO> GetById(Guid id)
        {
            var auhtorByIdQuery = new GetAuthorByIdQuery(id);
            if (auhtorByIdQuery == null)
                throw new Exception("Entity could not be loaded.");

            var result = await _mediator.Send(auhtorByIdQuery);
            return _mapper.Map<AuthorDTO>(result);
        }

        public async Task<AuthorDTO> Update(AuthorUpdateCommand entity)
        {
            var result = await _mediator.Send(entity);
            return _mapper.Map<AuthorDTO>(result);
        }
    }
}
