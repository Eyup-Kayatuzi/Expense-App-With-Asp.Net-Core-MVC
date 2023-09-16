using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Entities;
using MasrafUygulamasi.Domain.Enums;
using MasrafUygulamasi.Domain.Identity;
using MasrafUygulamasi.MVC.Areas.CompanyManager.ViewModels;
using MasrafUygulamasi.MVC.Areas.Personnel.Helper;
using MasrafUygulamasi.MVC.Areas.Personnel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasrafUygulamasi.MVC.Areas.Personnel.Controllers
{
	[Area("Personnel")]
	[Authorize(Roles = "personel")]
	public class MainController : Controller
	{
		private readonly IUserService _userService;
		private readonly ICurrencyService _currencyService;
		private readonly IExpenseTypeService _expenseTypeService;
		private readonly IStateService _stateService;
		private readonly IExpenseService _expenseService;
		private readonly IExpenseItemService _expenseItemService;
		public MainController(IUserService userService, ICurrencyService currencyService, IExpenseTypeService expenseTypeService, IStateService stateService, IExpenseService expenseService, IExpenseItemService expenseItemService)
		{
			_userService = userService;
			_currencyService = currencyService;
			_expenseTypeService = expenseTypeService;
			_stateService = stateService;
			_expenseService = expenseService;
			_expenseItemService = expenseItemService;
		}
		public async Task<IActionResult> HomePage()
		{
			AppIdentityUser userInfo = (await _userService.UMGetUserByNameAsync(User.Identity.Name));
			return View(userInfo);
		}
		public async Task<IActionResult> AddNewExpense()
		{
			return View(new AddExpenseVM(await _currencyService.
				GetCurrencyTypesAsync(),
				await _expenseTypeService.GetExpenseTypesAsync()));
		}
		[HttpPost]
		public async Task<IActionResult> AddNewExpense(AddExpenseVM addExpenseVM)
		{
			if (!ModelState.IsValid)
			{
				HelperClass.InitializeAddNewExpense(addExpenseVM, await _currencyService.GetCurrencyTypesAsync(), await _expenseTypeService.GetExpenseTypesAsync());
				return View(addExpenseVM);
			}
			else if (addExpenseVM.ExpenseItems.Count == 0)
			{
				TempData["FromAddNewExpense2"] = "false";
				return RedirectToAction("HomePage");
			}
			else
			{
				var user = await _userService.UMGetUserByNameAsync(User.Identity.Name);
				var currencyTypeId = await _currencyService.GetIdByCurrencyTypeNameAsync(addExpenseVM.CurrencyType);
				var approvalStateId = await _stateService.
					GetIdByStateNameAsync("Waiting");
				var expenseForm = new Expense()
				{
					TotalPrice = addExpenseVM.TotalPrice,
					ExpenseTitle = addExpenseVM.TitleName,
					AppIdentityUserId = user.Id,
					CurrencyTypeId = currencyTypeId,
					ApprovalStateId = approvalStateId
				};
				bool isExpensedAdded = await _expenseService
					.AddExpenseAsync(expenseForm);
				if (isExpensedAdded)
				{
					List<ExpenseItem> expenseItems = addExpenseVM
						.ExpenseItems
						.Select(x => new ExpenseItem()
						{
							ExpenseDate = (DateTime)x.ExpenseDate,
							ExpenseId = expenseForm.Id,
							ExpenseDescription = x.ExpenseDescription,
							Price = x.Price,
							ExpenseTypeId = _expenseTypeService.GetIdByExpenseTypeName(x.ExpenseType)
						}).ToList();
					await _expenseItemService.AddExpenseItemRangeAsync(expenseItems);
					TempData["FromAddNewExpense"] = "true";
					return RedirectToAction("HomePage");
				}
				else
				{
					HelperClass.InitializeAddNewExpense(addExpenseVM,
						await _currencyService.GetCurrencyTypesAsync(),
						await _expenseTypeService.GetExpenseTypesAsync());
					ModelState.AddModelError("GenelHata", "Error accured while saving to database. Please try again later");
					return View(addExpenseVM);
				}

			}
		}
		public async Task<IActionResult> UpdateFromList(int id)
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
		[HttpPost]
		public async Task<IActionResult> UpdateFromList(UpdateExpenseVM updateExpenseVM)
		{
			if (!ModelState.IsValid)
			{
				HelperClass.InitializeAddNewExpense(updateExpenseVM,
					await _currencyService.GetCurrencyTypesAsync(),
					await _expenseTypeService.GetExpenseTypesAsync());
				return View(updateExpenseVM);
			}
			else
			{
				var targetExpenseForm = await _expenseService
					.GetExpensesByIdAsync(updateExpenseVM.ExpenseId);
				if (targetExpenseForm != null)
				{
					targetExpenseForm.ApprovalStateId = (int)StatusEnum.Waiting;
					targetExpenseForm.ManagerDescription = null;
					targetExpenseForm.ExpenseTitle = updateExpenseVM.TitleName;
					targetExpenseForm.UpdatedDate = DateTime.Now;
					targetExpenseForm.TotalPrice = updateExpenseVM.TotalPrice;
					targetExpenseForm.CurrencyTypeId = await _currencyService
						.GetIdByCurrencyTypeNameAsync(updateExpenseVM.CurrencyType);
					bool res = _expenseService
						.UpdateExpense(targetExpenseForm);
					List<ExpenseItem> targetItems = updateExpenseVM.ExpenseItems
						.Select(x => new ExpenseItem()
						{
							Id = x.id,
							ExpenseDate = (DateTime)x.ExpenseDate,
							ExpenseDescription = x.ExpenseDescription,
							ExpenseId = updateExpenseVM.ExpenseId,
							ExpenseTypeId = _expenseTypeService.GetIdByExpenseTypeName(x.ExpenseType),
							Price = x.Price
						}).ToList();
					bool res2 = _expenseItemService
						.UpdateExpenseItemRange(targetItems);
				}
				else
				{
					TempData["isUpdated"] = "false";
				}
				TempData["UpdatedSuccess"] = "true";
				return RedirectToAction("ListExpenseForms");
			}
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
		public async Task<IActionResult> ListExpenseForms()
		{
			var user = await _userService
				.UMGetUserByNameAsync(User.Identity.Name);
			List<ListExpensesVM> expenses = (await _expenseService
				.GetExpensesWithItemsByIncludeAsync(x => x.AppIdentityUserId == user.Id, y => y.ExpenseItems))
				.Select(x => new ListExpensesVM()
				{
					ExpenseTitle = x.ExpenseTitle,
					UpdatedDate = x.UpdatedDate,
					ExpenseDetails = x.ExpenseItems.Select(a => _expenseTypeService.GetExpenseTypeNameByWhere(l => l.Id == a.ExpenseTypeId)).ToList(),
					ExpenseItemsList = x.ExpenseItems
						.Select(a => new ExpenseDetailsVM()
						{
							ExpenseDates = a.ExpenseDate,
							ExpenseNotes = a.ExpenseDescription,
							ExpensePrice = a.Price,
							ExpenseTypes = _expenseTypeService.GetExpenseTypeNameByWhere(l => l.Id == a.ExpenseTypeId)
						}).ToList()
					,
					ManagerDescription = x.ManagerDescription,
					TotalPrice = x.TotalPrice,
					ExpenseId = x.Id,
					CurrencyName = _currencyService.GetCurrencyTypeNameByWhere(m => m.Id == x.CurrencyTypeId),
					StatusName = _stateService.GetStateNameByWhere(m => m.Id == x.ApprovalStateId)
				}).ToList();
			return View(expenses);
		}
		public async Task<IActionResult> DeleteFromList(int id)
		{
			bool result = _expenseService.RemoveExpenseById(id);
			if (!result)
			{
				TempData["isDeleted"] = "true";
			}
			else
			{

			}
			return RedirectToAction("ListExpenseForms");
		}

	}
}
