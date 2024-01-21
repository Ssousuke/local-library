using LocalLibrary.Application.CQRS.Author.Commands;
using LocalLibrary.Application.DTO;

namespace LocalLibrary.Application.Services.IServices
{
    public interface IAuthorServices
    {
        public Task<AuthorDTO> GetById(Guid id);
        public Task<IEnumerable<AuthorDTO>> GetAll();
        public Task<AuthorDTO> Update(AuthorUpdateCommand entity);
        public Task<bool> DeleteById(Guid id);
        public Task<AuthorDTO> Create(AuthorCreateCommand entity);
    }
}
