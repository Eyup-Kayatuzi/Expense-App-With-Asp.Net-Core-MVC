namespace MasrafUygulamasi.Application.Interfaces.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        bool Add(T entity);
        Task<bool> AddAsync(T entity);
        bool AddRange(IEnumerable<T> entities);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        bool Update(T entity);
        bool UpdateRange(IEnumerable<T> entities);
        bool Remove(T entity);
        bool RemoveRange(IEnumerable<T> entities);
        int Save();
        Task<int> SaveAsync();
    }
}
