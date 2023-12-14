using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;

namespace LocalLibrary.Application.Services
{
    public class BookServices : IGenericServices<BookDTO>
    {
        public Task<BookDTO> Create(BookDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BookDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDTO> Update(BookDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
