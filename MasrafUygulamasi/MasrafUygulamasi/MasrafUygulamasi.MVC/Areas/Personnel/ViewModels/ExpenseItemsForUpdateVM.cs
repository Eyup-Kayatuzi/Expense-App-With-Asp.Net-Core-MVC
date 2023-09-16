using MasrafUygulamasi.MVC.Areas.Personnel.CustomeValidation;
using System.ComponentModel.DataAnnotations;

namespace MasrafUygulamasi.MVC.Areas.Personnel.ViewModels
{
	public class ExpenseItemsForUpdateVM
	{
		public int id { get; set; }
		[Required(ErrorMessage = "Date must be filled")]
		[AllowedDataRange]
		public DateTime? ExpenseDate { get; set; }
		[MaxLength(50)]
		public string? ExpenseDescription { get; set; }
		[Required(ErrorMessage = "This place must be filled")]
		public decimal Price { get; set; }
		[Required(ErrorMessage = "This place must be filled")]
		public string ExpenseType { get; set; }
	}
}
