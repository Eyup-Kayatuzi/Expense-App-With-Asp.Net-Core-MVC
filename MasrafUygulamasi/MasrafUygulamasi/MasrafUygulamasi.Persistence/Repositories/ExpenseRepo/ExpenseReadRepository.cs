using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseRepo;
using MasrafUygulamasi.Domain.Entities;
using MasrafUygulamasi.Persistence.Context;

namespace MasrafUygulamasi.Persistence.Repositories.ExpenseRepo
{
	public class ExpenseReadRepository : ReadRepository<Expense>, IExpenseReadRepository
	{
        public ExpenseReadRepository(MasrafUygulamasiDB context) : base(context)
        {
            
        }
    }
}
