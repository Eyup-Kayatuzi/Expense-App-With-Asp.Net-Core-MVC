using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseRepo;
using MasrafUygulamasi.Domain.Entities;
using MasrafUygulamasi.Persistence.Context;

namespace MasrafUygulamasi.Persistence.Repositories.ExpenseRepo
{
	public class ExpenseWriteRepository : WriteRepository<Expense>, IExpenseWriteRepository
	{
        public ExpenseWriteRepository(MasrafUygulamasiDB context): base(context)
        {
            
        }
    }
}
