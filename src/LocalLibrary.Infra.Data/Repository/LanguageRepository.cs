using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;

namespace LocalLibrary.Infra.Data.Repository
{
    public class LanguageRepository : IGenericRepository<Language>
    {
        public Task AddAsync(Language entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByIsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Language>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Language> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Language entity)
        {
            throw new NotImplementedException();
        }
    }
}
