using LocalLibrary.Application.CQRS.Genre.Commands;
using LocalLibrary.Application.DTO;

namespace LocalLibrary.Application.Services.IServices
{
    public interface IGenreServices
    {
        public Task<GenreDTO> GetById(Guid id);
        public Task<IEnumerable<GenreDTO>> GetAll();
        public Task<GenreDTO> Update(GenreUpdateCommand entity);
        public Task<bool> DeleteById(Guid id);
        public Task<GenreDTO> Create(GenreCreateCommand entity);
    }
}
