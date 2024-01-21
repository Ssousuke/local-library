using AutoMapper;
using LocalLibrary.Application.CQRS.Author.Queries;
using LocalLibrary.Application.CQRS.Book.Commands;
using LocalLibrary.Application.CQRS.Book.Queries;
using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;
using MediatR;

namespace LocalLibrary.Application.Services
{
    public class BookServices : IBookServices
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BookServices(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<BookDTO> Create(BookCreateCommand entity)
        {
            var result = await _mediator.Send(entity);
            return _mapper.Map<BookDTO>(result);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var bookRemoveCommand = new BookRemoveCommand(id);
            if (bookRemoveCommand == null)
                throw new Exception("Entity could not be loaded.");

            return await _mediator.Send(bookRemoveCommand);
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            var book = new GetBooksQuery();
            if (book == null)
                throw new Exception("Entity could not be loaded.");

            var result = await _mediator.Send(book);
            return _mapper.Map<IEnumerable<BookDTO>>(result);
        }

        public async Task<BookDTO> GetById(Guid id)
        {
            var book = new GetAuthorByIdQuery(id);
            if (book == null)
                throw new Exception("Entity could not be loaded.");

            var result = await _mediator.Send(book);
            return _mapper.Map<BookDTO>(result);
        }

        public async Task<BookDTO> Update(BookUpdateCommand entity)
        {
            var result = await _mediator.Send(entity);
            return _mapper.Map<BookDTO>(result);
        }
    }
}
