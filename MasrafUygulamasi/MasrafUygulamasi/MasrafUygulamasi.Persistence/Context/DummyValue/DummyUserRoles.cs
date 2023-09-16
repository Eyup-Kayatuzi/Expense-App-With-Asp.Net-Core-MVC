using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Context.DummyValue
{
	public class DummyUserRoles
    {
        public static void AddUserRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
        new IdentityUserRole<string> { UserId = "1", RoleId = "1" },
        new IdentityUserRole<string> { UserId = "2", RoleId = "1" },
        new IdentityUserRole<string> { UserId = "3", RoleId = "2" },
        new IdentityUserRole<string> { UserId = "4", RoleId = "2" },
        new IdentityUserRole<string> { UserId = "5", RoleId = "4" },
        new IdentityUserRole<string> { UserId = "6", RoleId = "3" }

    );
        }
    }
}
