using System.Linq.Expressions;
using MasrafUygulamasi.Application.Interfaces;
using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Concretes
{
	public class ExpenseService : IExpenseService
	{
		private readonly IUnitOfWork _unitOfWork;
        public ExpenseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddExpenseAsync(Expense expense)
		{
			return await _unitOfWork.ExpenseWrite.AddAsync(expense);
		}

		public async Task<List<Expense>> GetExpensesWithItemsByIncludeAsync(Expression<Func<Expense, bool>> predicate, Expression<Func<Expense, object>> predicateIclude)
		{
			return await _unitOfWork.ExpenseRead.GetWhereWithInclude(predicate, predicateIclude).ToListAsync();
		}
        public async Task<List<Expense>> GetExpensesWithItemsByTwoIncludeAsync(Expression<Func<Expense, bool>> predicate, Expression<Func<Expense, object>> predicateIclude, Expression<Func<Expense, object>> predicateIclude2)
        {
            return await _unitOfWork.ExpenseRead.GetWhereWithTwoInclude(predicate, predicateIclude,predicateIclude2).ToListAsync();
        }
		public async Task<List<Expense>> GetAllExpensesWithTwoIncludeAsync(Expression<Func<Expense, object>> predicateIclude, Expression<Func<Expense, object>> predicateIclude2)
		{
			return await _unitOfWork.ExpenseRead.GetAll().Include(predicateIclude).Include(predicateIclude2).ToListAsync();
		}
		public bool RemoveExpenseById(int id)
		{
			var targetExpense = _unitOfWork.ExpenseRead.GetFirstOrDefault(x => x.Id == id); 
			return _unitOfWork.ExpenseWrite.Remove(targetExpense);
		}
		public async Task<Expense> GetExpensesByIdAsync(int id)
		{
			return await _unitOfWork.ExpenseRead.GetFirstOrDefaultAsync(x => x.Id == id);
		}
		public bool UpdateExpense(Expense expense)
		{
			return _unitOfWork.ExpenseWrite.Update(expense);
		}

		public async Task<List<Expense>> GetAllExpensesWithWhereAsync(Expression<Func<Expense, bool>> predicate)
		{
			return await _unitOfWork.ExpenseRead.GetWhere(predicate).ToListAsync();
		}
	}
}
