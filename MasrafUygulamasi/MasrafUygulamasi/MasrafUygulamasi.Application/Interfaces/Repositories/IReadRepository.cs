using System.Linq.Expressions;

namespace MasrafUygulamasi.Application.Interfaces.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T,bool>> predicate);
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetWhereWithInclude(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> predicate2);
        IQueryable<T> GetWhereWithTwoInclude(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> predicate2, Expression<Func<T, object>> predicate3);


    }
}
