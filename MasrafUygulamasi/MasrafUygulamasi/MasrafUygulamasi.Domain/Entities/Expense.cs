using System.ComponentModel.DataAnnotations;
using MasrafUygulamasi.Domain.Entities.General;
using MasrafUygulamasi.Domain.Identity;

namespace MasrafUygulamasi.Domain.Entities
{
    public class Expense : BaseEntity
    {
        [MaxLength(50, ErrorMessage = "Maximum 50 karakter giriniz")]
        public string ExpenseTitle { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
        [Display(Name = "Yönetici Aciklamasi")]
        [MaxLength(100, ErrorMessage = "Maximum 100 karakter giriniz")]
        public string? ManagerDescription { get; set; }
        public string AppIdentityUserId { get; set; }
        public virtual AppIdentityUser AppIdentityUser { get; set; }
        public int ApprovalStateId { get; set; }
        public virtual State ApprovalState { get; set; }    
        public int CurrencyTypeId { get; set; }
        public virtual CurrencyType CurrencyType { get; set; }
		public virtual List<ExpenseItem> ExpenseItems { get; set; } = new List<ExpenseItem>();
	}
}
