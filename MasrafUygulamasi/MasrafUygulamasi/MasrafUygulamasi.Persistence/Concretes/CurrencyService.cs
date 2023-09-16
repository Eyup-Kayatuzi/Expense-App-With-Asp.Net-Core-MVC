using System.Linq.Expressions;
using MasrafUygulamasi.Application.Interfaces;
using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Concretes
{
	public class CurrencyService : ICurrencyService
	{
		private readonly IUnitOfWork _unitOfWork;
		public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public string GetCurrencyTypeNameByWhere(Expression<Func<CurrencyType, bool>> predicate)
		{
			return (_unitOfWork.CurrencyRead.GetFirstOrDefault(predicate)).CurrencyName;
		}

		public async Task<List<CurrencyType>> GetCurrencyTypesAsync()
		{
			return await _unitOfWork.CurrencyRead.GetAll().ToListAsync();
		}

		public async Task<int> GetIdByCurrencyTypeNameAsync(string name)
		{
			return (await _unitOfWork.CurrencyRead.GetFirstOrDefaultAsync(x => x.CurrencyName == name)).Id;
		}
	}
}
