using System.ComponentModel.DataAnnotations;
using MasrafUygulamasi.MVC.Areas.Personnel.CustomeValidation;

namespace MasrafUygulamasi.MVC.Areas.Personnel.ViewModels
{
	public class ExpenseItemsVM
    {
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
