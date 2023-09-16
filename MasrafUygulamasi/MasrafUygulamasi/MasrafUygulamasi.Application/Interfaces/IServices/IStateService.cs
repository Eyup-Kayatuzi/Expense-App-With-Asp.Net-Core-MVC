using System.Linq.Expressions;
using MasrafUygulamasi.Domain.Entities;

namespace MasrafUygulamasi.Application.Interfaces.IServices
{
	public interface IStateService
	{
		Task<int> GetIdByStateNameAsync(string name);
		string GetStateNameByWhere(Expression<Func<State, bool>> predicate);
		string GetStateNameById(int id);
	}
}
