using System.Linq.Expressions;
using MasrafUygulamasi.Domain.Entities;

namespace MasrafUygulamasi.Application.Interfaces.IServices
{
	public interface IExpenseItemService
	{
		Task<bool> AddExpenseItemRangeAsync(List<ExpenseItem> expenseItems);
		Task<List<ExpenseItem>> GetExpenseItemsWithIncludeByWhere(Expression<Func<ExpenseItem, bool>> predicate, Expression<Func<ExpenseItem, object>> predicateIclude);
		bool UpdateExpenseItemRange(List<ExpenseItem> expenseItems);
	}
}
