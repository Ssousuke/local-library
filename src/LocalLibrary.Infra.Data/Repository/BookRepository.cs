using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;

namespace LocalLibrary.Infra.Data.Repository
{
    public class BookRepository : IGenericRepository<Author>
    {
        public Task AddAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByIsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
