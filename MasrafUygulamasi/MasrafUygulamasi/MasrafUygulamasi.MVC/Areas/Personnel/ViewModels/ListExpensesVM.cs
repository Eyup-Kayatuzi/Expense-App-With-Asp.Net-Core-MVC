using MasrafUygulamasi.MVC.Areas.CompanyManager.ViewModels;

namespace MasrafUygulamasi.MVC.Areas.Personnel.ViewModels
{
	public class ListExpensesVM
	{
		public string ExpenseTitle { get; set; }
		public int ExpenseId { get; set; }
		public DateTime UpdatedDate { get; set; }
		public List<string> ExpenseDetails { get; set; } = new List<string>();
		public List<ExpenseDetailsVM> ExpenseItemsList { get; set; } = new();
		public string? ManagerDescription { get; set; }
		public decimal TotalPrice { get; set; }
		public string CurrencyName { get; set; }
		public string StatusName { get; set; }
	}
}
