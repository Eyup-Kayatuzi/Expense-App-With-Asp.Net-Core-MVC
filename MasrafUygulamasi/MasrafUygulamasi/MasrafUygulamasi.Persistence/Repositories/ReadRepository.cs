using System.Linq.Expressions;
using MasrafUygulamasi.Application.Interfaces.Repositories;
using MasrafUygulamasi.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Repositories
{
    public class ReadRepository<T> : Repository<T>, IReadRepository<T> where T : class
    {
        public ReadRepository(MasrafUygulamasiDB context) : base(context)
        {
            
        }

		public IQueryable<T> GetAll()
        {
            return Tablo;
        }
        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Tablo.FirstOrDefault(predicate);
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Tablo.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return Tablo.Where(predicate);
        }

        public IQueryable<T> GetWhereWithInclude(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> predicate2)
        {
            return Tablo.Where(predicate).Include(predicate2);
        }

        public IQueryable<T> GetWhereWithTwoInclude(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> predicate2, Expression<Func<T, object>> predicate3)
        {
            return Tablo.Where(predicate).Include(predicate2).Include(predicate3);
        }
    }
}
