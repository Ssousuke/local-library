using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;

namespace LocalLibrary.Application.Services
{
    public class GenreServices : IGenericServices<GenreDTO>
    {
        public Task<GenreDTO> Create(GenreDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GenreDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GenreDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GenreDTO> Update(GenreDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
