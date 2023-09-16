using MasrafUygulamasi.Application.Interfaces.Repositories.CurrencyRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseItemRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseTpyeRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.StateRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.UserRepo;

namespace MasrafUygulamasi.Application.Interfaces
{
	public interface IUnitOfWork : IDisposable
    {
        IUserReadRepository UserRead { get; }
        IUserWriteRepository UserWrite { get; }
        ICurrencyReadRepository CurrencyRead { get; }
        IExpenseTypeReadRepository ExpenseTypeRead { get; }
        IStateReadRepository StateRead { get; }
        IExpenseReadRepository ExpenseRead { get; }
        IExpenseWriteRepository ExpenseWrite { get; }
        IExpenseItemReadRepository ExpenseItemRead { get; }
        IExpenseItemWriteRepository ExpenseItemWrite { get; }
    }
}
