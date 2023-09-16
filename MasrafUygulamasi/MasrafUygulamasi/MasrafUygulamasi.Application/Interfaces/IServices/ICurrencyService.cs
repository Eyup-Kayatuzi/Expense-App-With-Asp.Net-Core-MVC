using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MasrafUygulamasi.Domain.Entities;

namespace MasrafUygulamasi.Application.Interfaces.IServices
{
	public interface ICurrencyService
	{
		Task<List<CurrencyType>> GetCurrencyTypesAsync();
		Task<int> GetIdByCurrencyTypeNameAsync(string name);
		string GetCurrencyTypeNameByWhere(Expression<Func<CurrencyType, bool>> predicate);
	}
}
