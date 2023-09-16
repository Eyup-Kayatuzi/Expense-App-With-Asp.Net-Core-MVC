namespace MasrafUygulamasi.MVC.Areas.Admin.ViewModels
{
	public class ReportsVM
	{
		public List<string> UserName { get; set; } = new();
		public List<string> ExpenseTypeName { get; set; } = new();
		public List<decimal> TotalPriceTl { get; set; } = new();
		public List<decimal> TotalPriceTlForExpenseType { get; set; } = new();
		public List<decimal> TotalPriceUSD { get; set; } = new();
		public List<decimal> TotalPriceUSDForExpenseType { get; set; } = new();
		public List<decimal> TotalPriceEUR { get; set; } = new();
		public List<decimal> TotalPriceEURForExpenseType { get; set; } = new();
	}
}
