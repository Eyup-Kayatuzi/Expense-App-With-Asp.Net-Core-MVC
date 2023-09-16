using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Application.Interfaces.Repositories
{
	public interface IRepository<T> where T : class
    {
        DbSet<T> Tablo { get; }
    }
}
