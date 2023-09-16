using MasrafUygulamasi.Application.Interfaces.Repositories;
using MasrafUygulamasi.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MasrafUygulamasiDB _context;

        public Repository(MasrafUygulamasiDB context)
        {
            _context = context;
        }
        public DbSet<T> Tablo => _context.Set<T>();
    }
}
