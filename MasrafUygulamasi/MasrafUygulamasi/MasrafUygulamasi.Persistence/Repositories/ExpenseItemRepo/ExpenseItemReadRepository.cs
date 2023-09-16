using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseItemRepo;
using MasrafUygulamasi.Domain.Entities;
using MasrafUygulamasi.Persistence.Context;

namespace MasrafUygulamasi.Persistence.Repositories.ExpenseItemRepo
{
	public class ExpenseItemReadRepository : ReadRepository<ExpenseItem>, IExpenseItemReadRepository
	{
        public ExpenseItemReadRepository(MasrafUygulamasiDB context) : base(context) 
        {
            
        }
    }
}
