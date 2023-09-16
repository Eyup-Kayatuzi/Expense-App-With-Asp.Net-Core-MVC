using System.ComponentModel.DataAnnotations;
using MasrafUygulamasi.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasrafUygulamasi.MVC.Areas.Personnel.ViewModels
{
	public class AddExpenseVM
	{
		public decimal TotalPrice { get; set; }
		[Required(ErrorMessage = "Title must be filled")]
		[MaxLength(50)]
		public string TitleName { get; set; }
        public string CurrencyType { get; set; }
		public List<SelectListItem> Currencies { get; set; } = new List<SelectListItem>();

        public List<string> ExpenseTypes { get; set; } = new List<string>();
		public List<ExpenseItemsVM> ExpenseItems { get; set; } = new();
		public AddExpenseVM()
        {
            
        }
        public AddExpenseVM(List<CurrencyType> currency, List<ExpenseType> expenseType)
		{
			AddToDropDownForCurrency(currency);
			AddToDropDownForExpenseType(expenseType);

        }

        public void AddToDropDownForExpenseType(List<ExpenseType> expenseType)
        {
            foreach (var item in expenseType)
            {
				ExpenseTypes.Add(item.ExpenseName);
			}
        }

        public void AddToDropDownForCurrency(List<CurrencyType> currency)
		{
			foreach (var item in currency)
			{

				if (item.CurrencyName == "TL")
				{
					Currencies.Add(new SelectListItem { Text = "₺", Value = item.CurrencyName });
				}
				else if (item.CurrencyName == "USD")
				{
					Currencies.Add(new SelectListItem { Text = "$", Value = item.CurrencyName });
				}
				else
				{
					Currencies.Add(new SelectListItem { Text = "€", Value = item.CurrencyName });
				}
			}
		}
	}
}
