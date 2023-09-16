using MasrafUygulamasi.Application.Interfaces;
using MasrafUygulamasi.Application.Interfaces.Repositories.CurrencyRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseItemRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseTpyeRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.StateRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.UserRepo;
using MasrafUygulamasi.Persistence.Context;

namespace MasrafUygulamasi.Persistence.Repositories
{
	public class UnitOfWork : IUnitOfWork
    {
        public IUserReadRepository UserRead { get; }

        public IUserWriteRepository UserWrite { get; }

		public ICurrencyReadRepository CurrencyRead { get; }

        public IExpenseTypeReadRepository ExpenseTypeRead { get; }
        public IStateReadRepository StateRead { get; }

		public IExpenseReadRepository ExpenseRead {get; }

		public IExpenseWriteRepository ExpenseWrite {get; }

		public IExpenseItemReadRepository ExpenseItemRead { get; }

		public IExpenseItemWriteRepository ExpenseItemWrite { get; }

		private readonly MasrafUygulamasiDB _dbContext;

        public UnitOfWork(IUserReadRepository userRead, IUserWriteRepository userWrite, MasrafUygulamasiDB dbContext, ICurrencyReadRepository currencyRead, IExpenseTypeReadRepository expenseTypeRead, IStateReadRepository stateRead, IExpenseReadRepository expenseRead, IExpenseWriteRepository expenseWrite, IExpenseItemReadRepository expenseItemRead, IExpenseItemWriteRepository expenseItemWrite)
        {
            UserRead = userRead;
            UserWrite = userWrite;
            _dbContext = dbContext;
            CurrencyRead = currencyRead;
            ExpenseTypeRead = expenseTypeRead;
            StateRead = stateRead;
            ExpenseRead = expenseRead;
            ExpenseWrite = expenseWrite;
            ExpenseItemRead = expenseItemRead;
            ExpenseItemWrite = expenseItemWrite;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
