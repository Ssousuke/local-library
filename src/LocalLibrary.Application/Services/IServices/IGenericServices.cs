namespace LocalLibrary.Application.Services.IServices
{
    public interface IGenericServices<T> where T : class
    {
        public Task<T> GetById(Guid id);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Update(T entity);
        public bool DeleteById(Guid id);
        public Task<T> Create(T entity);
    }
}
