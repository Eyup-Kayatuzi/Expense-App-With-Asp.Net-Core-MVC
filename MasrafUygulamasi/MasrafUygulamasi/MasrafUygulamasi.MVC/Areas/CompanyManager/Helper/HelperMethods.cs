using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Entities;
using MasrafUygulamasi.Domain.Enums;
using MasrafUygulamasi.MVC.Areas.CompanyManager.ViewModels;

namespace MasrafUygulamasi.MVC.Areas.CompanyManager.Helper
{
	public class HelperMethods
	{
        public static bool UpdateExpenseFromManager(IExpenseService _expenseService, Expense targetExpense, UpdatePendingExpenseVM updatePending, StatusEnum statusEnum)
        {
			targetExpense.ApprovalStateId = (int)statusEnum;
			targetExpense.ManagerDescription = (updatePending.ManagerNote != null) ? updatePending.ManagerNote : targetExpense.ManagerDescription;
			targetExpense.UpdatedDate = DateTime.Now;
			return _expenseService.UpdateExpense(targetExpense);
		}

	}
}
