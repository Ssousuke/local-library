namespace LocalLibrary.Domain.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> GetByIdAsync(Guid id);
        public Task<bool> DeleteByIsAsync(Guid id);
        public Task<IEnumerable<T>> GetAll();
    }
}
