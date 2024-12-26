namespace tp7.Domain.RepositoryInterfaces
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
    }
}
