using System.Data;
using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Enums;
using MasrafUygulamasi.Domain.Identity;
using MasrafUygulamasi.MVC.Areas.Admin.ViewModels;
using MasrafUygulamasi.MVC.Areas.CompanyManager.ViewModels;
using MasrafUygulamasi.MVC.Areas.Personnel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasrafUygulamasi.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "admin")]
	public class MainController : Controller
	{
		private readonly IUserService _userService;
		private readonly IExpenseService _expenseService;
		private readonly ICurrencyService _currencyService;
		private readonly IExpenseTypeService _expenseTypeService;
		private readonly IExpenseItemService _expenseItemService;
		private readonly IStateService _stateService;
		public MainController(IUserService userService, IExpenseService expenseService, ICurrencyService currencyService, IExpenseTypeService expenseTypeService, IStateService stateService, IExpenseItemService expenseItemService)
		{
			_userService = userService;
			_expenseService = expenseService;
			_currencyService = currencyService;
			_expenseTypeService = expenseTypeService;
			_stateService = stateService;
			_expenseItemService = expenseItemService;
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
		public async Task<IActionResult> ExpenseSummary()
		{
			var expenses = await _expenseService
				.GetAllExpensesWithTwoIncludeAsync(
				includeItems => includeItems.ExpenseItems,
				includeUserInfo => includeUserInfo.AppIdentityUser
				);
			List<ExpenseSummaryVM> expenseForms = new();
			foreach (var expense in expenses)
			{
				var superVisorInfo = await _userService
					.UMGetUserByIdAsync(expense.AppIdentityUser.SupervisorId);
				var expenseAndExpenseItems = new ExpenseSummaryVM()
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
							ExpenseTypes = _expenseTypeService.GetExpenseTypeNameByWhere(
								expenseType => expenseType.Id == expenseDetail.ExpenseTypeId)
						}).ToList(),
					ExpenseStatus = _stateService.GetStateNameById(expense.ApprovalStateId)
				};
				expenseForms.Add(expenseAndExpenseItems);
			}
			return View(expenseForms);
		}
		public async Task<IActionResult> Reports()
		{

			ReportsVM reportsVMs = new();
			var users = await _userService.UMGetAllUsersByRoleAsync("personel");
			var expenseTypes = await _expenseTypeService.GetExpenseTypesAsync();
			foreach (var user in users)
			{
				reportsVMs.UserName.Add(user.FullName);
				reportsVMs.TotalPriceTl.Add((await _expenseService
					.GetAllExpensesWithWhereAsync(x => x.AppIdentityUserId == user.Id && x.CurrencyTypeId == (int)CurrencyEnum.TL && x.ApprovalStateId == (int)StatusEnum.Paid))
					.Sum(x => x.TotalPrice));

				reportsVMs.TotalPriceUSD
					.Add((await _expenseService.GetAllExpensesWithWhereAsync(x => x.AppIdentityUserId == user.Id && x.CurrencyTypeId == (int)CurrencyEnum.USD && x.ApprovalStateId == (int)StatusEnum.Paid)).Sum(x => x.TotalPrice));

				reportsVMs.TotalPriceEUR.Add((
					await _expenseService
					.GetAllExpensesWithWhereAsync(x => x.AppIdentityUserId == user.Id && x.CurrencyTypeId == (int)CurrencyEnum.EUR && x.ApprovalStateId == (int)StatusEnum.Paid))
					.Sum(x => x.TotalPrice));
			}
			foreach (var expenseType in expenseTypes)
			{
				reportsVMs.ExpenseTypeName.Add(expenseType.ExpenseName);
				reportsVMs.TotalPriceTlForExpenseType
					.Add((await _expenseItemService
					.GetExpenseItemsWithIncludeByWhere(x => x.ExpenseTypeId == expenseType.Id, y => y.Expense))
					.Where(a => a.Expense.ApprovalStateId == (int)StatusEnum.Paid && a.Expense.CurrencyTypeId == (int)(CurrencyEnum.TL))
					.Sum(x => x.Price));

				reportsVMs.TotalPriceUSDForExpenseType.Add((await _expenseItemService
					.GetExpenseItemsWithIncludeByWhere(x => x.ExpenseTypeId == expenseType.Id, y => y.Expense))
					.Where(a => a.Expense.ApprovalStateId == (int)StatusEnum.Paid && a.Expense.CurrencyTypeId == (int)(CurrencyEnum.USD))
					.Sum(x => x.Price));

				reportsVMs.TotalPriceEURForExpenseType.Add((await _expenseItemService
					.GetExpenseItemsWithIncludeByWhere(x => x.ExpenseTypeId == expenseType.Id, y => y.Expense))
					.Where(a => a.Expense.ApprovalStateId == (int)StatusEnum.Paid && a.Expense.CurrencyTypeId == (int)(CurrencyEnum.EUR))
					.Sum(x => x.Price));
			}

			return View(reportsVMs);
		}
	}
}
