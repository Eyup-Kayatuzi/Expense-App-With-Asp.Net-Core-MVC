using System.ComponentModel.DataAnnotations;
using MasrafUygulamasi.Domain.Entities.General;

namespace MasrafUygulamasi.Domain.Entities
{
	public class CurrencyType : BaseEntity
    {
        [Display(Name = "Para Birimi")]
        [MaxLength(15,ErrorMessage = "Maximum 15 karakter giriniz")]
        public string CurrencyName { get; set; }
        public virtual List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
