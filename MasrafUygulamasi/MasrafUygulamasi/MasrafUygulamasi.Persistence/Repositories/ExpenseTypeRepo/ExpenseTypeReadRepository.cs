using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseTpyeRepo;
using MasrafUygulamasi.Domain.Entities;
using MasrafUygulamasi.Persistence.Context;

namespace MasrafUygulamasi.Persistence.Repositories.ExpenseTypeRepo
{
	public class ExpenseTypeReadRepository: ReadRepository<ExpenseType>, IExpenseTypeReadRepository
    {
        public ExpenseTypeReadRepository(MasrafUygulamasiDB context) : base(context)
        {
            
        }
    }
}
