namespace MasrafUygulamasi.MVC.Areas.CompanyManager.ViewModels
{
	public class PendingExpensesVM
	{
		public string ExpenseTitle { get; set; }
		public string PersonnelName { get; set; }
		public int ExpenseId { get; set; }
		public List<ExpenseDetailsVM> ExpenseItemsList { get; set; } = new();
		public decimal TotalPrice { get; set; }
		public string CurrencyName { get; set; }

	}
}
