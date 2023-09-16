using MasrafUygulamasi.Application.Interfaces.Repositories;
using MasrafUygulamasi.Persistence.Context;

namespace MasrafUygulamasi.Persistence.Repositories
{
    public class WriteRepository<T> : Repository<T>, IWriteRepository<T> where T : class
    {
        public WriteRepository(MasrafUygulamasiDB context) : base(context) 
        {
            
        }
        public bool Add(T entity)
        {
            Tablo.Add(entity);
            return Save() > 0;
        }

        public async Task<bool> AddAsync(T entity)
        {
            await Tablo.AddAsync(entity);
            return await SaveAsync() > 0;
        }

        public bool AddRange(IEnumerable<T> entities)
        {
            bool result = false;
            try
            {
                Tablo.AddRange(entities);
                Save();
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            bool result = false;
            try
            {
                await Tablo.AddRangeAsync(entities);
                await SaveAsync();
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool Remove(T entity)
        {
            Tablo.Remove(entity);
            return Save() > 0;
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            bool result = false;
            try
            {
                 Tablo.RemoveRange(entities);
                 Save() ;
                 result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Update(T entity)
        {
            Tablo.Update(entity);
            return Save() > 0;
        }

        public bool UpdateRange(IEnumerable<T> entities)
        {
            bool result = false;
            try
            {
                Tablo.UpdateRange(entities);
                Save();
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
