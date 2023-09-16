using System.ComponentModel.DataAnnotations;
using MasrafUygulamasi.Domain.Entities.General;

namespace MasrafUygulamasi.Domain.Entities
{
	public class ExpenseItem : BaseEntity
    {
        [Display(Name = "Harcamanin Yapildigi Tarih")]
        public DateTime ExpenseDate { get; set; }
        [Display(Name ="Harcama Aciklamasi")]
        [MaxLength(100, ErrorMessage = "Maximum 100 karakter giriniz")]
        public string? ExpenseDescription { get; set; }
        public decimal Price { get; set; }  
        public int ExpenseTypeId { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }
        public int ExpenseId { get; set; }
        public virtual Expense Expense { get; set; }
    }
}
