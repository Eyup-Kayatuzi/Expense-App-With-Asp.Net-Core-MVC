using System.Data;
using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Entities;
using MasrafUygulamasi.Domain.Enums;
using MasrafUygulamasi.Domain.Identity;
using MasrafUygulamasi.MVC.Areas.Accountant.ViewModels;
using MasrafUygulamasi.MVC.Areas.CompanyManager.ViewModels;
using MasrafUygulamasi.MVC.Areas.Personnel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasrafUygulamasi.MVC.Areas.Accountant.Controllers
{
	[Area("Accountant")]
	[Authorize(Roles = "muhasebeci")]
	public class MainController : Controller
	{
		private readonly IUserService _userService;
		private readonly IExpenseService _expenseService;
		private readonly ICurrencyService _currencyService;
		private readonly IExpenseTypeService _expenseTypeService;
		public MainController(IUserService userService, IExpenseService expenseService, ICurrencyService currencyService, IExpenseTypeService expenseTypeService)
		{
			_userService = userService;
			_expenseService = expenseService;
			_currencyService = currencyService;
			_expenseTypeService = expenseTypeService;

		}
		public async Task<IActionResult> HomePage()
		{
			AppIdentityUser userInfo = (await _userService.UMGetUserByNameAsync(User.Identity.Name));
			return View(userInfo);
		}
		public async Task<IActionResult> FormDetails(int id)
		{
			var updateExpenseVM = new UpdateExpenseVM(
				await _currencyService.GetCurrencyTypesAsync(),
				await _expenseTypeService.GetExpenseTypesAsync());
			var targetExpense = await _expenseService
				.GetExpensesByIdAsync(id);
			updateExpenseVM.CurrencyType = _currencyService
				.GetCurrencyTypeNameByWhere(x => x.Id == targetExpense.CurrencyTypeId);
			updateExpenseVM.TitleName = targetExpense.ExpenseTitle;
			updateExpenseVM.ExpenseItems = (
				await _expenseService.GetExpensesWithItemsByIncludeAsync(x => x.Id == id, x => x.ExpenseItems))
				.FirstOrDefault().ExpenseItems
				.Select(x => new ExpenseItemsForUpdateVM
				{
					id = x.Id,
					ExpenseDate = x.ExpenseDate,
					ExpenseDescription = x.ExpenseDescription,
					ExpenseType = _expenseTypeService.GetExpenseTypeNameByWhere(a => a.Id == x.ExpenseTypeId),
					Price = x.Price
				}).ToList();
			updateExpenseVM.TotalPrice = targetExpense.TotalPrice;
			updateExpenseVM.ExpenseId = id;
			return View(updateExpenseVM);
		}

		public async Task<IActionResult> PendingPayment()
		{

			var approvedExpenses = await _expenseService
				.GetExpensesWithItemsByTwoIncludeAsync(
				statusType => statusType.ApprovalStateId == (int)StatusEnum.Approved, includeItems => includeItems.ExpenseItems,
				includeUserInfo => includeUserInfo.AppIdentityUser
				);
			List<PendingPaymentVM> expenses = new();
			foreach (var expense in approvedExpenses)
			{
				var superVisorInfo = await _userService
					.UMGetUserByIdAsync(expense.AppIdentityUser.SupervisorId);
				var pendingPayment = new PendingPaymentVM()
				{
					PersonnelName = expense.AppIdentityUser.FullName,
					PersonnelManager = superVisorInfo.FullName,
					CurrencyName = _currencyService
						.GetCurrencyTypeNameByWhere(curremcyId => curremcyId.Id == expense.CurrencyTypeId),
					ExpenseId = expense.Id,
					ExpenseTitle = expense.ExpenseTitle,
					TotalPrice = expense.TotalPrice,
					ExpenseItemsList = expense.ExpenseItems
						.Select(expenseDetail => new ExpenseDetailsVM()
						{
							ExpenseDates = expenseDetail.ExpenseDate,
							ExpenseNotes = expenseDetail.ExpenseDescription,
							ExpensePrice = expenseDetail.Price,
							ExpenseTypes = _expenseTypeService
							.GetExpenseTypeNameByWhere(
								expenseType => expenseType.Id == expenseDetail.ExpenseTypeId)
						}).ToList()
				};
				expenses.Add(pendingPayment);
			}
			return View(expenses);
		}
		public async Task<IActionResult> PayFromList(int id)
		{
			Expense targetExpense = await _expenseService.GetExpensesByIdAsync(id);
			if (targetExpense != null)
			{
				targetExpense.ApprovalStateId = (int)StatusEnum.Paid;
				targetExpense.UpdatedDate = DateTime.Now;
				bool result = _expenseService.UpdateExpense(targetExpense);
				if (!result)
				{
					TempData["fromPayFromList"] = "true";
				}
				else
				{

				}
			}
			else
			{
				TempData["fromPayFromList"] = "true";
			}
			return RedirectToAction("PendingPayment");
		}
	}
}
