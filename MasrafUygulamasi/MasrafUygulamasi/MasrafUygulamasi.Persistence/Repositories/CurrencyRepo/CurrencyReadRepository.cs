using MasrafUygulamasi.Application.Interfaces.Repositories.CurrencyRepo;
using MasrafUygulamasi.Domain.Entities;
using MasrafUygulamasi.Persistence.Context;

namespace MasrafUygulamasi.Persistence.Repositories.CurrencyRepo
{
    public class CurrencyReadRepository : ReadRepository<CurrencyType>, ICurrencyReadRepository
	{
        public CurrencyReadRepository(MasrafUygulamasiDB context) : base(context) 
        {
            
        }
    }
}
