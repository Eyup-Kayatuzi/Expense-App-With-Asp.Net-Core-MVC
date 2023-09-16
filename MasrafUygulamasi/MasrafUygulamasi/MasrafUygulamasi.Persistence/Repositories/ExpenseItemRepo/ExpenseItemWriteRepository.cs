using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseItemRepo;
using MasrafUygulamasi.Domain.Entities;
using MasrafUygulamasi.Persistence.Context;

namespace MasrafUygulamasi.Persistence.Repositories.ExpenseItemRepo
{
	public class ExpenseItemWriteRepository : WriteRepository<ExpenseItem>, IExpenseItemWriteRepository
	{
        public ExpenseItemWriteRepository(MasrafUygulamasiDB context) : base(context)
        {
            
        }
    }
}
