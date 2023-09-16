using Microsoft.AspNetCore.Identity;

namespace MasrafUygulamasi.Domain.Identity
{
	public class AppIdentityRole : IdentityRole
    {
        public string? Description { get; set; }
    }
}
