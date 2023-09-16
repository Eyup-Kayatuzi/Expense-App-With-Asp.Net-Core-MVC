using System.ComponentModel.DataAnnotations;
using MasrafUygulamasi.Domain.Entities.General;

namespace MasrafUygulamasi.Domain.Entities
{
	public class State : BaseEntity
    {
        [MaxLength(15, ErrorMessage = "Maximum 15 karakter giriniz")]
        [Display(Name = "Onaylanma Durumu")]
        public string ApprovalStateName { get; set; }
        public virtual List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
