using MasrafUygulamasi.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MasrafUygulamasi.Domain.Identity
{
	public class AppIdentityUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public string Department { get; set; } = string.Empty;
        public string SupervisorId { get; set; } = string.Empty;
        public List<Expense> Expenses { get; set; } = new();
        
    }
}
