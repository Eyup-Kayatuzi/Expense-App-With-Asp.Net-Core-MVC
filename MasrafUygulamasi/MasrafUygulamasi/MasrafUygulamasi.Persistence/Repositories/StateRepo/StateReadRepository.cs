using MasrafUygulamasi.Application.Interfaces.Repositories.StateRepo;
using MasrafUygulamasi.Domain.Entities;
using MasrafUygulamasi.Persistence.Context;

namespace MasrafUygulamasi.Persistence.Repositories.StateRepo
{
	public class StateReadRepository : ReadRepository<State>, IStateReadRepository
	{
        public StateReadRepository(MasrafUygulamasiDB context) : base(context) 
        {
            
        }
    }
}
