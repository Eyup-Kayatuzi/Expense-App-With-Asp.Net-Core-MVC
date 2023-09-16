using System.ComponentModel.DataAnnotations;
using MasrafUygulamasi.Domain.Entities.General;

namespace MasrafUygulamasi.Domain.Entities
{
    public class ExpenseType : BaseEntity
    {
        [Display(Name ="Harcama Tipi")]
        [MaxLength(50, ErrorMessage = "Maximum 50 karakter giriniz")]
        public string ExpenseName { get; set; }
        public virtual List<ExpenseItem> ExpenseItems { get; set; } = new List<ExpenseItem>(); 

    }
}
