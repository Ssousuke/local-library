using AutoMapper;
using LocalLibrary.Application.CQRS.Book.Commands;
using LocalLibrary.Application.CQRS.Genre.Commands;
using LocalLibrary.Application.CQRS.Genre.Queries;
using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;
using MediatR;

namespace LocalLibrary.Application.Services
{
    public class GenreServices : IGenericServices<GenreDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GenreServices(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<GenreDTO> Create(GenreDTO entity)
        {
            var genreCreateCommand = _mapper.Map<BookUpdateCommand>(entity);
            var result = await _mediator.Send(genreCreateCommand);
            return _mapper.Map<GenreDTO>(result);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var genreRemoveCommand = new GenreRemoveCommand(id);
            if (genreRemoveCommand == null)
                throw new Exception("Entity could not be loaded.");

            return await _mediator.Send(genreRemoveCommand);
        }

        public async Task<IEnumerable<GenreDTO>> GetAll()
        {
            var genreByIdQuery = new GetGenresQuery();
            if (genreByIdQuery == null)
                throw new Exception("Entity could not be loaded.");

            var result = await _mediator.Send(genreByIdQuery);
            return _mapper.Map<IEnumerable<GenreDTO>>(result);
        }

        public async Task<GenreDTO> GetById(Guid id)
        {
            var genreByIdQuery = new GetGenreByIdQuery(id);
            if (genreByIdQuery == null)
                throw new Exception("Entity could not be loaded.");

            var result = await _mediator.Send(genreByIdQuery);
            return _mapper.Map<GenreDTO>(result);
        }

        public async Task<GenreDTO> Update(GenreDTO entity)
        {
            var genreUpdateCommand = _mapper.Map<BookUpdateCommand>(entity);
            var result = await _mediator.Send(genreUpdateCommand);
            return _mapper.Map<GenreDTO>(result);
        }
    }
}
