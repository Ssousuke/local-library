using LocalLibrary.Application.CQRS.Book.Commands;
using LocalLibrary.Application.DTO;

namespace LocalLibrary.Application.Services.IServices
{
    public interface IBookServices
    {
        public Task<BookDTO> GetById(Guid id);
        public Task<IEnumerable<BookDTO>> GetAll();
        public Task<BookDTO> Update(BookUpdateCommand entity);
        public Task<bool> DeleteById(Guid id);
        public Task<BookDTO> Create(BookCreateCommand entity);
    }
}
