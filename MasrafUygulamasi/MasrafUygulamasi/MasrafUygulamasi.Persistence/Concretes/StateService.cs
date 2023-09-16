using System.Linq.Expressions;
using MasrafUygulamasi.Application.Interfaces;
using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Entities;

namespace MasrafUygulamasi.Persistence.Concretes
{
	public class StateService : IStateService
	{
		private readonly IUnitOfWork _unitOfWork;
        public StateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public string GetStateNameByWhere(Expression<Func<State, bool>> predicate)
		{
			return (_unitOfWork.StateRead.GetFirstOrDefault(predicate)).ApprovalStateName;
		}

		public async Task<int> GetIdByStateNameAsync(string name)
		{
			return (await _unitOfWork.StateRead.GetFirstOrDefaultAsync(x => x.ApprovalStateName == name)).Id;
		}

		public string GetStateNameById(int id)
		{
			return (_unitOfWork.StateRead.GetFirstOrDefault(x => x.Id == id)).ApprovalStateName;
		}
	}
}
