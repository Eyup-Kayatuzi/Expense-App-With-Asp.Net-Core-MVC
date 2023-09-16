using System.Linq.Expressions;
using MasrafUygulamasi.Application.Interfaces;
using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Concretes
{
	public class ExpenseItemService : IExpenseItemService
	{
		private readonly IUnitOfWork _unitOfWork;
		public ExpenseItemService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<bool> AddExpenseItemRangeAsync(List<ExpenseItem> expenseItems)
		{
			return await _unitOfWork.ExpenseItemWrite.AddRangeAsync(expenseItems);
		}

		public async Task<List<ExpenseItem>> GetExpenseItemsWithIncludeByWhere(Expression<Func<ExpenseItem, bool>> predicate, Expression<Func<ExpenseItem, object>> predicateIclude)
		{
			return await _unitOfWork.ExpenseItemRead.GetWhere(predicate).Include(predicateIclude).ToListAsync();
		}

		public bool UpdateExpenseItemRange(List<ExpenseItem> expenseItems)
		{
			return _unitOfWork.ExpenseItemWrite.UpdateRange(expenseItems);
		}
	}
}
