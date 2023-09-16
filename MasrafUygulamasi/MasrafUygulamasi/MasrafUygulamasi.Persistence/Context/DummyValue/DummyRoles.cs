using MasrafUygulamasi.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Context.DummyValue
{
	public class DummyRoles
    {
        public static void AddDummyRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppIdentityRole>().HasData(
            new AppIdentityRole
            { 
                Id = "1",
                Name = "personel", 
                NormalizedName = "PERSONEL", 
                Description = "Bu sirket personelidir",
            },
            new AppIdentityRole
            {
                Id = "2",
                Name = "yonetici",
                NormalizedName = "YONETICI",
                Description = "Bu sirket yoneticisidir",
            },
            new AppIdentityRole
            {
                Id = "3",
                Name = "muhasebeci",
                NormalizedName = "MUHASEBECI",
                Description = "Bu sirket muhasebecisidir",
            },
            new AppIdentityRole
            {
                Id = "4",
                Name = "admin",
                NormalizedName = "ADMIN",
                Description = "Admin",
            }
            );
        }
    }
}
