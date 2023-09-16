using System.Linq.Expressions;
using MasrafUygulamasi.Application.Interfaces;
using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Concretes
{
	public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExpenseTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ExpenseType>> GetExpenseTypesAsync()
        {
            return await _unitOfWork.ExpenseTypeRead.GetAll().ToListAsync();
        }

		public async Task<int> GetIdByExpenseTypeNameAsync(string name)
		{
            return (await _unitOfWork.ExpenseTypeRead.GetFirstOrDefaultAsync(x => x.ExpenseName == name)).Id;
				
		}
		public int GetIdByExpenseTypeName(string name)
		{
			return (_unitOfWork.ExpenseTypeRead.GetFirstOrDefault(x => x.ExpenseName == name)).Id;

		}

		public string GetExpenseTypeNameByWhere(Expression<Func<ExpenseType, bool>> predicate)
		{
			return ( _unitOfWork.ExpenseTypeRead.GetFirstOrDefault(predicate)).ExpenseName;
		}
	}
}
