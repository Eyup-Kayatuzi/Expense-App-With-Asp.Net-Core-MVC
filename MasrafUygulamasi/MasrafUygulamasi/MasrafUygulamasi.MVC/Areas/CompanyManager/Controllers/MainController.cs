using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Enums;
using MasrafUygulamasi.Domain.Identity;
using MasrafUygulamasi.MVC.Areas.CompanyManager.Helper;
using MasrafUygulamasi.MVC.Areas.CompanyManager.ViewModels;
using MasrafUygulamasi.MVC.Areas.Personnel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasrafUygulamasi.MVC.Areas.CompanyManager.Controllers
{
	[Area("CompanyManager")]
	[Authorize(Roles = "yonetici")]
	public class MainController : Controller
	{
		private readonly IUserService _userService;
		private readonly IExpenseService _expenseService;
		private readonly IExpenseTypeService _expenseTypeService;
		private readonly ICurrencyService _currencyService;
		public MainController(IUserService userService, IExpenseService expenseService, IExpenseTypeService expenseTypeService, ICurrencyService currencyService, IStateService stateService)
		{
			_userService = userService;
			_expenseService = expenseService;
			_expenseTypeService = expenseTypeService;
			_currencyService = currencyService;
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
		public async Task<IActionResult> PendingExpenses()
		{
			var user = await _userService
				.UMGetUserByNameAsync(User.Identity.Name);
			var personnels = await _userService
				.UMGetUsersWhereAsync(x => x.SupervisorId == user.Id);
			List<List<PendingExpensesVM>> pendingExpenses = new();
			foreach (var personnel in personnels)
			{
				List<PendingExpensesVM> expenses = (
					await _expenseService.
					GetExpensesWithItemsByIncludeAsync(x => x.AppIdentityUserId == personnel.Id, y => y.ExpenseItems))
					.Where(x => x.ApprovalStateId == (int)StatusEnum.Waiting)
					.Select(x => new PendingExpensesVM()
					{
						ExpenseTitle = x.ExpenseTitle,
						ExpenseItemsList = x.ExpenseItems
						.Select(a => new ExpenseDetailsVM()
						{
							ExpenseDates = a.ExpenseDate,
							ExpenseNotes = a.ExpenseDescription,
							ExpensePrice = a.Price,
							ExpenseTypes = _expenseTypeService.GetExpenseTypeNameByWhere(l => l.Id == a.ExpenseTypeId)
						}).ToList(),
						TotalPrice = x.TotalPrice,
						ExpenseId = x.Id,
						CurrencyName = _currencyService
						.GetCurrencyTypeNameByWhere(m => m.Id == x.CurrencyTypeId),
						PersonnelName = x.AppIdentityUser.FullName
					}).ToList();
				pendingExpenses.Add(expenses);
			}
			return View(pendingExpenses);
		}
		[HttpPost]
		public async Task<IActionResult> ConfirmPendingExpense(UpdatePendingExpenseVM updatePending)
		{

			if (updatePending.ExpenseId != null && updatePending.ExpenseId != 0)
			{
				var targetExpense = await _expenseService.
					GetExpensesByIdAsync(updatePending.ExpenseId);
				if (targetExpense != null)
				{
					var result = HelperMethods.UpdateExpenseFromManager(_expenseService,targetExpense,updatePending,StatusEnum.Approved);
					if (!result)
					{
						TempData["fromUpdatePendingExpense"] = "false";
					}
				}
				else
				{
					TempData["fromUpdatePendingExpense"] = "false";
				}
			}
			else
			{
				TempData["fromUpdatePendingExpense"] = "false";
			}
			return RedirectToAction("PendingExpenses");

		}
		[HttpPost]
		public async Task<IActionResult> RejectPendingExpense(UpdatePendingExpenseVM updatePending)
		{

			if (updatePending.ExpenseId != null && updatePending.ExpenseId != 0 && updatePending.ManagerNote != null)
			{
				var targetExpense = await _expenseService.
					GetExpensesByIdAsync(updatePending.ExpenseId);
				if (targetExpense != null)
				{
					var result = HelperMethods.UpdateExpenseFromManager(_expenseService, targetExpense, updatePending, StatusEnum.Denied);
					if (!result)
					{
						TempData["fromUpdatePendingExpense"] = "false";
					}
				}
				else
				{
					TempData["fromUpdatePendingExpense"] = "false";
				}
			}
			else
			{
				TempData["fromUpdatePendingExpense"] = "false";
			}
			return RedirectToAction("PendingExpenses");

		}
	}
}
