using MasrafUygulamasi.Domain.Entities;

namespace MasrafUygulamasi.MVC.Areas.Personnel.Helper
{
	public class HelperClass
	{
		public static void InitializeAddNewExpense(dynamic targetVM, List<CurrencyType> currencyTypes, List<ExpenseType> expenseTypes)
		{
			targetVM.AddToDropDownForCurrency(currencyTypes);
			targetVM.AddToDropDownForExpenseType(expenseTypes);
		}
	}
}
