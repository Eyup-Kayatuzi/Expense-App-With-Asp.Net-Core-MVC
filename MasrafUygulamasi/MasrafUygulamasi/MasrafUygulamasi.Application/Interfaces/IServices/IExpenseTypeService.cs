using System.Linq.Expressions;
using MasrafUygulamasi.Domain.Entities;

namespace MasrafUygulamasi.Application.Interfaces.IServices
{
	public interface IExpenseTypeService
    {
        Task<List<ExpenseType>> GetExpenseTypesAsync();
		Task<int> GetIdByExpenseTypeNameAsync(string name);
		int GetIdByExpenseTypeName(string name);
		string GetExpenseTypeNameByWhere(Expression<Func<ExpenseType, bool>> predicate);
	}
}
