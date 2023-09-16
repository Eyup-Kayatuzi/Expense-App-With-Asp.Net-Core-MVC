using MasrafUygulamasi.MVC.Areas.CompanyManager.ViewModels;

namespace MasrafUygulamasi.MVC.Areas.Admin.ViewModels
{
	public class ExpenseSummaryVM
	{
		public string ExpenseTitle { get; set; }
		public string PersonnelName { get; set; }
		public string PersonnelManager { get; set; }
		public string ExpenseStatus { get; set; }
		public int ExpenseId { get; set; }
		public List<ExpenseDetailsVM> ExpenseItemsList { get; set; } = new();
		public decimal TotalPrice { get; set; }
		public string CurrencyName { get; set; }
	}
}
