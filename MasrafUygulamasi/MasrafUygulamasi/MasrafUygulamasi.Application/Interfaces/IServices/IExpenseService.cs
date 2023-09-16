using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MasrafUygulamasi.Domain.Entities;

namespace MasrafUygulamasi.Application.Interfaces.IServices
{
	public interface IExpenseService
	{
		Task<bool> AddExpenseAsync(Expense expense);
		Task<List<Expense>> GetExpensesWithItemsByIncludeAsync(Expression<Func<Expense, bool>> predicate, Expression<Func<Expense, object>> predicateIclude);
        Task<List<Expense>> GetExpensesWithItemsByTwoIncludeAsync(Expression<Func<Expense, bool>> predicate, Expression<Func<Expense, object>> predicateIclude, Expression<Func<Expense, object>> predicateIclude2);
		Task<List<Expense>> GetAllExpensesWithTwoIncludeAsync(Expression<Func<Expense, object>> predicateIclude, Expression<Func<Expense, object>> predicateIclude2);
		Task<List<Expense>> GetAllExpensesWithWhereAsync(Expression<Func<Expense, bool>> predicate);
		bool RemoveExpenseById(int id);
		Task<Expense> GetExpensesByIdAsync(int id);
		bool UpdateExpense(Expense expense);
	}
}
