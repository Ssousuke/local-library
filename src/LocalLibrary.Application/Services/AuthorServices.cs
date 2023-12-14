using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;

namespace LocalLibrary.Application.Services
{
    public class AuthorServices : IGenericServices<AuthorDTO>
    {
        public Task<AuthorDTO> Create(AuthorDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorDTO> Update(AuthorDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
