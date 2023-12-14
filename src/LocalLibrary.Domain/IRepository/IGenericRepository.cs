namespace LocalLibrary.Domain.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task<T> GetByIdAsync(Guid id);
        public bool DeleteByIsAsync(Guid id);
        public Task<IEnumerable<T>> GetAll();
    }
}
