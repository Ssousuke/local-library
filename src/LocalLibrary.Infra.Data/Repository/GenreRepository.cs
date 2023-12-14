using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;

namespace LocalLibrary.Infra.Data.Repository
{
    public class GenreRepository : IGenericRepository<Genre>
    {
        public Task AddAsync(Genre entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByIsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Genre>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
