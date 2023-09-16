using System.ComponentModel.DataAnnotations;

namespace MasrafUygulamasi.MVC.Areas.Personnel.CustomeValidation
{
	public class AllowedDataRange : ValidationAttribute
	{
		protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
		{
			DateTime date = Convert.ToDateTime(value);

			return (date <= DateTime.Now && date >= DateTime.Now.AddYears(-1)) ? ValidationResult.Success : new ValidationResult("Invalid data range for date");
		}
	}
}
